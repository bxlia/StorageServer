using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageServer
{
	public partial class StorageServerForm : Form
	{
		private FilesPCForm _filesPCWindow;
		private FilesServerForm _filesServerWindow;
		public StorageServerForm()
		{
			InitializeComponent();
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
	}
}
