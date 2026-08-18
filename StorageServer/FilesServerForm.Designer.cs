namespace StorageServer
{
	partial class FilesServerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tvFilesServer = new System.Windows.Forms.TreeView();
			this.cmsFilesServer = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.SelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsFilesServer.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvFilesServer
			// 
			this.tvFilesServer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvFilesServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tvFilesServer.Location = new System.Drawing.Point(0, 0);
			this.tvFilesServer.Margin = new System.Windows.Forms.Padding(2);
			this.tvFilesServer.Name = "tvFilesServer";
			this.tvFilesServer.ShowNodeToolTips = true;
			this.tvFilesServer.Size = new System.Drawing.Size(356, 823);
			this.tvFilesServer.TabIndex = 0;
			this.tvFilesServer.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFilesServer_BeforeExpand);
			this.tvFilesServer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFilesServer_NodeMouseClick);
			// 
			// cmsFilesServer
			// 
			this.cmsFilesServer.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.cmsFilesServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectedToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.CreateToolStripMenuItem,
            this.DeleteToolStripMenuItem});
			this.cmsFilesServer.Name = "cmsFilesServer";
			this.cmsFilesServer.Size = new System.Drawing.Size(241, 165);
			// 
			// SelectedToolStripMenuItem
			// 
			this.SelectedToolStripMenuItem.Name = "SelectedToolStripMenuItem";
			this.SelectedToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
			this.SelectedToolStripMenuItem.Text = "Выбрать";
			this.SelectedToolStripMenuItem.Click += new System.EventHandler(this.SelectedToolStripMenuItem_Click);
			// 
			// EditToolStripMenuItem
			// 
			this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
			this.EditToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
			this.EditToolStripMenuItem.Text = "Редактировать";
			this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
			// 
			// CreateToolStripMenuItem
			// 
			this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
			this.CreateToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
			this.CreateToolStripMenuItem.Text = "Создать";
			this.CreateToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItem_Click);
			// 
			// DeleteToolStripMenuItem
			// 
			this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
			this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
			this.DeleteToolStripMenuItem.Text = "Удалить";
			this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
			// 
			// FilesServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 823);
			this.Controls.Add(this.tvFilesServer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FilesServerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.cmsFilesServer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip cmsFilesServer;
		private System.Windows.Forms.ToolStripMenuItem SelectedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
		public System.Windows.Forms.TreeView tvFilesServer;
		private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
	}
}