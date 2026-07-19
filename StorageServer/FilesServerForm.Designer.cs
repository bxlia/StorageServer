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
			this.lbFilesServer = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// lbFilesServer
			// 
			this.lbFilesServer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbFilesServer.FormattingEnabled = true;
			this.lbFilesServer.ItemHeight = 25;
			this.lbFilesServer.Location = new System.Drawing.Point(0, 0);
			this.lbFilesServer.Name = "lbFilesServer";
			this.lbFilesServer.Size = new System.Drawing.Size(500, 1100);
			this.lbFilesServer.TabIndex = 0;
			// 
			// FilesServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 1100);
			this.Controls.Add(this.lbFilesServer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FilesServerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lbFilesServer;
	}
}