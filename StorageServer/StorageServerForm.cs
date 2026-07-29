// Главная форма

using StorageServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageServer
{
	public partial class StorageServerForm : Form
	{
		//private FilesServerForm frmServer = new FilesServerForm();
		//private FilesPCForm fPCForm = new FilesPCForm();
		private FilesPCForm _filesPCWindow;
		private FilesServerForm _filesServerWindow;

		public StorageServerForm()
		{
			InitializeComponent();
			tbUrl.Text = "94.41.17.13:25565"; // Автоматически в поле ввода
			tbApiKey.Text = "bxlia_api_v0_6b4b4abcdefg1234567"; // Автоматически в поле ввода
			Console.SetOut(new ControlWriter(tbLog));
		}

		// Парсинг адреса
		private (string ip, int port) ParseUrl()
		{
			string[] urlAdress = tbUrl.Text.Split(':');
			string ip = urlAdress[0]; // Адрес
			int port = int.Parse(urlAdress[1]); // Порт
			return (ip, port);
		}

		// Отчитывание время сообщение в логе
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
				this._filesServerWindow = new FilesServerForm();
				int newX = this.Right;
				int newY = this.Top;
				this._filesServerWindow.Location = new Point(newX, newY);
				this._filesServerWindow.Show();
			}
			else
			{
				this._filesServerWindow.Close();
				this._filesServerWindow = null;
			}
		}


		// Подключаем Клиент к Серверу
		private void btnCheck_Click(object sender, EventArgs e)
		{
			try
			{
				var server = ParseUrl();

				// Пишем обычный Console.WriteLine — текст сам улетит в tbLogStorageServerForm
				Console.WriteLine($"Связь: {server.ip}:{server.port}");

				System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
				info.FileName = "ClientNetwork.exe";
				info.Arguments = $"{server.ip} {server.port} {tbApiKey.Text} PING";
				info.RedirectStandardOutput = true;
				info.UseShellExecute = false;
				info.CreateNoWindow = true;

				using (System.Diagnostics.Process proc = System.Diagnostics.Process.Start(info))
				{
					string res = proc.StandardOutput.ReadToEnd();
					proc.WaitForExit();

					if (proc.ExitCode == 0)
					{
						Console.WriteLine("Ответ: " + res);
						MessageBox.Show("Ответ сервера: " + res);
					}
					else
					{
						Console.WriteLine("Ошибка подключения");
						MessageBox.Show("Не удалось подключиться к серверу");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				MessageBox.Show(ex.Message);
			}
		}

		// Отправка Файлов через Сокет
		private void btnSend_Click(object sender, EventArgs e)
		{
			try
			{
				string path = _filesPCWindow.filePath;
				string name = Path.GetFileName(path);
				var server = ParseUrl();

				Console.WriteLine($"Файл: {name}");

				System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
				info.FileName = "ClientNetwork.exe";
				info.Arguments = $"{server.ip} {server.port} {tbApiKey.Text} \"{name}\" \"{path}\"";
				info.UseShellExecute = false;
				info.CreateNoWindow = true;

				Console.WriteLine("Отправка сокетом...");

				using (System.Diagnostics.Process proc = System.Diagnostics.Process.Start(info))
				{
					proc.WaitForExit();
					if (proc.ExitCode == 0)
					{
						Console.WriteLine("Успешно отправлено");
						MessageBox.Show("Файл успешно передан через C++ сокет!");
					}
					else
					{
						Console.WriteLine("Ошибка передачи");
						MessageBox.Show("Ошибка передачи файла.");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

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
	private TextBox _box;
	public ControlWriter(TextBox box) { _box = box; }
	public override void WriteLine(string value)
	{
		_box.AppendText($"[{DateTime.Now:HH:mm:ss}] {value}{Environment.NewLine}");
	}
	public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;
}

