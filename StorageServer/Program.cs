using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageServer
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public static string SelectedLocalFilePath = " ";
		public static string SelectedRemoteFolderPath = "/home/zizik";

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new StorageServerForm());
		}
	}
}
