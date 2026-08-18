namespace StorageServer
{
	partial class FilesPCForm
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
			this.tvFilesPC = new System.Windows.Forms.TreeView();
			this.cmsFilesPC = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.SelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsFilesPC.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvFilesPC
			// 
			this.tvFilesPC.ContextMenuStrip = this.cmsFilesPC;
			this.tvFilesPC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvFilesPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tvFilesPC.Location = new System.Drawing.Point(0, 0);
			this.tvFilesPC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tvFilesPC.Name = "tvFilesPC";
			this.tvFilesPC.ShowNodeToolTips = true;
			this.tvFilesPC.Size = new System.Drawing.Size(356, 823);
			this.tvFilesPC.TabIndex = 0;
			this.tvFilesPC.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFilesPC_BeforeExpand);
			this.tvFilesPC.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFilesPC_NodeMouseClick);
			// 
			// cmsFilesPC
			// 
			this.cmsFilesPC.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.cmsFilesPC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectedToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.CreateToolStripMenuItem,
            this.DeleteToolStripMenuItem});
			this.cmsFilesPC.Name = "contextMenuStrip1";
			this.cmsFilesPC.Size = new System.Drawing.Size(309, 198);
			// 
			// SelectedToolStripMenuItem
			// 
			this.SelectedToolStripMenuItem.Name = "SelectedToolStripMenuItem";
			this.SelectedToolStripMenuItem.Size = new System.Drawing.Size(205, 32);
			this.SelectedToolStripMenuItem.Text = "Выбрать";
			this.SelectedToolStripMenuItem.Click += new System.EventHandler(this.SelectedToolStripMenuItem_Click);
			// 
			// EditToolStripMenuItem
			// 
			this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
			this.EditToolStripMenuItem.Size = new System.Drawing.Size(205, 32);
			this.EditToolStripMenuItem.Text = "Редактировать";
			this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
			// 
			// CreateToolStripMenuItem
			// 
			this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
			this.CreateToolStripMenuItem.Size = new System.Drawing.Size(205, 32);
			this.CreateToolStripMenuItem.Text = "Создать";
			this.CreateToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItem_Click);
			// 
			// DeleteToolStripMenuItem
			// 
			this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
			this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(205, 32);
			this.DeleteToolStripMenuItem.Text = "Удалить";
			this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
			// 
			// FilesPCForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 823);
			this.Controls.Add(this.tvFilesPC);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FilesPCForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Load += new System.EventHandler(this.FilesPCForm_Load);
			this.cmsFilesPC.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip cmsFilesPC;
		private System.Windows.Forms.ToolStripMenuItem SelectedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
		public System.Windows.Forms.TreeView tvFilesPC;
		private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
	}
}