using CharacterGenerator.Collections;
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
		private const float X = 100;
		public static Dictionary<string, float> Percents = new Dictionary<string, float>()
	{
					{"Eye_1",  float.Parse("0.054") * X},
					{"Eye_2",   float.Parse("0.434444444")*X},
					{"Eye_3",   float.Parse("0.162888889")*X},
					{"Eye_4",   float.Parse("0.271555556")*X },
					{"Eye_5",   float.Parse("0.037555556")*X },
					{"Eye_6",   float.Parse("0.109111111")*X  },
					{"Eye_7",   float.Parse("0.009777778")*X },
					{"Eye_8",   float.Parse("0.009777778")*X},
					{"Superrare_1", float.Parse("0.003777778")*X},
					{"Superrare_2", float.Parse("0.003777778")*X},
					{"Superrare_3", float.Parse("0.003777778")*X},
					{"Hat_9",   float.Parse("0.024444444" )*X }  ,
					{"Hat_10",  float.Parse("0.024444444" )*X}  ,
					{"Hat_11",  float.Parse("0.024444444" )*X}  ,
					{"Hat_12",  float.Parse("0.006222222")*X}  ,
					{"Hat_13",  float.Parse("0.024444444" )*X}  ,
					{"Hat_14",  float.Parse("0.012222222" )*X}  ,
					{"Hat_15",  float.Parse("0.012222222" )*X}  ,
					{"Hat_16",  float.Parse("0.006222222")*X}  ,
					{"Hat_17",  float.Parse("0.024444444" )*X}  ,
					{"Hat_18",  float.Parse("0.006222222")*X}  ,
					{"Hat_19",  float.Parse("0.006222222")*X}  ,
					{"Hat_20",  float.Parse("0.004888889")*X}  ,
					{"Hat_21",  float.Parse("0.012222222" )*X}  ,
					{"Hat_22",  float.Parse("0.003777778")*X}  ,
					{"Hat_23",  float.Parse("0.003777778")*X } ,
					{"Amulet_24",   float.Parse("0.029333333")*X} ,
					{"Amulet_25",   float.Parse("0.029333333")*X} ,
					{"Amulet_26",   float.Parse("0.029333333")*X} ,
					{"Amulet_27",   float.Parse("0.029333333")*X} ,
					{"Amulet_28",   float.Parse("0.029333333")*X} ,
					{"Amulet_29",   float.Parse("0.012222222")*X} ,
					{"Amulet_30",   float.Parse("0.029333333")*X} ,
					{"Amulet_31",   float.Parse("0.029333333")*X} ,
					{"Amulet_32",   float.Parse("0.029333333")*X} ,
					{"Amulet_33",   float.Parse("0.029333333")*X} ,
					{"Amulet_34",   float.Parse("0.029333333")*X} ,
					{"Amulet_35",   float.Parse("0.029333333")*X} ,
					{"Amulet_36",   float.Parse("0.029333333")*X} ,
					{"Amulet_37",   float.Parse("0.029333333")*X} ,
					{"Amulet_38",   float.Parse("0.029333333")*X} ,
					{"Amulet_39",   float.Parse("0.029333333")*X} ,
					{"Amulet_40",   float.Parse("0.029333333")*X} ,
					{"Amulet_41",   float.Parse("0.029333333")*X} ,
					{"Amulet_42",   float.Parse("0.014666667")*X} ,
					{"Amulet_43",   float.Parse("0.012222222")*X} ,
					{"Piercing_44", float.Parse("0.055111111")*X} ,
					{"Piercing_45", float.Parse("0.055111111")*X} ,
					{"Piercing_46", float.Parse("0.055111111")*X} ,
					{"Piercing_47", float.Parse("0.067333333")*X} ,
					{"Piercing_48", float.Parse("0.055111111")*X} ,
					{"Piercing_49", float.Parse("0.055111111")*X} ,
					{"Piercing_50", float.Parse("0.055111111")*X} ,
					{"Piercing_51", float.Parse("0.030666667")*X} ,
					{"Piercing_52", float.Parse("0.055111111")*X} ,
					{"Piercing_53", float.Parse("0.055111111")*X} ,
					{"Mouth_54",    float.Parse("0.030666667")*X} ,
					{"Mouth_55",    float.Parse("0.024444444")*X} ,
					{"Mouth_56",    float.Parse("0.024444444")*X} ,
					{"Mouth_57",    float.Parse("0.030666667")*X} ,
					{"mouth_58",    float.Parse("0.025777778")*X} ,
					{"Mouth_59",    float.Parse("0.025777778")*X} ,
					{"Mouth_60",    float.Parse("0.020888889")*X} ,
					{"mouth_61",    float.Parse("0.020888889")*X },
					{"bg_gray", float.Parse("0.766666667")*X} ,
					{"bg_blue", float.Parse("0.322222222")*X },
					{"65",  float.Parse("0.040444444")*X },
					{"66",  float.Parse("0.023333333")*X },
					{"67",  float.Parse("0.011111111")*X }  ,
					{"67x", float.Parse("0.039111111")*X},
					{"68",  float.Parse("0.022")*X },
					{"69",   float.Parse("0.009777778")*X  },
					{ "70",  float.Parse("0.036666667")*X      },
					{ "71",  float.Parse("0.019555556")*X      },
					{ "72",  float.Parse("0.007333333" )*X },
					{ "73",  float.Parse("0.035555556"  )*X},
					{ "74",  float.Parse("0.018444444"  )*X} ,
					{ "75",  float.Parse("0.006222222" )*X } ,
					{ "Weapon_76",   float.Parse("0.046444444")*X},
					{ "Weapon_77",   float.Parse("0.039111111")*X},
					{ "Weapon_78",   float.Parse("0.034222222")*X},
					{ "Weapon_79",   float.Parse("0.029333333")*X},
					{ "Weapon_80",   float.Parse("0.019555556")*X},
					{ "Weapon_81",   float.Parse("0.014666667")*X} ,
					{ "82",  float.Parse("0.040444444" ) *X},
					{ "83",  float.Parse("0.023333333" ) *X},
					{ "84",  float.Parse("0.011111111" ) *X},
					{ "85",  float.Parse("0.039111111")*X},
					{ "86",  float.Parse("0.022") *X },
					{ "87",  float.Parse("0.009777778")  *X},
					{ "88",  float.Parse("0.036666667" ) *X},
					{ "89",  float.Parse("0.019555556" ) *X},
					{ "90",  float.Parse("0.007333333")  *X},
					{ "91",  float.Parse("0.035555556" ) *X},
					{ "92",  float.Parse("0.018444444" ) *X},
					{ "93",  float.Parse("0.006222222")*X},
					{ "Weapon_94",   float.Parse("0.046444444")*X},
					{ "Weapon_95",   float.Parse("0.039111111")*X} ,
					{ "Weapon_96",   float.Parse("0.034222222")*X} ,
					{ "Weapon_97",   float.Parse("0.029333333")*X} ,
					{ "Weapon_98",   float.Parse("0.019555556")*X} ,
					{ "Weapon_99",   float.Parse("0.014666667")*X} ,
					{"100", float.Parse("0.040444444" )*X},
					{ "101", float.Parse("0.023333333" ) *X  },
					{ "102", float.Parse("0.011111111")    *X   },
					{ "103", float.Parse("0.039111111")   *X },
					{ "104", float.Parse("0.022")     *X  },
					{ "105", float.Parse("0.009777778")*X},
					{ "106", float.Parse("0.036666667"   )*X },
					{ "107", float.Parse("0.019555556"   ) *X} ,
					{ "108", float.Parse("0.007333333")*X},
					{ "109", float.Parse("0.035555556"   )*X },
					{ "110", float.Parse("0.018444444"   ) *X},
					{ "111", float.Parse("0.006222222")*X},
					{ "Weapon_112",  float.Parse("0.046444444")*X},
					{ "Weapon_113",  float.Parse("0.039111111")*X} ,
					{ "Weapon_114",  float.Parse("0.034222222")*X} ,
					{ "Weapon_115",  float.Parse("0.029333333")*X} ,
					{ "Weapon_116",  float.Parse("0.019555556")*X} ,
					{ "Weapon_117",  float.Parse("0.014666667")*X}
};

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
			var ss = path.Select(p => Directory.GetFiles(p));
			return ss;
		}

		public static ImageMetadata ToImageMetadata(this string filePath, string type)
		{
			try
			{
				var fWE = Path.GetFileNameWithoutExtension(filePath);
				var lastFolderName = new DirectoryInfo(filePath).Parent.Name;
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
				return new ImageMetadata(filePath, fWE, fWE, tag, GetPercents(fWE), lastFolderName);

			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private static float GetPercents(string key)
		{
			if (key == "dark magician 2" || key == "druid 2" || key == "warrior 2" || key == "druid 2 ")
			{
				return 0;
			}
			if (key != "bg_gray" && key != "bg_blue")
			{
				key = key.FirstCharToUpper();
			}
			if (key == "Mouth_58" || key == "Mouth_61")
			{
				key = key.FirstCharToLower();
			}

			return Percents[key];
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
