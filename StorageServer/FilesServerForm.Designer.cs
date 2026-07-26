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
			this.выбратьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsFilesServer.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvFilesServer
			// 
			this.tvFilesServer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvFilesServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tvFilesServer.Location = new System.Drawing.Point(0, 0);
			this.tvFilesServer.Name = "tvFilesServer";
			this.tvFilesServer.ShowNodeToolTips = true;
			this.tvFilesServer.Size = new System.Drawing.Size(500, 1100);
			this.tvFilesServer.TabIndex = 0;
			this.tvFilesServer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFilesServer_BeforeExpand);
			this.tvFilesServer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFilesServer_NodeMouseClick);
			// 
			// cmsFilesServer
			// 
			this.cmsFilesServer.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.cmsFilesServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьToolStripMenuItem,
            this.редактироватьToolStripMenuItem});
			this.cmsFilesServer.Name = "cmsFilesServer";
			this.cmsFilesServer.Size = new System.Drawing.Size(251, 80);
			// 
			// выбратьToolStripMenuItem
			// 
			this.выбратьToolStripMenuItem.Name = "выбратьToolStripMenuItem";
			this.выбратьToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
			this.выбратьToolStripMenuItem.Text = "Выбрать";
			this.выбратьToolStripMenuItem.Click += new System.EventHandler(this.SelectedToolStripMenuItem_Click);
			// 
			// редактироватьToolStripMenuItem
			// 
			this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
			this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
			this.редактироватьToolStripMenuItem.Text = "Редактировать";
			this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
			// 
			// FilesServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 1100);
			this.Controls.Add(this.tvFilesServer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FilesServerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Load += new System.EventHandler(this.FilesServerForm_Load);
			this.cmsFilesServer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView tvFilesServer;
		private System.Windows.Forms.ContextMenuStrip cmsFilesServer;
		private System.Windows.Forms.ToolStripMenuItem выбратьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
	}
}