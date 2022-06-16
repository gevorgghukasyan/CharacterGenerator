using CharacterGenerator.Entities;
using CharacterGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace CharacterGenerator.DAL
{
	public static class DataAccess
	{
		public static IEnumerable<string> GetDirectories(
			string path,
			string searchPattern = "*",
			SearchOption searchOption = SearchOption.AllDirectories)
		{
			if (searchOption == SearchOption.TopDirectoryOnly)
			{
				return Directory.GetDirectories(path, searchPattern);
			}

			var directories = new List<string>(GetDirectories(path, searchPattern));

			for (var i = 0; i < directories.Count; i++)
			{
				directories.AddRange(GetDirectories(directories[i], searchPattern));
			}
			return directories;
		}

		private static IEnumerable<string> GetDirectories(string path, string searchPattern)
		{
			try
			{
				return Directory.GetDirectories(path, searchPattern);
			}
			catch (UnauthorizedAccessException)
			{
				return Enumerable.Empty<string>();
			}
		}

		public static IEnumerable<IEnumerable<string>> GetFiles(this IEnumerable<string> path)
		{
			return path.Select(p => Directory.GetFiles(p));
		}

		public static ImageMetadata ToImageMetadata(this string filePath)
		{
			try
			{
				var fWE = Path.GetFileNameWithoutExtension(filePath);
				var fN = Path.GetFileName(Path.GetDirectoryName(filePath));
				string tag = null;
				var parts = fN.Split('_');
				if (parts.Length == 2)
				{
					tag = parts[1];
				}
				//var image = Image.FromFile(filePath).ResizeImage(new Size(500, 500));

				//using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				//{
				//	using (Image image = Image.FromStream(fs))
				//	{
				//	}
				//}
				//var s = image.Height;
				return new ImageMetadata(filePath, fWE, fN, tag);

			}
			catch(Exception ex)
			{
				throw;
			}
		}

		public static Dictionary<string, string> GetExcelFile(this string filePath)
		{
			if (!filePath.IsValidPath())
			{
				throw new ArgumentException("Path is not valid", nameof(filePath));
			}

			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
			Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
			Excel.Range xlRange = xlWorksheet.UsedRange;

			int rowCount = xlRange.Rows.Count;

			var dictionary = new Dictionary<string, string>();

			for (int i = 1; i <= rowCount; i++)
			{
				var col1 = xlRange.Cells[i, 1]?.Value2?.ToString();
				var col2 = xlRange.Cells[i, 2]?.Value2?.ToString();

				if (col1 != null && col2 != null)
				{
					dictionary.Add(col1, col2);
				}
			}

			GC.Collect();
			GC.WaitForPendingFinalizers();

			Marshal.ReleaseComObject(xlRange);
			Marshal.ReleaseComObject(xlWorksheet);

			xlWorkbook.Close();
			Marshal.ReleaseComObject(xlWorkbook);

			xlApp.Quit();

			Marshal.ReleaseComObject(xlApp);

			return dictionary;
		}
	}
}
