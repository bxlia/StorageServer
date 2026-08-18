using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageServer
{
	public partial class AuthForm : Form
	{
		// Публичные свойства, чтобы MainForm могла забрать данные после успешного входа/регистрации
		public string AuthorizedEmail { get; private set; } = string.Empty;
		public string ServerAddress { get; private set; } = string.Empty;
		public string ServerKey { get; private set; } = string.Empty;

		public AuthForm()
		{
			InitializeComponent();
			SetupFormLayout();
			ThemeManager.ApplyTheme(this);
		}

		private void SetupFormLayout()
		{
			this.Text = "StorageServer — Регистрация и Вход";
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.StartPosition = FormStartPosition.CenterScreen;
			tbPassword.UseSystemPasswordChar = true;
		}

		// КНОПКА: ВОЙТИ (btnEntrance)
		private async void btnEntrance_Click(object sender, EventArgs e)
		{
			string email = tbEmail.Text.Trim().ToLower();
			string password = tbPassword.Text;

			if (!ValidateInputs(email, password)) return;

			ToggleUIState(false);
			bool isLoginSuccess = await AuthenticateUserAsync(email, password);
			ToggleUIState(true);

			if (isLoginSuccess)
			{
				CompleteAuth(email);
			}
			else
			{
				MessageBox.Show("Неверный Email или пароль.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// КНОПКА: РЕГИСТРАЦИЯ (btnRegistration)
		private async void btnRegistration_Click(object sender, EventArgs e)
		{
			string email = tbEmail.Text.Trim().ToLower();
			string password = tbPassword.Text;

			if (!ValidateInputs(email, password)) return;

			ToggleUIState(false);
			bool isRegisterSuccess = await RegisterUserAsync(email, password);
			ToggleUIState(true);

			if (isRegisterSuccess)
			{
				// Если у вас на форме регистрации есть необязательные поля для адреса и ключа сервера,
				// считываем их (например, tbRegAddress и tbRegKey). Если их нет, оставляем пустыми:
				// ServerAddress = tbRegAddress.Text.Trim();
				// ServerKey = tbRegKey.Text.Trim();

				CompleteAuth(email);
			}
			else
			{
				MessageBox.Show("Ошибка при регистрации аккаунта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CompleteAuth(string email)
		{
			// Фиксируем глобальную сессию
			Properties.Settings.Default.UserToken = "secure_user_token_jwt";
			Properties.Settings.Default.LastLoggedUser = email;
			Properties.Settings.Default.Save();

			// Заполняем свойства для передачи в MainForm
			AuthorizedEmail = email;

			// Указываем, что авторизация прошла успешно, и закрываем форму
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private bool ValidateInputs(string email, string password)
		{
			if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
			{
				MessageBox.Show("Укажите корректный Email адрес.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbEmail.Focus();
				return false;
			}
			if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
			{
				MessageBox.Show("Пароль должен содержать не менее 8 символов.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbPassword.Focus();
				return false;
			}
			return true;
		}

		private void ToggleUIState(bool enabled)
		{
			tbEmail.Enabled = enabled;
			tbPassword.Enabled = enabled;
			btnEntrance.Enabled = enabled;
			btnRegistration.Enabled = enabled;
		}

		private async Task<bool> AuthenticateUserAsync(string email, string password) => await Task.Delay(500).ContinueWith(_ => true);
		private async Task<bool> RegisterUserAsync(string email, string password) => await Task.Delay(500).ContinueWith(_ => true);   
	}
}
