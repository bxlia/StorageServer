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
			this.ts_tbSearch = new System.Windows.Forms.ToolStripTextBox();
			this.ts_btnSearch = new System.Windows.Forms.ToolStripButton();
			this.ts_DDBtnSettings = new System.Windows.Forms.ToolStripDropDownButton();
			this.профильToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsMenuChangeEmail = new System.Windows.Forms.ToolStripMenuItem();
			this.tsMenuLogout = new System.Windows.Forms.ToolStripMenuItem();
			this.темаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsMenuLightTheme = new System.Windows.Forms.ToolStripMenuItem();
			this.tsMenuDarkTheme = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_DDBtnNotifications = new System.Windows.Forms.ToolStripDropDownButton();
			this.lbSuggestions = new System.Windows.Forms.ListBox();
			this.tsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpenPC
			// 
			this.btnOpenPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnOpenPC.Location = new System.Drawing.Point(9, 71);
			this.btnOpenPC.Margin = new System.Windows.Forms.Padding(2);
			this.btnOpenPC.Name = "btnOpenPC";
			this.btnOpenPC.Size = new System.Drawing.Size(97, 708);
			this.btnOpenPC.TabIndex = 0;
			this.btnOpenPC.Text = "Ф\r\nА\r\nЙ\r\nЛ\r\n Ы ";
			this.btnOpenPC.UseVisualStyleBackColor = true;
			this.btnOpenPC.Click += new System.EventHandler(this.btnOpenPC_Click);
			// 
			// btnOpenServer
			// 
			this.btnOpenServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnOpenServer.Location = new System.Drawing.Point(1000, 71);
			this.btnOpenServer.Margin = new System.Windows.Forms.Padding(2);
			this.btnOpenServer.Name = "btnOpenServer";
			this.btnOpenServer.Size = new System.Drawing.Size(97, 708);
			this.btnOpenServer.TabIndex = 1;
			this.btnOpenServer.Text = "С\r\nЕ\r\nР\r\nВ\r\nЕ\r\nР";
			this.btnOpenServer.UseVisualStyleBackColor = true;
			this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
			// 
			// tbUrl
			// 
			this.tbUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbUrl.ForeColor = System.Drawing.Color.Gray;
			this.tbUrl.Location = new System.Drawing.Point(137, 89);
			this.tbUrl.Margin = new System.Windows.Forms.Padding(2);
			this.tbUrl.Name = "tbUrl";
			this.tbUrl.Size = new System.Drawing.Size(826, 39);
			this.tbUrl.TabIndex = 2;
			this.tbUrl.Text = "Введите URL-адрес...";
			this.tbUrl.Enter += new System.EventHandler(this.tbUrl_Enter);
			this.tbUrl.Leave += new System.EventHandler(this.tbUrl_Leave);
			// 
			// tbApiKey
			// 
			this.tbApiKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbApiKey.ForeColor = System.Drawing.Color.Gray;
			this.tbApiKey.Location = new System.Drawing.Point(137, 171);
			this.tbApiKey.Margin = new System.Windows.Forms.Padding(2);
			this.tbApiKey.Name = "tbApiKey";
			this.tbApiKey.Size = new System.Drawing.Size(826, 39);
			this.tbApiKey.TabIndex = 3;
			this.tbApiKey.Text = "Введите API-ключ...";
			this.tbApiKey.Enter += new System.EventHandler(this.tbApiKey_Enter);
			this.tbApiKey.Leave += new System.EventHandler(this.tbApiKey_Leave);
			// 
			// btnSend
			// 
			this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnSend.Location = new System.Drawing.Point(137, 250);
			this.btnSend.Margin = new System.Windows.Forms.Padding(2);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(402, 60);
			this.btnSend.TabIndex = 4;
			this.btnSend.Text = "Отправить";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// btnCheck
			// 
			this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnCheck.Location = new System.Drawing.Point(560, 250);
			this.btnCheck.Margin = new System.Windows.Forms.Padding(2);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new System.Drawing.Size(402, 60);
			this.btnCheck.TabIndex = 5;
			this.btnCheck.Text = "Проверка сети";
			this.btnCheck.UseVisualStyleBackColor = true;
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			// 
			// tbLog
			// 
			this.tbLog.BackColor = System.Drawing.Color.Black;
			this.tbLog.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.tbLog.Location = new System.Drawing.Point(137, 349);
			this.tbLog.Margin = new System.Windows.Forms.Padding(2);
			this.tbLog.Multiline = true;
			this.tbLog.Name = "tbLog";
			this.tbLog.ReadOnly = true;
			this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbLog.Size = new System.Drawing.Size(826, 414);
			this.tbLog.TabIndex = 6;
			// 
			// tsPanel
			// 
			this.tsPanel.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.tsPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_btnUpdate,
            this.ts_tbSearch,
            this.ts_btnSearch,
            this.ts_DDBtnSettings,
            this.ts_DDBtnNotifications});
			this.tsPanel.Location = new System.Drawing.Point(0, 0);
			this.tsPanel.Name = "tsPanel";
			this.tsPanel.Size = new System.Drawing.Size(1106, 38);
			this.tsPanel.TabIndex = 7;
			this.tsPanel.Text = "toolStrip1";
			// 
			// ts_btnUpdate
			// 
			this.ts_btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("ts_btnUpdate.Image")));
			this.ts_btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btnUpdate.Name = "ts_btnUpdate";
			this.ts_btnUpdate.Size = new System.Drawing.Size(97, 33);
			this.ts_btnUpdate.Text = "Обновить";
			this.ts_btnUpdate.ToolTipText = "Обновить";
			this.ts_btnUpdate.Click += new System.EventHandler(this.ts_btnUpdate_Click);
			// 
			// ts_tbSearch
			// 
			this.ts_tbSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.ts_tbSearch.Name = "ts_tbSearch";
			this.ts_tbSearch.Size = new System.Drawing.Size(76, 34);
			this.ts_tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ts_tbSearch_KeyDown);
			this.ts_tbSearch.TextChanged += new System.EventHandler(this.ts_tbSearch_TextChanged);
			// 
			// ts_btnSearch
			// 
			this.ts_btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("ts_btnSearch.Image")));
			this.ts_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_btnSearch.Name = "ts_btnSearch";
			this.ts_btnSearch.Size = new System.Drawing.Size(67, 29);
			this.ts_btnSearch.Text = "Поиск";
			this.ts_btnSearch.Click += new System.EventHandler(this.ts_btnSearch_Click);
			// 
			// ts_DDBtnSettings
			// 
			this.ts_DDBtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_DDBtnSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.профильToolStripMenuItem,
            this.темаToolStripMenuItem});
			this.ts_DDBtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("ts_DDBtnSettings.Image")));
			this.ts_DDBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_DDBtnSettings.Name = "ts_DDBtnSettings";
			this.ts_DDBtnSettings.Size = new System.Drawing.Size(118, 29);
			this.ts_DDBtnSettings.Text = "Настройки";
			// 
			// профильToolStripMenuItem
			// 
			this.профильToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuChangeEmail,
            this.tsMenuLogout});
			this.профильToolStripMenuItem.Name = "профильToolStripMenuItem";
			this.профильToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
			this.профильToolStripMenuItem.Text = "Профиль";
			// 
			// tsMenuChangeEmail
			// 
			this.tsMenuChangeEmail.Name = "tsMenuChangeEmail";
			this.tsMenuChangeEmail.Size = new System.Drawing.Size(270, 34);
			this.tsMenuChangeEmail.Text = "Сменить почту";
			this.tsMenuChangeEmail.Click += new System.EventHandler(this.tsMenuChangeEmail_Click);
			// 
			// tsMenuLogout
			// 
			this.tsMenuLogout.Name = "tsMenuLogout";
			this.tsMenuLogout.Size = new System.Drawing.Size(270, 34);
			this.tsMenuLogout.Text = "Выйти из аккаунта";
			this.tsMenuLogout.Click += new System.EventHandler(this.tsMenuLogout_Click);
			// 
			// темаToolStripMenuItem
			// 
			this.темаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuLightTheme,
            this.tsMenuDarkTheme});
			this.темаToolStripMenuItem.Name = "темаToolStripMenuItem";
			this.темаToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
			this.темаToolStripMenuItem.Text = "Тема";
			// 
			// tsMenuLightTheme
			// 
			this.tsMenuLightTheme.Name = "tsMenuLightTheme";
			this.tsMenuLightTheme.Size = new System.Drawing.Size(270, 34);
			this.tsMenuLightTheme.Text = "Светлая";
			this.tsMenuLightTheme.Click += new System.EventHandler(this.tsMenuLightTheme_Click);
			// 
			// tsMenuDarkTheme
			// 
			this.tsMenuDarkTheme.Name = "tsMenuDarkTheme";
			this.tsMenuDarkTheme.Size = new System.Drawing.Size(270, 34);
			this.tsMenuDarkTheme.Text = "Темная";
			this.tsMenuDarkTheme.Click += new System.EventHandler(this.tsMenuDarkTheme_Click);
			// 
			// ts_DDBtnNotifications
			// 
			this.ts_DDBtnNotifications.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ts_DDBtnNotifications.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_DDBtnNotifications.Name = "ts_DDBtnNotifications";
			this.ts_DDBtnNotifications.Size = new System.Drawing.Size(140, 29);
			this.ts_DDBtnNotifications.Text = "Уведомления";
			this.ts_DDBtnNotifications.DropDownOpened += new System.EventHandler(this.ts_DDBtnNotifications_DropDownOpened);
			// 
			// lbSuggestions
			// 
			this.lbSuggestions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbSuggestions.FormattingEnabled = true;
			this.lbSuggestions.ItemHeight = 20;
			this.lbSuggestions.Location = new System.Drawing.Point(111, 37);
			this.lbSuggestions.Name = "lbSuggestions";
			this.lbSuggestions.Size = new System.Drawing.Size(884, 142);
			this.lbSuggestions.TabIndex = 8;
			this.lbSuggestions.Visible = false;
			this.lbSuggestions.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbSuggestions_DrawItem);
			// 
			// StorageServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1106, 823);
			this.Controls.Add(this.lbSuggestions);
			this.Controls.Add(this.tsPanel);
			this.Controls.Add(this.tbLog);
			this.Controls.Add(this.btnCheck);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.tbApiKey);
			this.Controls.Add(this.tbUrl);
			this.Controls.Add(this.btnOpenServer);
			this.Controls.Add(this.btnOpenPC);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "StorageServerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Хранилище данных";
			this.Load += new System.EventHandler(this.StorageServerForm_Load);
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
		private System.Windows.Forms.ToolStripTextBox ts_tbSearch;
		private System.Windows.Forms.ToolStripButton ts_btnSearch;
		private System.Windows.Forms.ListBox lbSuggestions;
		private System.Windows.Forms.ToolStripDropDownButton ts_DDBtnSettings;
		private System.Windows.Forms.ToolStripMenuItem профильToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem темаToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton ts_DDBtnNotifications;
		private System.Windows.Forms.ToolStripMenuItem tsMenuChangeEmail;
		private System.Windows.Forms.ToolStripMenuItem tsMenuLogout;
		private System.Windows.Forms.ToolStripMenuItem tsMenuLightTheme;
		private System.Windows.Forms.ToolStripMenuItem tsMenuDarkTheme;
	}
}

