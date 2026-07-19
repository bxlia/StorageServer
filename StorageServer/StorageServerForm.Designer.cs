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
			this.btnOpenPC = new System.Windows.Forms.Button();
			this.btnOpenServer = new System.Windows.Forms.Button();
			this.tbUrl = new System.Windows.Forms.TextBox();
			this.tbApiKey = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.btnCheck = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOpenPC
			// 
			this.btnOpenPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnOpenPC.Location = new System.Drawing.Point(12, 12);
			this.btnOpenPC.Name = "btnOpenPC";
			this.btnOpenPC.Size = new System.Drawing.Size(129, 962);
			this.btnOpenPC.TabIndex = 0;
			this.btnOpenPC.Text = "Ф\r\nА\r\nЙ\r\nЛ\r\n Ы ";
			this.btnOpenPC.UseVisualStyleBackColor = true;
			this.btnOpenPC.Click += new System.EventHandler(this.btnOpenPC_Click);
			// 
			// btnOpenServer
			// 
			this.btnOpenServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnOpenServer.Location = new System.Drawing.Point(1333, 12);
			this.btnOpenServer.Name = "btnOpenServer";
			this.btnOpenServer.Size = new System.Drawing.Size(129, 962);
			this.btnOpenServer.TabIndex = 1;
			this.btnOpenServer.Text = "С\r\nЕ\r\nР\r\nВ\r\nЕ\r\nР";
			this.btnOpenServer.UseVisualStyleBackColor = true;
			this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
			// 
			// tbUrl
			// 
			this.tbUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbUrl.Location = new System.Drawing.Point(183, 67);
			this.tbUrl.Name = "tbUrl";
			this.tbUrl.Size = new System.Drawing.Size(1100, 49);
			this.tbUrl.TabIndex = 2;
			this.tbUrl.Text = "Введите URL-адрес...";
			// 
			// tbApiKey
			// 
			this.tbApiKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbApiKey.Location = new System.Drawing.Point(183, 177);
			this.tbApiKey.Name = "tbApiKey";
			this.tbApiKey.Size = new System.Drawing.Size(1100, 49);
			this.tbApiKey.TabIndex = 3;
			this.tbApiKey.Text = "Введите API-ключ...";
			// 
			// btnSend
			// 
			this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnSend.Location = new System.Drawing.Point(183, 276);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(536, 75);
			this.btnSend.TabIndex = 4;
			this.btnSend.Text = "Отправить";
			this.btnSend.UseVisualStyleBackColor = true;
			// 
			// btnCheck
			// 
			this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnCheck.Location = new System.Drawing.Point(747, 276);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new System.Drawing.Size(536, 75);
			this.btnCheck.TabIndex = 5;
			this.btnCheck.Text = "Проверка сети";
			this.btnCheck.UseVisualStyleBackColor = true;
			// 
			// StorageServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1474, 1029);
			this.Controls.Add(this.btnCheck);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.tbApiKey);
			this.Controls.Add(this.tbUrl);
			this.Controls.Add(this.btnOpenServer);
			this.Controls.Add(this.btnOpenPC);
			this.Name = "StorageServerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Хранилище данных";
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
	}
}

