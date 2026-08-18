namespace StorageServer
{
	partial class AuthForm
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
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.btnEntrance = new System.Windows.Forms.Button();
			this.btnRegistration = new System.Windows.Forms.Button();
			this.lbEntrance = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tbEmail
			// 
			this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbEmail.Location = new System.Drawing.Point(12, 128);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(776, 30);
			this.tbEmail.TabIndex = 0;
			this.tbEmail.Text = "Введите Email...";
			// 
			// tbPassword
			// 
			this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbPassword.Location = new System.Drawing.Point(12, 218);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(776, 30);
			this.tbPassword.TabIndex = 1;
			this.tbPassword.Text = "Введите пароль...";
			// 
			// btnEntrance
			// 
			this.btnEntrance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnEntrance.Location = new System.Drawing.Point(276, 286);
			this.btnEntrance.Name = "btnEntrance";
			this.btnEntrance.Size = new System.Drawing.Size(275, 64);
			this.btnEntrance.TabIndex = 2;
			this.btnEntrance.Text = "Вход";
			this.btnEntrance.UseVisualStyleBackColor = true;
			this.btnEntrance.Click += new System.EventHandler(this.btnEntrance_Click);
			// 
			// btnRegistration
			// 
			this.btnRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnRegistration.Location = new System.Drawing.Point(328, 356);
			this.btnRegistration.Name = "btnRegistration";
			this.btnRegistration.Size = new System.Drawing.Size(174, 64);
			this.btnRegistration.TabIndex = 3;
			this.btnRegistration.Text = "Регистрация";
			this.btnRegistration.UseVisualStyleBackColor = true;
			this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
			// 
			// lbEntrance
			// 
			this.lbEntrance.AutoSize = true;
			this.lbEntrance.Font = new System.Drawing.Font("Impact", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbEntrance.Location = new System.Drawing.Point(268, 43);
			this.lbEntrance.Name = "lbEntrance";
			this.lbEntrance.Size = new System.Drawing.Size(283, 48);
			this.lbEntrance.TabIndex = 4;
			this.lbEntrance.Text = "Вход в систему";
			// 
			// AuthForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lbEntrance);
			this.Controls.Add(this.btnRegistration);
			this.Controls.Add(this.btnEntrance);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbEmail);
			this.Name = "AuthForm";
			this.Text = "AuthForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Button btnEntrance;
		private System.Windows.Forms.Button btnRegistration;
		private System.Windows.Forms.Label lbEntrance;
	}
}