// Форма ПК 

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
		public string filePath = " ";
		private TreeNode lastNode = null;
		public FilesPCForm()
		{
			InitializeComponent();
			this.Load += FilesPCForm_Load;
		}

		// Подключение драйверов ПК
		private void FilesPCForm_Load(object sender, EventArgs e)
		{
			tvFilesPC.Nodes.Clear();
			string[] drives = Directory.GetLogicalDrives();

			foreach (string drive in drives)
			{
				TreeNode driveNode = new TreeNode(drive);
				driveNode.Tag = drive;
				driveNode.Nodes.Add(" ");
				tvFilesPC.Nodes.Add(driveNode);
			}
		}

		// Загрузка Папок и Файлов ПК
		private void tvFilesPC_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode currentNode = e.Node;
			if (currentNode.Tag == null) return;
			currentNode.Nodes.Clear();
			string currentPath = currentNode.Tag.ToString();

			try
			{
				// Загрузка Папок ПК
				string[] dirs = Directory.GetDirectories(currentPath);
				foreach (string dir in dirs)
				{
					string dirName = Path.GetFileName(dir);
					TreeNode childDirNode = new TreeNode(dirName);
					childDirNode.Tag = dir;
					childDirNode.Nodes.Add(" ");
					currentNode.Nodes.Add(childDirNode);
				}

				// Загрузка Файлов ПК
				string[] files = Directory.GetFiles(currentPath);
				foreach (string file in files)
				{
					string fileName = Path.GetFileName(file);
					TreeNode fileNode = new TreeNode(fileName);
					fileNode.Tag = file;
					fileNode.ToolTipText = fileName;
					currentNode.Nodes.Add(fileNode);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Выбор Добавить в панеле инструментов
		private void SelectedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = tvFilesPC.SelectedNode;
			if (selectedNode == null) return;

			filePath = selectedNode.Tag.ToString();
			lastNode = selectedNode;
		}

		// Выбор Редактировать в панеле инструментов
		private void EditToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = tvFilesPC.SelectedNode;
			if (selectedNode == null) return;
			try
			{
				string filePath = selectedNode.Tag.ToString();
				System.Diagnostics.Process.Start("notepad++.exe", filePath); // Открытие дефолтного приложения-редактора
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Открыть Панель инструментов (ПКМ по тексту)
		private void tvFilesPC_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				tvFilesPC.SelectedNode = e.Node;
				string path = e.Node.Tag.ToString();

				if (!Directory.Exists(path) && File.Exists(path))
				{
					cmsFilesPC.Show(Cursor.Position);
				}
			}
		}
	}
}
