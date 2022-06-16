using CharacterGenerator.Collections;
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
			var jsonFiletoWrite = $@"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Target\IPFS{DateTime.Now:yyyy-dd-M--HH-mm-ss}.json";

			Action<Combination, string> saveFunc = (x, f) => Generator.Generate(x, Path.Combine(targetFolder, f));

			//var jsonFile = @"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Target\Combinations_2022-23-6--12-13-46.json";
			//var all = jsonFile.ReadFromFile<List<Combination>>();
			//FromCombinationIPFSMetadataToMapper fromCombinationIPFSMetadataToMapper = new FromCombinationIPFSMetadataToMapper();

			//all.Select(x => fromCombinationIPFSMetadataToMapper.Map(x)).WriteToFile(jsonFiletoWrite);
			//return;

			////Parallel.ForEach(all, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (combination) =>
			////{
			////	Console.WriteLine(combination.Id);
			////	Generator.Generate(combination, @"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Target\images");
			////});

			////foreach (var item in all)
			////         {
			////	saveFunc(item, "all");
			////}
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
			//var valProv = new AllPersonValidatorsProvider(validation);


			string darkMageRootPath = @"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Images\Dark Mage";
			string druidRootPath = @"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Images\Druid";
			string warriorRootPath = @"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Images\Warrior";

			List<string> rootPaths = new List<string>() { darkMageRootPath, druidRootPath, warriorRootPath };


			var darkMage = Manager.GetParts(darkMageRootPath);
			var druid = Manager.GetParts(druidRootPath);
			var warrior = Manager.GetParts(warriorRootPath);

			var darkMageVal = new DarkMageValidatorsProvider(validation);
			var druidVal = new DruidValidatorsProvider(validation);
			var warriorVal = new WarriorValidatorsProvider(validation);

			var personsArray = new PersonData[]
			{
				new PersonData { AttributeLists = darkMage, validators = darkMageVal.GetValidators() },
				new PersonData { AttributeLists = druid, validators = druidVal.GetValidators() },
				new PersonData { AttributeLists = warrior, validators = warriorVal.GetValidators() },
			};


			Generator generator = new Generator();
			Manager manager = new Manager(validation, mapper, combinationMapper, generator);
			manager.Execute(personsArray, saveFunc);
			Console.WriteLine("End");
			Console.ReadKey();
		}
		static string targetFolder = @"C:\Users\C1\Downloads\CharacterGenerator\Target\all";//Saq
	}
}
