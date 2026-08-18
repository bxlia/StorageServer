// Главная форма

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace StorageServer
{
	public partial class StorageServerForm : Form
	{
		// Глобальная переменная для хранения активной SSH-сессии
		private SshClient _sshClient;
		//private FilesServerForm frmServer = new FilesServerForm();
		//private FilesPCForm fPCForm = new FilesPCForm();
		private FilesPCForm _filesPCWindow;
		private FilesServerForm _filesServerWindow;
		private CancellationTokenSource _delaySearch;
		private string _currentUserEmail;

		public StorageServerForm(string email)
		{
			InitializeComponent();

			// Запоминаем, какой пользователь сейчас зашел
			_currentUserEmail = email;

			// Выводим имя пользователя в заголовок окна для проверки (по желанию)
			this.Text = $"StorageServer — Главная [{_currentUserEmail}]";
		}

		public StorageServerForm()
		{
			InitializeComponent();
			Console.SetOut(new ControlWriter(tbLog));
			// КОММЕНТАРИЙ: Пункт 1. Запуск настроек для нашего нового списка из дизайнера
			InitializeSearchSettings();
			ThemeManager.ApplyTheme(this);
		}

		// Парсинг адреса
		private (string ip, int port) ParseUrl()
		{
			string[] urlAdress = tbUrl.Text.Split(':');
			string ip = urlAdress[0]; // Адрес
			int port = int.Parse(urlAdress[1]); // Порт
			return (ip, port);
		}

		// Отчитывание времени сообщением в логе
		private void Log(string message)
		{
			tbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
		}

		// Кнопка открытия хранилища ПК
		private void btnOpenPC_Click(object sender, EventArgs e)
		{
			if (this._filesPCWindow == null)
			{
				this._filesPCWindow = new FilesPCForm();
				int newX = this.Left - this._filesPCWindow.Width;
				int newY = this.Top;
				this._filesPCWindow.Location = new Point(newX, newY);
				this._filesPCWindow.Show();
			}
			else
			{
				this._filesPCWindow.Close();
				this._filesPCWindow = null;
			}
		}

		// Кнопка открытия хранилища Сервера
		private void btnOpenServer_Click(object sender, EventArgs e)
		{
			if (this._filesServerWindow == null)
			{
				string rawAddress = tbUrl.Text.Trim();
				string serverPassword = tbApiKey.Text.Trim();

				if (string.IsNullOrEmpty(rawAddress) || string.IsNullOrEmpty(serverPassword))
				{
					MessageBox.Show("Сначала введите адрес сервера и пароль подключения!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				string host = rawAddress;
				int port = 2222;

				if (rawAddress.Contains(":"))
				{
					string[] parts = rawAddress.Split(':');
					if (parts.Length >= 2)
					{
						host = parts[0].Trim();
						int.TryParse(parts[1].Trim(), out port);
					}
				}

				// Передаем параметры, как это было изначально в рабочем коде
				this._filesServerWindow = new FilesServerForm(host, port, serverPassword);

				int newX = this.Left + this.Width;
				int newY = this.Top;
				this._filesServerWindow.Location = new Point(newX, newY);

				this._filesServerWindow.FormClosed += (s, args) => { this._filesServerWindow = null; };
				this._filesServerWindow.Show();
			}
			else
			{
				this._filesServerWindow.Close();
				this._filesServerWindow = null;
			}

		}

		
		// Подключаем Клиент к Серверу
		private async void btnCheck_Click(object sender, EventArgs e)
		{
			string rawAddress = tbUrl.Text.Trim();
			string enteredPassword = tbApiKey.Text.Trim();

			if (string.IsNullOrEmpty(rawAddress) || string.IsNullOrEmpty(enteredPassword))
			{
				MessageBox.Show("Пожалуйста, введите адрес сервера (IP:порт) и пароль!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string host = rawAddress;
			int port = 2222;

			if (rawAddress.Contains(":"))
			{
				string[] parts = rawAddress.Split(':');
				if (parts.Length >= 2)
				{
					host = parts[0].Trim();
					int.TryParse(parts[1].Trim(), out port);
				}
			}

			// ИЗНАЧАЛЬНО: Подключаемся строго как zizik
			string sshUsername = "zizik";

			tbUrl.Enabled = false;
			tbApiKey.Enabled = false;
			btnCheck.Enabled = false;

			AddSystemNotification($"Стучимся по SSH...");

			bool connectionSuccess = await Task.Run(() =>
			{
				try
				{
					_sshClient = new SshClient(host, port, sshUsername, enteredPassword);
					_sshClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(15);
					_sshClient.Connect();
					return _sshClient.IsConnected;
				}
				catch
				{
					return false;
				}
			});

			tbUrl.Enabled = true;
			tbApiKey.Enabled = true;
			btnCheck.Enabled = true;

			if (connectionSuccess)
			{
				AddSystemNotification("Защищенное соединение успешно установлено!");
				MessageBox.Show($"Вы успешно подключились к удаленному серверу {host}:{port}!", "StorageServer", MessageBoxButtons.OK, MessageBoxIcon.Information);

				CheckAndSaveServerSettings(rawAddress, enteredPassword);

				if (this._filesServerWindow != null)
				{
					await this._filesServerWindow.UpdateTreeAsync();
				}
			}
			else
			{
				MessageBox.Show("Не удалось связаться с сервером. Проверьте пароль.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
				if (_sshClient != null) _sshClient.Dispose();
			}
		}

		// Логика сохранения настроек в локальный файл вместо ломающихся Properties
		private void CheckAndSaveServerSettings(string address, string key)
		{
			// Защита: если текущий Email пустой, используем имя по умолчанию
			string emailKey = string.IsNullOrEmpty(_currentUserEmail) ? "DefaultUser" : _currentUserEmail;
			string cleanEmail = emailKey.Replace("@", "_").Replace(".", "_");
			string configPath = System.IO.Path.Combine(Application.StartupPath, $"{cleanEmail}_server.txt");

			string savedAddress = string.Empty;
			string savedKey = string.Empty;

			if (System.IO.File.Exists(configPath))
			{
				string[] lines = System.IO.File.ReadAllLines(configPath);
				if (lines.Length >= 2)
				{
					savedAddress = lines[0];
					savedKey = lines[1];
				}
			}

			if (address != savedAddress || key != savedKey)
			{
				DialogResult result = MessageBox.Show(
					$"Хотите сохранить введенный адрес и пароль для текущего аккаунта?\n" +
					"При следующем запуске программы они заполнятся автоматически.",
					"Сохранение настроек",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				);

				if (result == DialogResult.Yes)
				{
					try
					{
						System.IO.File.WriteAllLines(configPath, new string[] { address, key });
						AddSystemNotification("Параметры сервера привязаны к вашему локальному профилю.");
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Ошибка записи файла конфигурации: {ex.Message}", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}

			}

		}
		// Логика автоматического чтения настроек при входе (вызовите этот метод в StorageServerForm_Load)
		private void LoadUserServerSettings()
		{
			try
			{
				string emailKey = string.IsNullOrEmpty(_currentUserEmail) ? "DefaultUser" : _currentUserEmail;
				string cleanEmail = emailKey.Replace("@", "_").Replace(".", "_");
				string configPath = System.IO.Path.Combine(Application.StartupPath, $"{cleanEmail}_server.txt");

				if (System.IO.File.Exists(configPath))
				{
					string[] lines = System.IO.File.ReadAllLines(configPath);
					if (lines.Length >= 2)
					{
						tbUrl.Text = lines[0];
						tbApiKey.Text = lines[1];
						AddSystemNotification("Сохраненная конфигурация сервера успешно восстановлена.");
					}
				}
			}
			catch { /* Игнорируем ошибки при первом запуске, когда файла еще нет */ }
		}


		// Отправка Файлов через Сокет
		private async void btnSend_Click(object sender, EventArgs e)
		{
			if (this._filesPCWindow == null || string.IsNullOrWhiteSpace(this._filesPCWindow.filePath) || this._filesPCWindow.filePath == " ")
			{
				MessageBox.Show("Сначала выберите файл на форме ПК!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string rawAddress = tbUrl.Text.Trim();
			string serverPassword = tbApiKey.Text.Trim();

			if (string.IsNullOrEmpty(rawAddress) || string.IsNullOrEmpty(serverPassword))
			{
				MessageBox.Show("Введите адрес сервера и пароль!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string host = rawAddress;
			int port = 2222;
			if (rawAddress.Contains(":"))
			{
				string[] parts = rawAddress.Split(':');
				if (parts.Length >= 2)
				{
					host = parts[0].Trim();
					int.TryParse(parts[1].Trim(), out port);
				}
			}

			string localFilePath = this._filesPCWindow.filePath;
			string fileName = Path.GetFileName(localFilePath);

			// Отправляем строго в домашнюю папку zizik
			string targetFolder = "/home/zizik";
			string remoteFilePath = targetFolder + "/" + fileName;

			AddSystemNotification($"Отправка файла \"{fileName}\"...");
			btnSend.Enabled = false;

			bool uploadSuccess = await Task.Run(() =>
			{
				try
				{
					using (var sftp = new SftpClient(host, port, "zizik", serverPassword))
					{
						sftp.Connect();
						using (var fileStream = File.OpenRead(localFilePath))
						{
							sftp.UploadFile(fileStream, remoteFilePath);
						}
						sftp.Disconnect();
						return true;
					}
				}
				catch
				{
					return false;
				}
			});

			btnSend.Enabled = true;

			if (uploadSuccess)
			{
				MessageBox.Show($"Файл успешно отправлен в папку /home/zizik!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

				if (this._filesServerWindow != null)
				{
					await this._filesServerWindow.UpdateTreeAsync();
				}
			}
			else
			{
				MessageBox.Show("Не удалось передать файл.", "Ошибка отправки", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void ts_btnUpdate_Click(object sender, EventArgs e)
		{        
			try
			{
				if (_filesPCWindow != null) _filesPCWindow.UpdateTree();
				if (_filesServerWindow != null) _filesServerWindow.UpdateTreeAsync();
				Console.WriteLine("Все файловые структуры успешно обновлены");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}


		//------------------------------------------------------------------------------------------------------

			// Метод навигации при клике по списку
		private void InitializeSearchSettings()
		{
			lbSuggestions.ItemHeight = 26;
			lbSuggestions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			lbSuggestions.DrawItem += lbSuggestions_DrawItem;

			// При нажатии на элемент из списка программа переносит тебя в путь
			lbSuggestions.Click += (s, e) => {
				if (lbSuggestions.SelectedItem == null) return;

				string text = lbSuggestions.SelectedItem.ToString();
				lbSuggestions.Visible = false; // Прячем список

				// Вызываем метод для перехода по выбранному пути
				NavigateToTargetPath(text);
			};

			// Прячем список, если кликнуть в любое место
			this.Click += (s, e) => lbSuggestions.Visible = false;
		}

		private void NavigateToTargetPath(string suggestionText)
		{
			try
			{
				// Находим наш разделитель '|' и вырезаем чистый путь к файлу/папке
				int pipeIndex = suggestionText.IndexOf('|');
				if (pipeIndex > 0)
				{
					string targetPath = suggestionText.Substring(pipeIndex + 1).Trim();
					ts_tbSearch.Text = targetPath; // Выводим чистый путь в текстовое поле

					// Если строка начинается на "[ПК", перемещаем твое окно компьютера _filesPCWindow
					if (suggestionText.StartsWith("[ПК") && _filesPCWindow != null && !string.IsNullOrEmpty(targetPath))
					{
						// Если кликнули по файлу, берем путь к его папке. Если по папке — открываем напрямую.
						string folder = System.IO.Directory.Exists(targetPath) ? targetPath : System.IO.Path.GetDirectoryName(targetPath);

						_filesPCWindow.filePath = folder; // Задаем путь окну ПК
						_filesPCWindow.UpdateTree();      // Перерисовываем дерево папок ПК на экране
						Console.WriteLine($"[Навигация]: Успешно открыта папка ПК: {folder}");
					}
					// Если строка начинается на "[Сервер", перемещаем твое окно сервера _filesServerWindow
					else if (suggestionText.StartsWith("[Сервер") && _filesServerWindow != null)
					{
						_filesServerWindow.UpdateTreeAsync();  // Перерисовываем дерево сервера на экране
						Console.WriteLine($"[Навигация]: Успешно обновлено дерево Сервера для: {targetPath}");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка навигации: " + ex.Message);
			}
		}


		// Живой поиск при вводе текста (задержка 350 миллисекунд)
		private async void ts_tbSearch_TextChanged(object sender, EventArgs e)
		{
			string query = ts_tbSearch.Text;

			// Если в поле пусто или меньше 2 символов — прячем список и выходим
			if (string.IsNullOrWhiteSpace(query) || query.Length < 2)
			{
				lbSuggestions.Visible = false;
				return;
			}

			// Сбрасываем прошлый таск поиска, если пользователь продолжает набирать буквы
			_delaySearch?.Cancel();
			_delaySearch = new System.Threading.CancellationTokenSource();
			var token = _delaySearch.Token;

			try
			{
				await Task.Delay(350, token); // Задержка 350 мс
				if (!token.IsCancellationRequested)
				{
					// Запускаем параллельный поиск по всем дискам ПК и Серверу
					var localTask = Task.Run(() => FastScanLocal(query));
					var serverTask = FastScanServer(query);

					await Task.WhenAll(localTask, serverTask);

					// ВОзврат в поток UI для обновления списков
					this.Invoke((MethodInvoker)delegate {
						lbSuggestions.BeginUpdate();
						lbSuggestions.Items.Clear();

						foreach (var item in localTask.Result) lbSuggestions.Items.Add(item);
						foreach (var item in serverTask.Result) lbSuggestions.Items.Add(item);

						lbSuggestions.EndUpdate();
						lbSuggestions.BringToFront();
						lbSuggestions.Visible = lbSuggestions.Items.Count > 0;
					});
				}
			}
			catch (TaskCanceledException) { }
		}

		//  поиск по нажатию клавиши Enter
		private void ts_tbSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				e.SuppressKeyPress = true; // Полностью выключаем системный писк Windows

				_delaySearch?.Cancel(); // Останавливаем фоновый живой поиск

				// Если в списке есть хотя бы одна подсказка, файл — автоматически открываем самый первый (верхний)
				if (lbSuggestions.Items.Count > 0)
				{
					string firstItemText = lbSuggestions.Items[0].ToString();
					lbSuggestions.Visible = false; // Скрываем список

					// Вызываем переход к первому файлу
					NavigateToTargetPath(firstItemText);
				}
			}
		}
		// Поиск (Сканирует диски, обходя защищенные папки через очередь Queue)
		private List<string> FastScanLocal(string query)
		{
			var list = new List<string>();
			try
			{
				foreach (var drive in System.IO.DriveInfo.GetDrives())
				{
					if (!drive.IsReady) continue;

					// Поиск начинается честно с диска C:\ или D:\
					string startFolder = drive.RootDirectory.FullName;

					var queue = new Queue<string>();
					queue.Enqueue(startFolder);

					while (queue.Count > 0 && list.Count < 30) // Ограничиваем список 30 результатами
					{
						string current = queue.Dequeue();
						try
						{
							// 1. Ищем подходящие файлы в текущей папке
							string[] files = System.IO.Directory.GetFiles(current, $"*{query}*");
							foreach (var file in files)
							{
								list.Add($"[ПК ({drive.Name.Replace("\\", "")})] {System.IO.Path.GetFileName(file)} | {file}");
							}

							// 2. Ищем подходящие подпапки
							string[] subDirs = System.IO.Directory.GetDirectories(current);
							foreach (var dir in subDirs)
							{
								if (dir.ToLower().Contains(query.ToLower()))
								{
									list.Add($"[ПК ({drive.Name.Replace("\\", "")})] {System.IO.Path.GetFileName(dir)} | {dir}");
								}

								// Пропускаем только тяжелый системный кэш Windows и корзину, 
								// все остальные папки сканируются
								string name = System.IO.Path.GetFileName(dir).ToLower();
								if (name != "windows" && name != "$recycle.bin" && name != "microsoft" && !dir.StartsWith("C:\\ProgramData"))
								{
									queue.Enqueue(dir);
								}
							}
						}
						catch (UnauthorizedAccessException) { continue; } // Безопасно пропускаем закрытые папки системы
						catch (Exception) { continue; }
					}
				}
			}
			catch { }
			return list;
		}

		// Быстрый поиск на Сервере (Заглушка)
		private async Task<List<string>> FastScanServer(string query)
		{
			await Task.Delay(20); // Имитируем сетевой пинг
			return new List<string> { $"[Сервер] Удаленный_Объект_{query} | /remote/storage/{query}" };
		}

		private void lbSuggestions_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0) return;
			string text = lbSuggestions.Items[e.Index].ToString();

			// Настраиваем цвета: белый фон, темно-серый текст, синий/зеленый для тегов ПК/Сервера
			System.Drawing.Color bgColor = e.State.HasFlag(DrawItemState.Selected) ? System.Drawing.Color.FromArgb(225, 240, 252) : System.Drawing.Color.White;
			System.Drawing.Color textColor = e.State.HasFlag(DrawItemState.Selected) ? System.Drawing.Color.FromArgb(0, 90, 180) : System.Drawing.Color.FromArgb(40, 40, 40);
			System.Drawing.Color tagColor = text.StartsWith("[ПК") ? System.Drawing.Color.FromArgb(0, 122, 204) : System.Drawing.Color.FromArgb(0, 165, 80);

			using (var bgBrush = new System.Drawing.SolidBrush(bgColor)) e.Graphics.FillRectangle(bgBrush, e.Bounds);

			int closeTag = text.IndexOf(']') + 1;
			int pipe = text.IndexOf('|');

			if (closeTag > 0 && pipe > closeTag)
			{
				string tag = text.Substring(0, closeTag);
				string name = text.Substring(closeTag, pipe - closeTag);
				string path = " -> " + text.Substring(pipe + 1).Trim();

				var boldFont = new System.Drawing.Font(e.Font, System.Drawing.FontStyle.Bold);

				using (var brush = new System.Drawing.SolidBrush(tagColor)) e.Graphics.DrawString(tag, boldFont, brush, e.Bounds.X + 6, e.Bounds.Y + 4);
				int w1 = (int)e.Graphics.MeasureString(tag, boldFont).Width;

				using (var brush = new System.Drawing.SolidBrush(textColor)) e.Graphics.DrawString(name, e.Font, brush, e.Bounds.X + 6 + w1, e.Bounds.Y + 4);
				int w2 = (int)e.Graphics.MeasureString(name, e.Font).Width;

				System.Drawing.Color pathColor = e.State.HasFlag(DrawItemState.Selected) ? textColor : System.Drawing.Color.Gray;
				using (var brush = new System.Drawing.SolidBrush(pathColor)) e.Graphics.DrawString(path, e.Font, brush, e.Bounds.X + 6 + w1 + w2, e.Bounds.Y + 4);
			}
			else
			{
				using (var brush = new System.Drawing.SolidBrush(textColor)) e.Graphics.DrawString(text, e.Font, brush, e.Bounds.X + 6, e.Bounds.Y + 4);
			}
		}

		private void ts_btnSearch_Click(object sender, EventArgs e)
		{
			_delaySearch?.Cancel();

			// ИСПРАВЛЕНО: Кнопка "Поиск" теперь работает точно так же, как Enter — открывает первый файл из списка
			if (lbSuggestions.Items.Count > 0)
			{
				string firstItemText = lbSuggestions.Items[0].ToString();
				lbSuggestions.Visible = false;
				NavigateToTargetPath(firstItemText);
			}
		}

		//------------------------------------------------------------------------------------------------------
		private void StorageServerForm_Load(object sender, EventArgs e)
		{
			// Проверяем, есть ли сохраненная сессия
			string savedUser = Properties.Settings.Default.LastLoggedUser;
			string token = Properties.Settings.Default.UserToken;

			if (string.IsNullOrEmpty(savedUser) || string.IsNullOrEmpty(token))
			{
				// Если пользователь не вошел, открываем форму авторизации ПОВЕРХ главной
				using (AuthForm authForm = new AuthForm())
				{
					// ShowDialog() открывает окно строго спереди и блокирует MainForm, пока его не закроют
					if (authForm.ShowDialog() == DialogResult.OK)
					{
						// Запоминаем пользователя, который только что вошел/зарегистрировался
						_currentUserEmail = authForm.AuthorizedEmail;
						this.Text = $"StorageServer — Панель управления [{_currentUserEmail}]";

						// Проверяем, ввел ли он данные сервера на форме регистрации
						if (!string.IsNullOrEmpty(authForm.AuthorizedEmail) || !string.IsNullOrEmpty(authForm.ServerKey))
						{
							// Выдвигаем окно запроса на сохранение параметров
							PromptSaveServerDetails(authForm.AuthorizedEmail, authForm.ServerKey);
						}
						else
						{
							// Если при регистрации полей сервера не было, просто загружаем старые настройки этого юзера (если они есть)
							LoadUserServerSettings();
						}
					}
					else
					{
						// Если пользователь просто закрыл форму авторизации и не вошел — закрываем всю программу
						Application.Exit();
					}
				}
			}
			else
			{
				// Если пользователь уже был авторизован ранее, сразу подгружаем его сессию
				_currentUserEmail = savedUser;
				this.Text = $"StorageServer — Панель управления [{_currentUserEmail}]";
				LoadUserServerSettings();
			}
		}

		// Диалоговое окно запроса сохранения (по вашему плану)
		private void PromptSaveServerDetails(string address, string key)
		{
			DialogResult result = MessageBox.Show(
				$"Вы успешно зарегистрировались! Хотите сохранить адрес сервера ({address}) и его IP-ключ для аккаунта {_currentUserEmail}?",
				"Сохранение настроек сервера",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question
			);

			if (result == DialogResult.Yes)
			{
				// Генерируем уникальные имена настроек для конкретного пользователя, чтобы они не перемешивались
				string addressKey = _currentUserEmail + "_Url";
				string apiKey = _currentUserEmail + "_ServerKey";

				// Сохраняем данные в словарь настроек программы
				Properties.Settings.Default[addressKey] = address;
				Properties.Settings.Default[apiKey] = key;
				Properties.Settings.Default.Save();

				MessageBox.Show("Данные успешно привязаны к вашему профилю!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			// В любом случае автоматически подставляем их в поля программы на главной форме
			tbUrl.Text = address;
			tbApiKey.Text = key;
		}


		//------------------------------------------------------------------------------------------------------

		
		// Настройки -> Профиль -> Сменить почту
		private void tsMenuChangeEmail_Click(object sender, EventArgs e)
		{
			Form inputForm = new Form();
			Label lblText = new Label();
			System.Windows.Forms.TextBox txtInput = new System.Windows.Forms.TextBox();
			System.Windows.Forms.Button btnOk = new System.Windows.Forms.Button();

			inputForm.Text = "Смена почты";
			lblText.Text = "Введите новый Email адрес:";
			txtInput.Text = _currentUserEmail;
			btnOk.Text = "OK";
			btnOk.DialogResult = DialogResult.OK;

			lblText.SetBounds(20, 20, 260, 20);
			txtInput.SetBounds(20, 45, 245, 23);
			btnOk.SetBounds(185, 80, 80, 25);

			inputForm.ClientSize = new Size(290, 120);
			inputForm.Controls.AddRange(new Control[] { lblText, txtInput, btnOk });
			inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			inputForm.StartPosition = FormStartPosition.CenterParent;
			inputForm.MaximizeBox = false;
			inputForm.MinimizeBox = false;

			if (inputForm.ShowDialog() == DialogResult.OK)
			{
				string newEmail = txtInput.Text.Trim().ToLower();

				if (!string.IsNullOrWhiteSpace(newEmail) && newEmail.Contains("@") && newEmail != _currentUserEmail)
				{
					Properties.Settings.Default.LastLoggedUser = newEmail;
					Properties.Settings.Default.Save();

					_currentUserEmail = newEmail;
					this.Text = $"StorageServer — Панель управления [{_currentUserEmail}]";

					AddSystemNotification("Email успешно изменен на: " + _currentUserEmail);
					MessageBox.Show("Email успешно изменен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		// Настройки -> Профиль -> Выйти из аккаунта
		private void tsMenuLogout_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?", "Выход из системы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				// Полностью стираем токен и сессию, чтобы заблокировать автологин при старте
				Properties.Settings.Default.UserToken = string.Empty;
				Properties.Settings.Default.LastLoggedUser = string.Empty;
				Properties.Settings.Default.Save();

				// Перезапускаем программу, чтобы она открыла чистую форму входа
				Application.Restart();
			}
		}


		// Настройки -> Тема -> Светлая
		private void tsMenuLightTheme_Click(object sender, EventArgs e)
		{
			ThemeManager.SwitchTheme("Light"); // Меняем тему в конфиге
			ThemeManager.ApplyTheme(this);    // Мгновенно перекрашиваем форму
		}

		// Настройки -> Тема -> Тёмная
		private void tsMenuDarkTheme_Click(object sender, EventArgs e)
		{
			ThemeManager.SwitchTheme("Dark");  // Меняем тему в конфиге
			ThemeManager.ApplyTheme(this);    // Мгновенно перекрашиваем форму
		}



		// Публичный метод, можно вызывать из любой части программы
		public void AddSystemNotification(string message)
		{
			// Создаем новый кликабельный пункт для выпадающего списка ToolStrip
			ToolStripMenuItem notificationItem = new ToolStripMenuItem();
			notificationItem.Text = $"[{DateTime.Now.ToShortTimeString()}] {message}";
			notificationItem.Font = new Font("Segoe UI", 9F);

			// Вставляем новое уведомление на самый верх выпадающего списка кнопки ts_DDBtnNotifications
			ts_DDBtnNotifications.DropDownItems.Insert(0, notificationItem);

			// Маркируем кнопку уведомлений, сигнализируя пользователю о новом событии
			ts_DDBtnNotifications.Text = " ведомления (*)";
			ts_DDBtnNotifications.ForeColor = Color.Red; // Можно выделить цветом
		}

		// Клик по кнопке Уведомления сбрасывает флаг новизны, когда список открыт
		private void ts_DDBtnNotifications_DropDownOpened(object sender, EventArgs e)
		{
			ts_DDBtnNotifications.Text = "Уведомления";
			ts_DDBtnNotifications.ForeColor = SystemColors.ControlText; // Возвращаем стандартный цвет текста
		}

		//------------------------------------------------------------------------------------------------------
		// Визуал полей ввода
		private void tbUrl_Enter(object sender, EventArgs e)
		{
			if (tbUrl.Text == "Введите URL-адрес...")
			{
				tbUrl.Text = "";
				tbUrl.ForeColor = SystemColors.WindowText;
			}
		}

		private void tbUrl_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(tbUrl.Text))
			{
				tbUrl.Text = "Введите URL-адрес...";
				tbUrl.ForeColor = SystemColors.GrayText;
			}
		}

		private void tbApiKey_Enter(object sender, EventArgs e)
		{
			if (tbApiKey.Text == "Введите API-ключ...")
			{
				tbApiKey.Text = "";
				tbApiKey.ForeColor = SystemColors.WindowText;
			}
		}

		private void tbApiKey_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(tbApiKey.Text))
			{
				tbApiKey.Text = "Введите API-ключ...";
				tbApiKey.ForeColor = SystemColors.GrayText;
			}
		}

	}
}

public class ControlWriter : System.IO.TextWriter
{
	private System.Windows.Forms.TextBox _box;
	public ControlWriter(System.Windows.Forms.TextBox box)
	{
		_box = box;
	}

	public override void WriteLine(string value)
	{
		_box.AppendText($"[{DateTime.Now:HH:mm:ss}] {value}{Environment.NewLine}");
	}

	public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;
}

