// Главная форма

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
		}

		// Парсинг адреса
		private (string ip, int port) ParseUrl()
		{
			string[] urlAdress = tbUrl.Text.Split(':');
			string ip = urlAdress[0]; // Адрес
			int port = int.Parse(urlAdress[1]); // Порт
			return (ip, port);
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
				System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
				info.FileName = "ClientStorageServer.exe";
				info.Arguments = $"{server.ip} {server.port} {tbApiKey.Text} PING";
				info.RedirectStandardOutput = true;
				info.UseShellExecute = false;
				info.CreateNoWindow = true;

				using (System.Diagnostics.Process proc = System.Diagnostics.Process.Start(info))
				{
					string response = proc.StandardOutput.ReadToEnd();
					proc.WaitForExit();

					if (proc.ExitCode == 0) MessageBox.Show("Ответ сервера: " + response);
					else MessageBox.Show("Не удалось подключиться к серверу.");
				}
			}
			catch (Exception ex)
			{
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

				System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
				info.FileName = "ClientStorageServer.exe";
				info.Arguments = $"{server.ip} {server.port} {tbApiKey.Text} \"{name}\" \"{path}\"";
				info.UseShellExecute = false;
				info.CreateNoWindow = true;

				using (System.Diagnostics.Process proc = System.Diagnostics.Process.Start(info))
				{
					proc.WaitForExit();
					if (proc.ExitCode == 0) MessageBox.Show("Файл передан через сокет!");
					else MessageBox.Show("Ошибка передачи файла.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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