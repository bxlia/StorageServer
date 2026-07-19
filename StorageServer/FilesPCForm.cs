using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace StorageServer
{
	public partial class FilesPCForm : Form
	{
		public string SavedFilePath { get; private set; }
		private ListViewItem _showWithCursor = null;
		public FilesPCForm()
		{
			InitializeComponent();
		}
		private void FilesPCForm_Load(object sender, EventArgs e)
		{

		}
	}
}
