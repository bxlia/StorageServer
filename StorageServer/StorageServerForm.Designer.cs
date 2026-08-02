namespace StorageServer
{
	partial class StorageServerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageServerForm));
			this.btnOpenPC = new System.Windows.Forms.Button();
			this.btnOpenServer = new System.Windows.Forms.Button();
			this.tbUrl = new System.Windows.Forms.TextBox();
			this.tbApiKey = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.btnCheck = new System.Windows.Forms.Button();
			this.tbLog = new System.Windows.Forms.TextBox();
			this.tsPanel = new System.Windows.Forms.ToolStrip();
			this.ts_btnUpdate = new System.Windows.Forms.ToolStripButton();
			this.tsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpenPC
			// 
			this.btnOpenPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnOpenPC.Location = new System.Drawing.Point(12, 89);
			this.btnOpenPC.Name = "btnOpenPC";
			this.btnOpenPC.Size = new System.Drawing.Size(129, 885);
			this.btnOpenPC.TabIndex = 0;
			this.btnOpenPC.Text = "Ф\r\nА\r\nЙ\r\nЛ\r\n Ы ";
			this.btnOpenPC.UseVisualStyleBackColor = true;
			this.btnOpenPC.Click += new System.EventHandler(this.btnOpenPC_Click);
			// 
			// btnOpenServer
			// 
			this.btnOpenServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnOpenServer.Location = new System.Drawing.Point(1333, 89);
			this.btnOpenServer.Name = "btnOpenServer";
			this.btnOpenServer.Size = new System.Drawing.Size(129, 885);
			this.btnOpenServer.TabIndex = 1;
			this.btnOpenServer.Text = "С\r\nЕ\r\nР\r\nВ\r\nЕ\r\nР";
			this.btnOpenServer.UseVisualStyleBackColor = true;
			this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
			// 
			// tbUrl
			// 
			this.tbUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbUrl.ForeColor = System.Drawing.Color.Gray;
			this.tbUrl.Location = new System.Drawing.Point(183, 111);
			this.tbUrl.Name = "tbUrl";
			this.tbUrl.Size = new System.Drawing.Size(1100, 49);
			this.tbUrl.TabIndex = 2;
			this.tbUrl.Text = "Введите URL-адрес...";
			this.tbUrl.Enter += new System.EventHandler(this.tbUrl_Enter);
			this.tbUrl.Leave += new System.EventHandler(this.tbUrl_Leave);
			// 
			// tbApiKey
			// 
			this.tbApiKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbApiKey.ForeColor = System.Drawing.Color.Gray;
			this.tbApiKey.Location = new System.Drawing.Point(183, 214);
			this.tbApiKey.Name = "tbApiKey";
			this.tbApiKey.Size = new System.Drawing.Size(1100, 49);
			this.tbApiKey.TabIndex = 3;
			this.tbApiKey.Text = "Введите API-ключ...";
			this.tbApiKey.Enter += new System.EventHandler(this.tbApiKey_Enter);
			this.tbApiKey.Leave += new System.EventHandler(this.tbApiKey_Leave);
			// 
			// btnSend
			// 
			this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnSend.Location = new System.Drawing.Point(183, 312);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(536, 75);
			this.btnSend.TabIndex = 4;
			this.btnSend.Text = "Отправить";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// btnCheck
			// 
			this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnCheck.Location = new System.Drawing.Point(747, 312);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new System.Drawing.Size(536, 75);
			this.btnCheck.TabIndex = 5;
			this.btnCheck.Text = "Проверка сети";
			this.btnCheck.UseVisualStyleBackColor = true;
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			// 
			// tbLog
			// 
			this.tbLog.BackColor = System.Drawing.Color.DarkGray;
			this.tbLog.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.tbLog.Location = new System.Drawing.Point(183, 436);
			this.tbLog.Multiline = true;
			this.tbLog.Name = "tbLog";
			this.tbLog.ReadOnly = true;
			this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbLog.Size = new System.Drawing.Size(1100, 517);
			this.tbLog.TabIndex = 6;
			// 
			// tsPanel
			// 
			this.tsPanel.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.tsPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_btnUpdate});
			this.tsPanel.Location = new System.Drawing.Point(0, 0);
			this.tsPanel.Name = "tsPanel";
			this.tsPanel.Size = new System.Drawing.Size(1474, 42);
			this.tsPanel.TabIndex = 7;
			this.tsPanel.Text = "toolStrip1";
			// 
			// ts_btnUpdate
			// 
			this.ts_btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("ts_btnUpdate.Image")));
			this.ts_btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btnUpdate.Name = "ts_btnUpdate";
			this.ts_btnUpdate.Size = new System.Drawing.Size(127, 36);
			this.ts_btnUpdate.Text = "Обновить";
			this.ts_btnUpdate.ToolTipText = "Обновить";
			this.ts_btnUpdate.Click += new System.EventHandler(this.ts_btnUpdate_Click);
			// 
			// StorageServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1474, 1029);
			this.Controls.Add(this.tsPanel);
			this.Controls.Add(this.tbLog);
			this.Controls.Add(this.btnCheck);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.tbApiKey);
			this.Controls.Add(this.tbUrl);
			this.Controls.Add(this.btnOpenServer);
			this.Controls.Add(this.btnOpenPC);
			this.Name = "StorageServerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Хранилище данных";
			this.tsPanel.ResumeLayout(false);
			this.tsPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpenPC;
		private System.Windows.Forms.Button btnOpenServer;
		private System.Windows.Forms.TextBox tbUrl;
		private System.Windows.Forms.TextBox tbApiKey;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnCheck;
		private System.Windows.Forms.TextBox tbLog;
		private System.Windows.Forms.ToolStrip tsPanel;
		private System.Windows.Forms.ToolStripButton ts_btnUpdate;
	}
}

