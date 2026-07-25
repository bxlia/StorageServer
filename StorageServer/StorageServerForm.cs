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
		//private FilesPCForm fPCForm = new FilesPCForm();
		private FilesPCForm _filesPCWindow;
		private FilesServerForm _filesServerWindow;

		public StorageServerForm()
		{
			InitializeComponent();
		}

		// 1. Общий метод для парсинга адреса (используем кортеж для возврата двух значений)
		private (string ip, int port) ParseUrl()
		{
			string[] urlAdress = tbUrl.Text.Split(':');
			string ip = urlAdress[0];
			int port = int.Parse(urlAdress[1]);
			return (ip, port);
		}

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

		private void btnSend_Click(object sender, EventArgs e)
		{
			try
			{
				string path = _filesPCWindow.filePath;
				string name = Path.GetFileName(path);
				byte[] data = File.ReadAllBytes(path);

				var server = ParseUrl();

				using (TcpClient client = new TcpClient(server.ip, server.port))
				{
					using (NetworkStream stream = client.GetStream())
					{
						StreamWriter writer = new StreamWriter(stream);
						writer.WriteLine(tbApiKey.Text); 
						writer.WriteLine(name);         
						writer.Flush();

						stream.Write(data, 0, data.Length);
						stream.Flush();
					}
				}

				MessageBox.Show("Отправлено через сокет!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnCheck_Click(object sender, EventArgs e)
		{
			try
			{
				var server = ParseUrl();

				// Открываем прямое TCP-подключение
				using (TcpClient client = new TcpClient(server.ip, server.port))
				{
					using (NetworkStream stream = client.GetStream())
					{
						StreamWriter writer = new StreamWriter(stream);
						StreamReader reader = new StreamReader(stream);

						// Отправляем API-ключ и команду проверки
						writer.WriteLine(tbApiKey.Text);
						writer.WriteLine("PING");
						writer.Flush();

						// Считываем мгновенный ответ от сервера
						string response = reader.ReadLine();
						MessageBox.Show("Ответ сервера: " + response);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Сервер недоступен: " + ex.Message);
			}
		}

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
			}
		}
	}
}