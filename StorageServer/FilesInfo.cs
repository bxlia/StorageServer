// Класс, хранящий информацию файлов
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServer
{
	internal class FilesInfo
	{
		public string Name { get; set; }
		public string Path { get; set; }
		public string Source { get; set; }
		public FilesInfo(string name, string path, string source)
		{
			Name = name;
			Path = path;
			Source = source;
		}
		public string GetSearchSuggestion()
		{
			return $"[{Source}] {Name}  --->  ({Path})";
		}
	}
}
