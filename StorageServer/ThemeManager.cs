using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageServer
{
	internal class ThemeManager
	{
		public static string CurrentTheme { get; private set; } = "Light";

		// Палитра цветов для окон и элементов управления
		public static Color BackgroundColor { get; private set; }
		public static Color ForegroundColor { get; private set; }
		public static Color InputBackColor { get; private set; }
		public static Color AccentColor { get; private set; }
		public static Color ToolStripColor { get; private set; }

		// Палитра для визуального разделения ПК и Сервера в результатах
		public static Color LocalFileColor { get; private set; }
		public static Color RemoteFileColor { get; private set; }

		static ThemeManager()
		{
			LoadTheme();
		}

		public static void LoadTheme()
		{
			// Безопасно читаем тему из настроек
			try { CurrentTheme = Properties.Settings.Default.AppTheme; }
			catch { CurrentTheme = "Light"; }

			if (string.IsNullOrEmpty(CurrentTheme)) CurrentTheme = "Light";

			if (CurrentTheme == "Dark")
			{
				BackgroundColor = Color.FromArgb(28, 28, 28);     // Глубокий темно-серый
				ForegroundColor = Color.FromArgb(240, 240, 240); // Мягкий белый
				InputBackColor = Color.FromArgb(45, 45, 48);      // Текстбоксы чуть светлее фона
				AccentColor = Color.FromArgb(0, 122, 204);       // Синий VS Accent
				ToolStripColor = Color.FromArgb(37, 37, 38);     // Панель инструментов

				// Мягкие цвета для логов файлов в темной теме
				LocalFileColor = Color.FromArgb(100, 220, 100);  // Салатовый для ПК
				RemoteFileColor = Color.FromArgb(100, 180, 255); // Голубой для Сервера
			}
			else // Light
			{
				BackgroundColor = Color.FromArgb(245, 245, 245); // Приятный светло-серый
				ForegroundColor = Color.FromArgb(30, 30, 30);     // Темно-серый текст
				InputBackColor = Color.White;                    // Белые текстбоксы
				AccentColor = Color.FromArgb(0, 90, 158);        // Синий Microsoft
				ToolStripColor = Color.FromArgb(230, 230, 230);   // Панель инструментов

				// Насыщенные цвета для логов файлов в светлой теме
				LocalFileColor = Color.DarkGreen;
				RemoteFileColor = Color.DarkBlue;
			}
		}

		// Переключение темы с мгновенным сохранением
		public static void SwitchTheme(string themeName)
		{
			Properties.Settings.Default.AppTheme = themeName;
			Properties.Settings.Default.Save();
			LoadTheme();

			// Автоматически перекрашиваем все открытые формы в приложении!
			foreach (Form openForm in Application.OpenForms)
			{
				ApplyTheme(openForm);
			}
		}

		// Метод покраски любой переданной формы
		public static void ApplyTheme(Form form)
		{
			form.BackColor = BackgroundColor;
			form.ForeColor = ForegroundColor;

			foreach (Control control in form.Controls)
			{
				ApplyControlTheme(control);
			}
		}

		private static void ApplyControlTheme(Control control)
		{
			// Задаем цвет текста по умолчанию для текущего элемента
			control.ForeColor = ForegroundColor;

			// ПРОВЕРКА ТИПА: Находит ЛЮБОЙ TreeView с ЛЮБЫМ названием
			if (control is System.Windows.Forms.TreeView tv)
			{
				tv.BackColor = InputBackColor;
				tv.ForeColor = ForegroundColor;
				tv.BorderStyle = BorderStyle.FixedSingle;
			}
			else if (control is System.Windows.Forms.TextBox txt)
			{
				txt.BackColor = InputBackColor;
				txt.BorderStyle = BorderStyle.FixedSingle;
				txt.ForeColor = ForegroundColor;
			}
			else if (control is System.Windows.Forms.Button btn)
			{
				if (btn.Name.Contains("Connect") || btn.Name.Contains("Entrance") || btn.Name.Contains("Registration") || btn.Name.Contains("Search"))
				{
					btn.BackColor = AccentColor;
					btn.ForeColor = Color.White;
				}
				else
				{
					btn.BackColor = InputBackColor;
					btn.ForeColor = ForegroundColor;
				}
				btn.FlatStyle = FlatStyle.Flat;
				btn.FlatAppearance.BorderSize = 1;
				btn.FlatAppearance.BorderColor = AccentColor;
			}
			else if (control is ToolStrip ts)
			{
				ts.BackColor = ToolStripColor;
				ts.ForeColor = ForegroundColor;
				ts.RenderMode = ToolStripRenderMode.System;
			}
			else if (control is GroupBox grp)
			{
				grp.BackColor = BackgroundColor;
				grp.ForeColor = AccentColor;
			}

			// РЕКУРСИЯ: Обязательно спускаемся внутрь контейнеров (панелей/вкладок),
			// чтобы найти TreeView, даже если они спрятаны внутри SplitContainer или Panel
			foreach (Control child in control.Controls)
			{
				ApplyControlTheme(child);
			}
		}

		private static void UpdateNodeTheme(TreeNode node)
		{
			// Текст папок и файлов всегда должен соответствовать цвету темы
			node.ForeColor = ThemeManager.ForegroundColor;
			node.BackColor = ThemeManager.InputBackColor;

			foreach (TreeNode child in node.Nodes)
			{
				UpdateNodeTheme(child);
			}
		}

	}
}
