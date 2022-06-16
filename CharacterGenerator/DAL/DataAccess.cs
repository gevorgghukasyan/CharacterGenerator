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
		public static Dictionary<string, float> Percents = new Dictionary<string, float>()
		{
						{"Eye_1",  float.Parse("4.911111")},
						{"Eye_2",   float.Parse("39.48889")},
						{"Eye_3",   float.Parse("14.8")},
						{"Eye_4",   float.Parse("24.68889") },
						{"Eye_5",   float.Parse("3.422222") },
						{"Eye_6",   float.Parse("9.866667")  },
						{"Eye_7",   float.Parse("0.7777778") },
						{"Eye_8",   float.Parse("0.7777778")},
						{"Superrare_1", float.Parse("0.3111111")},
						{"Superrare_2", float.Parse("0.3333333")},
						{"Superrare_3", float.Parse("0.3333333")},
						{"Hat_9",   float.Parse("2.222222" ) }  ,
						{"Hat_10",  float.Parse("2.222222" )}  ,
						{"Hat_11",  float.Parse("2.222222" )}  ,
						{"Hat_12",  float.Parse("0.5555556")}  ,
						{"Hat_13",  float.Parse("2.222222" )}  ,
						{"Hat_14",  float.Parse("1.111111" )}  ,
						{"Hat_15",  float.Parse("1.111111" )}  ,
						{"Hat_16",  float.Parse("0.5555556")}  ,
						{"Hat_17",  float.Parse("2.222222" )}  ,
						{"Hat_18",  float.Parse("0.5555556")}  ,
						{"Hat_19",  float.Parse("0.5555556")}  ,
						{"Hat_20",  float.Parse("0.4444444")}  ,
						{"Hat_21",  float.Parse("1.111111" )}  ,
						{"Hat_22",  float.Parse("0.3333333")}  ,
						{"Hat_23",  float.Parse("0.3333333") } ,
						{"Amulet_24",   float.Parse("2.666667")} ,
						{"Amulet_25",   float.Parse("2.666667")} ,
						{"Amulet_26",   float.Parse("2.666667")} ,
						{"Amulet_27",   float.Parse("2.666667")} ,
						{"Amulet_28",   float.Parse("2.666667")} ,
						{"Amulet_29",   float.Parse("1.111111")} ,
						{"Amulet_30",   float.Parse("2.666667")} ,
						{"Amulet_31",   float.Parse("2.666667")} ,
						{"Amulet_32",   float.Parse("2.666667")} ,
						{"Amulet_33",   float.Parse("2.666667")} ,
						{"Amulet_34",   float.Parse("2.666667")} ,
						{"Amulet_35",   float.Parse("2.666667")} ,
						{"Amulet_36",   float.Parse("2.666667")} ,
						{"Amulet_37",   float.Parse("2.666667")} ,
						{"Amulet_38",   float.Parse("2.666667")} ,
						{"Amulet_39",   float.Parse("2.666667")} ,
						{"Amulet_40",   float.Parse("2.666667")} ,
						{"Amulet_41",   float.Parse("2.666667")} ,
						{"Amulet_42",   float.Parse("1.333333")} ,
						{"Amulet_43",   float.Parse("1.111111")} ,
						{"Piercing_44", float.Parse("5")} ,
						{"Piercing_45", float.Parse("5")} ,
						{"Piercing_46", float.Parse("5")} ,
						{"Piercing_47", float.Parse("6.111111")} ,
						{"Piercing_48", float.Parse("5")} ,
						{"Piercing_49", float.Parse("5")} ,
						{"Piercing_50", float.Parse("5")} ,
						{"Piercing_51", float.Parse("2.777778")} ,
						{"Piercing_52", float.Parse("5")} ,
						{"Piercing_53", float.Parse("5")} ,
						{"Mouth_54",    float.Parse("2.777778")} ,
						{"Mouth_55",    float.Parse("2.222222")} ,
						{"Mouth_56",    float.Parse("2.222222")} ,
						{"Mouth_57",    float.Parse("2.777778")} ,
						{"mouth_58",    float.Parse("2.222222")} ,
						{"Mouth_59",    float.Parse("2.222222")} ,
						{"Mouth_60",    float.Parse("1.666667")} ,
						{"mouth_61",    float.Parse("1.666667") },
						{"bg_gray", float.Parse("70")} ,
						{"bg_blue", float.Parse("30") },
						{"65",  float.Parse("3.666667") },
						{"66",  float.Parse("2.111111") },
						{"67",  float.Parse("1") }  ,
						{"67x", float.Parse("3.555556")},
						{"68",  float.Parse("2") },
						{"69",   float.Parse("0.8888889")  },
						{ "70",  float.Parse("3.333333")      },
						{ "71",  float.Parse("1.777778")      },
						{ "72",  float.Parse("0.6666667" ) },
						{ "73",  float.Parse("3.222222"  )},
						{ "74",  float.Parse("1.666667"  )} ,
						{ "75",  float.Parse("0.5555556" ) } ,
						{ "Weapon_76",   float.Parse("4.222222")},
						{ "Weapon_77",   float.Parse("3.555556")},
						{ "Weapon_78",   float.Parse("3.111111")},
						{ "Weapon_79",   float.Parse("2.666667")},
						{ "Weapon_80",   float.Parse("1.777778")},
						{ "Weapon_81",   float.Parse("1.333333")} ,
						{ "82",  float.Parse("3.666667" ) },
						{ "83",  float.Parse("2.111111" ) },
						{ "84",  float.Parse("1" ) },
						{ "85",  float.Parse("3.555556")},
						{ "86",  float.Parse("2")  },
						{ "87",  float.Parse("0.8888889")  },
						{ "88",  float.Parse("3.333333" ) },
						{ "89",  float.Parse("1.777778" ) },
						{ "90",  float.Parse("0.6666667")  },
						{ "91",  float.Parse("3.222222" ) },
						{ "92",  float.Parse("1.666667" ) },
						{ "93",  float.Parse("0.5555556")},
						{ "Weapon_94",   float.Parse("4.222222")},
						{ "Weapon_95",   float.Parse("3.555556")} ,
						{ "Weapon_96",   float.Parse("3.111111")} ,
						{ "Weapon_97",   float.Parse("2.666667")} ,
						{ "Weapon_98",   float.Parse("1.777778")} ,
						{ "Weapon_99",   float.Parse("1.333333")} ,
						{"100", float.Parse("3.666667" )},
						{ "101", float.Parse("2.111111" )   },
						{ "102", float.Parse("1")       },
						{ "103", float.Parse("3.555556")    },
						{ "104", float.Parse("2")       },
						{ "105", float.Parse("0.8888889")},
						{ "106", float.Parse("3.333333"   ) },
						{ "107", float.Parse("1.777778"   ) } ,
						{ "108", float.Parse("0.6666667")},
						{ "109", float.Parse("3.222222"   ) },
						{ "110", float.Parse("1.666667"   ) },
						{ "111", float.Parse("0.5555556")},
						{ "Weapon_112",  float.Parse("4.222222")},
						{ "Weapon_113",  float.Parse("3.555556")} ,
						{ "Weapon_114",  float.Parse("3.111111")} ,
						{ "Weapon_115",  float.Parse("2.666667")} ,
						{ "Weapon_116",  float.Parse("1.777778")} ,
						{ "Weapon_117",  float.Parse("1.333333")}
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
