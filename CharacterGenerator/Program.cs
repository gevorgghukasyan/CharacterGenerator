using CharacterGenerator.Common.Mapper;
using CharacterGenerator.DAL;
using CharacterGenerator.Entities;
using CharacterGenerator.Extensions;
using CharacterGenerator.Validators;
using CharacterGenerator.Validators.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CharacterGenerator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Action<Combination, string> saveFunc = (x, f) => Generator.Generate(x, Path.Combine(targetFolder, f));


			//var jsonFile = @"C:\Users\sargi\OneDrive\Desktop\CharacterGenerator\Target\Combinations_2022-15-6--00-25-01.json";
   //         var all = jsonFile.ReadFromFile<List<Combination>>();
			//foreach (var item in all)
   //         {
			//	saveFunc(item, "all");
			//}
   //         return;
            var parts = new List<List<string>>()
			{
				new List<string>{"b1", "b2" },
				new List<string>{"1", "2", "3", "4"},
				new List<string>{":", "-", "/" },
			};
			//var comb = MainLogic.GetAllCombinations(parts)
			//	.Select(c => $"{c.ElementAt(0)} {c.ElementAt(1)} {c.ElementAt(2)}")
			//	.JoinString(Environment.NewLine);
			//CodeGenerator.Run();

			//return;
			Validation validation = new Validation();
			IMapper<IEnumerable<ImageMetadata>, Combination> mapper = new ImageMetadataMapper();
			IMapper<Combination, IEnumerable<ImageMetadata>> combinationMapper = new CombinationMapper();

			Generator generator = new Generator();
			Manager manger = new Manager(validation, mapper, combinationMapper, generator);
			manger.Run(saveFunc);
			Console.WriteLine("End");
			Console.ReadKey();
		}
		static string targetFolder = @"C:\Users\C1\Downloads\CharacterGenerator\Target\all";//Saq
		//static string targetFolder = @"C:\Users\C1\Downloads\pics";//Gev
	}
}
