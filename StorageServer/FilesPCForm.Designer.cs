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
			this.выбратьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsFilesPC.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvFilesPC
			// 
			this.tvFilesPC.ContextMenuStrip = this.cmsFilesPC;
			this.tvFilesPC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvFilesPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tvFilesPC.Location = new System.Drawing.Point(0, 0);
			this.tvFilesPC.Name = "tvFilesPC";
			this.tvFilesPC.ShowNodeToolTips = true;
			this.tvFilesPC.Size = new System.Drawing.Size(474, 1029);
			this.tvFilesPC.TabIndex = 0;
			this.tvFilesPC.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFilesPC_BeforeExpand);
			this.tvFilesPC.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFilesPC_NodeMouseClick);
			// 
			// cmsFilesPC
			// 
			this.cmsFilesPC.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.cmsFilesPC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьToolStripMenuItem,
            this.редактироватьToolStripMenuItem});
			this.cmsFilesPC.Name = "contextMenuStrip1";
			this.cmsFilesPC.Size = new System.Drawing.Size(251, 80);
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
			// FilesPCForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(474, 1029);
			this.Controls.Add(this.tvFilesPC);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FilesPCForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Load += new System.EventHandler(this.FilesPCForm_Load);
			this.cmsFilesPC.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView tvFilesPC;
		private System.Windows.Forms.ContextMenuStrip cmsFilesPC;
		private System.Windows.Forms.ToolStripMenuItem выбратьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
	}
}