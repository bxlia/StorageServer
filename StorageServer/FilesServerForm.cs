// Форма Сервера

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
		private string root = @"C:\StorageServer_Data"; // Путь папки Сервера
		public string filePath = " ";
		private TreeNode lastNode = null;

		public FilesServerForm()
		{
			InitializeComponent();
		}

		private void FilesServerForm_Load(object sender, EventArgs e)
		{
			tvFilesServer.Nodes.Clear();

			if (!Directory.Exists(root)) Directory.CreateDirectory(root);
			TreeNode rootNode = new TreeNode(root);
			rootNode.Tag = root;
			rootNode.Nodes.Add("");
			tvFilesServer.Nodes.Add(rootNode);
			rootNode.Expand();
		}

		// Загрузка Папок и Файлов Сервера
		private void tvFilesServer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode curr = e.Node;
			if (curr.Tag == null) return;
			curr.Nodes.Clear();
			string p = curr.Tag.ToString();

			try
			{
				// Загрузка папок сервера
				string[] dirs = Directory.GetDirectories(p);
				foreach (string d in dirs)
				{
					TreeNode node = new TreeNode(Path.GetFileName(d));
					node.Tag = d;
					node.Nodes.Add("");
					curr.Nodes.Add(node);
				}

				// Загрузка файлов сервера
				string[] files = Directory.GetFiles(p);
				foreach (string f in files)
				{
					TreeNode node = new TreeNode(Path.GetFileName(f));
					node.Tag = f;
					node.ToolTipText = Path.GetFileName(f);
					curr.Nodes.Add(node);
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
			TreeNode selected = tvFilesServer.SelectedNode;
			if (selected == null) return;

			filePath = selected.Tag.ToString();
			lastNode = selected;
		}

		// Выбор Редактировать в панеле инструментов
		private void EditToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode edit = tvFilesServer.SelectedNode;
			if (edit == null) return;

			try
			{
				System.Diagnostics.Process.Start("notepad++.exe" , edit.Tag.ToString()); // Открытие дефолтного приложения-редактора
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Открыть Панель инструментов (ПКМ по тексту)
		private void tvFilesServer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				tvFilesServer.SelectedNode = e.Node;
				cmsFilesServer.Show(Cursor.Position);
			}
		}


	}
}
