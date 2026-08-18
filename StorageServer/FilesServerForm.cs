// Форма Сервера

using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageServer
{
	public partial class FilesServerForm : Form
	{
		private readonly string _host;
		private readonly int _port;
		private readonly string _password;

		public string remoteFilePath = " ";
		private TreeNode lastNode = null;

		public FilesServerForm(string host, int port, string password)
		{
			InitializeComponent();

			_host = host;
			_port = port;
			_password = password;

			ThemeManager.ApplyTheme(this);
			this.Load += FilesServerForm_Load;
		}

		// Подключение корневой папки сервера
		private async void FilesServerForm_Load(object sender, EventArgs e)
		{
			this.Text = $"Проводник сервера — {_host}:{_port}";
			await UpdateTreeAsync();
		}

		public async Task UpdateTreeAsync()
		{
			tvFilesServer.Nodes.Clear();

			string defaultPath = "/home/zizik";
			this.Text = $"Проводник сервера — zizik@{_host}:{_port}";

			TreeNode rootNode = new TreeNode(defaultPath);
			rootNode.Tag = defaultPath;

			await Task.Run(() =>
			{
				try
				{
					var connectionInfo = new PasswordConnectionInfo(_host, _port, "zizik", _password)
					{
						Timeout = TimeSpan.FromSeconds(15),
						Encoding = System.Text.Encoding.UTF8
					};

					using (var sftp = new SftpClient(connectionInfo))
					{
						sftp.Connect();
						var files = sftp.ListDirectory(defaultPath);

						this.Invoke((MethodInvoker)delegate
						{
							foreach (var file in files)
							{
								if (file.Name == "." || file.Name == "..") continue;

								TreeNode node = new TreeNode(file.Name);
								node.Tag = file.FullName;

								if (file.IsDirectory)
								{
									node.Nodes.Add(" ");
								}
								else
								{
									node.ToolTipText = file.Name;
								}
								rootNode.Nodes.Add(node);
							}
						});
						sftp.Disconnect();
					}
				}
				catch { }
			});

			tvFilesServer.Nodes.Add(rootNode);
			rootNode.Expand();

		}

		// Ленивая загрузка папок и файлов с удаленного сервера
		public async void tvFilesServer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode currentNode = e.Node;
			if (currentNode.Tag == null) return;

			currentNode.Nodes.Clear();
			string currentRemotePath = currentNode.Tag.ToString();
			string dynamicUser = currentRemotePath.StartsWith("/opt") ? "bulya" : "zizik";

			await Task.Run(() =>
			{
				try
				{
					// Настраиваем подключение для пользователя bulya с поддержкой русского языка (UTF-8)
					var connectionInfo = new PasswordConnectionInfo(_host, _port, dynamicUser, _password)
					{
						Timeout = TimeSpan.FromSeconds(15),
						Encoding = System.Text.Encoding.UTF8 // Чтобы русские буквы папок не ломались!
					};

					using (var sftp = new SftpClient(connectionInfo))
					{
						sftp.Connect();
						var files = sftp.ListDirectory(currentRemotePath);

						this.Invoke((MethodInvoker)delegate
						{
							foreach (var file in files)
							{
								if (file.Name == "." || file.Name == "..") continue;

								if (file.IsDirectory)
								{
									// Папки сервера ("тест", "майн сервер")
									TreeNode childDirNode = new TreeNode(file.Name);
									childDirNode.Tag = file.FullName;
									childDirNode.Nodes.Add(" ");
									currentNode.Nodes.Add(childDirNode);
								}
								else
								{
									// Файлы сервера
									TreeNode fileNode = new TreeNode(file.Name);
									fileNode.Tag = file.FullName;
									fileNode.ToolTipText = file.Name;
									currentNode.Nodes.Add(fileNode);
								}
							}
						});

						sftp.Disconnect();
					}
				}
				catch (Exception ex)
				{
					this.Invoke((MethodInvoker)delegate
					{
						MessageBox.Show($"Не удалось прочитать папку сервера: {ex.Message}", "Ошибка SFTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					});
				}
			});
		}

		// Выбор Добавить в контекстном меню сервера
		private void SelectedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = tvFilesServer.SelectedNode;
			if (selectedNode == null || selectedNode.Tag == null) return;

			remoteFilePath = selectedNode.Tag.ToString().Trim();
			lastNode = selectedNode;

			// Записываем выбранный путь папки в глобальный мост программы
			Program.SelectedRemoteFolderPath = remoteFilePath;

			MessageBox.Show($"Целевая папка выбрана:\n{remoteFilePath}", "StorageServer", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// Простой выбор Редактировать в контекстном меню сервера (ПКМ)
		private async void EditToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = tvFilesServer.SelectedNode;
			if (selectedNode == null || selectedNode.Tag == null) return;

			string targetRemotePath = selectedNode.Tag.ToString().Trim();
			string fileName = Path.GetFileName(targetRemotePath);
			string localTempPath = Path.Combine(Path.GetTempPath(), fileName);

			try
			{
				tvFilesServer.Enabled = false;

				// Сами определяем, кому принадлежит файл, строго по его пути (/home/bulya или /home/zizik)
				string activeUser = "zizik";
				if (targetRemotePath.Contains("bulya"))
				{
					activeUser = "bulya";
				}

				// ШАГ 0: Выдаем полные права на файл (chmod 777) под ПРАВИЛЬНЫМ пользователем
				await Task.Run(() =>
				{
					try
					{
						using (var ssh = new SshClient(_host, _port, activeUser, _password))
						{
							ssh.Connect();
							ssh.RunCommand($"chmod 777 \"{targetRemotePath}\"");
							ssh.Disconnect();
						}
					}
					catch { }
				});

				// ШАГ 1: Скачивание файла на ПК в кодировке UTF-8 под ПРАВИЛЬНЫМ пользователем
				bool downloadSuccess = await Task.Run(() =>
				{
					try
					{
						var connectionInfo = new PasswordConnectionInfo(_host, _port, activeUser, _password)
						{
							Timeout = TimeSpan.FromSeconds(15),
							Encoding = System.Text.Encoding.UTF8
						};

						using (var sftp = new SftpClient(connectionInfo))
						{
							sftp.Connect();
							using (var fileStream = File.Create(localTempPath))
							{
								sftp.DownloadFile(targetRemotePath, fileStream);
							}
							sftp.Disconnect();
							return true;
						}
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine($"Ошибка скачивания SFTP: {ex.Message}");
						return false;
					}
				});

				tvFilesServer.Enabled = true;

				if (!downloadSuccess)
				{
					MessageBox.Show($"Ошибка доступа!\nНе удалось прочитать файл '{fileName}'.\nУбедитесь, что у пользователя {activeUser} есть права на этот объект в Linux.",
									"Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					if (File.Exists(localTempPath)) File.Delete(localTempPath);
					return;
				}

				// ШАГ 2: Запуск Блокнота Windows и ожидание его закрытия
				using (Process notepadProcess = Process.Start(new ProcessStartInfo { FileName = "notepad.exe", Arguments = $"\"{localTempPath}\"", UseShellExecute = true }))
				{
					if (notepadProcess != null)
					{
						await Task.Run(() => notepadProcess.WaitForExit());
					}
				}

				tvFilesServer.Enabled = false;

				// ШАГ 3: Автоматическая отправка обновлённого файла обратно под ПРАВИЛЬНЫМ пользователем
				await Task.Run(() =>
				{
					try
					{
						var connectionInfo = new PasswordConnectionInfo(_host, _port, activeUser, _password)
						{
							Timeout = TimeSpan.FromSeconds(15),
							Encoding = System.Text.Encoding.UTF8
						};

						using (var sftp = new SftpClient(connectionInfo))
						{
							sftp.Connect();
							using (var fileStream = File.OpenRead(localTempPath))
							{
								sftp.UploadFile(fileStream, targetRemotePath, true);
							}
							sftp.Disconnect();
						}
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine($"Ошибка отправки SFTP: {ex.Message}");
					}
				});

				tvFilesServer.Enabled = true;

				if (File.Exists(localTempPath)) File.Delete(localTempPath);
				await UpdateTreeAsync();
			}
			catch (Exception ex)
			{
				tvFilesServer.Enabled = true;
				MessageBox.Show($"Ошибка редактирования: {ex.Message}", "Сбой", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private async void CreateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = tvFilesServer.SelectedNode;
			if (selectedNode == null || selectedNode.Tag == null) return;

			string currentRemotePath = selectedNode.Tag.ToString().Trim();

			// Если выбрали файл, поднимаемся на уровень выше к папке (в Linux папки обычно не имеют расширения)
			if (selectedNode.Text.Contains(".") && selectedNode.Parent != null)
			{
				currentRemotePath = selectedNode.Parent.Tag.ToString().Trim();
			}

			string newFilePath = currentRemotePath.EndsWith("/") ? currentRemotePath + "new_file.txt" : currentRemotePath + "/new_file.txt";

			try
			{
				await Task.Run(() =>
				{
					using (var sftp = new SftpClient(_host, _port, "zizik", _password))
					{
						sftp.Connect();

						// Проверяем уникальность имени, чтобы не затереть старые файлы
						int counter = 1;
						while (sftp.Exists(newFilePath))
						{
							newFilePath = currentRemotePath.EndsWith("/") ?
								currentRemotePath + $"new_file({counter++}).txt" :
								currentRemotePath + $"/new_file({counter++}).txt";
						}

						// Создаем пустой файл на Linux-сервере
						using (var stream = sftp.Create(newFilePath)) { }
						sftp.Disconnect();
					}
				});

				await UpdateTreeAsync(); // Мгновенно обновляем дерево сервера на экране
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка создания на сервере: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = tvFilesServer.SelectedNode;
			if (selectedNode == null || selectedNode.Tag == null) return;

			string targetRemotePath = selectedNode.Tag.ToString().Trim();
			string name = Path.GetFileName(targetRemotePath);

			DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить \"{name}\" с Linux-сервера?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
			{
				try
				{
					await Task.Run(() =>
					{
						using (var sftp = new SftpClient(_host, _port, "zizik", _password))
						{
							sftp.Connect();

							// Проверяем: файл это или директория, и вызываем нужный метод удаления SFTP
							var attributes = sftp.GetAttributes(targetRemotePath);
							if (attributes.IsDirectory)
							{
								sftp.DeleteDirectory(targetRemotePath);
							}
							else
							{
								sftp.DeleteFile(targetRemotePath);
							}

							sftp.Disconnect();
						}
					});

					await UpdateTreeAsync(); // Мгновенно обновляем дерево сервера на экране
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка удаления на сервере: {ex.Message}.\nВозможно, папка не пуста или доступ ограничен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}


		// Открыть Панель инструментов (ПКМ по тексту)
		private void tvFilesServer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				TreeNode clickedNode = tvFilesServer.GetNodeAt(e.X, e.Y);
				if (clickedNode != null)
				{
					tvFilesServer.SelectedNode = clickedNode;
					if (clickedNode.Tag == null) return;
					cmsFilesServer.Show(Cursor.Position);
				}
			}
		}


	}
}
