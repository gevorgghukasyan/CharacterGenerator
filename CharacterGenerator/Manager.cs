using CharacterGenerator.Collections;
using CharacterGenerator.Common.Mapper;
using CharacterGenerator.DAL;
using CharacterGenerator.Entities;
using CharacterGenerator.Extensions;
using CharacterGenerator.Validators;
using CharacterGenerator.Validators.Abstractions;
using CharacterGenerator.Validators.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace CharacterGenerator
{
	public class Manager
	{
		private readonly Validation _validation;
		private IMapper<IEnumerable<ImageMetadata>, Combination> _mapper;
		private IMapper<Combination, IEnumerable<ImageMetadata>> _combinationMapper;
		private Generator _generator;
		public Manager(Validation validation, IMapper<IEnumerable<ImageMetadata>, Combination> mapper, IMapper<Combination, IEnumerable<ImageMetadata>> combinationMapper, Generator generator)
		{
			_mapper = mapper;
			_combinationMapper = combinationMapper;
			_generator = generator;
			_validation = validation;
			_validation.OnResult += _validation_OnResult;
		}

		private void _validation_OnResult(object sender, ValidationResult e)
		{
			var mc = e.FailureReason as MaxCountValidator;
			Console.WriteLine($"Valid: {passed} | Ignored: {ignored} | {mc?.Name ?? e.FailureReason?.GetType().Name}  {mc?.MaxCount}");
			if (e.Success)
			{
				passed++;
				return;
			}
			ignored++;
		}

		int passed;
		int ignored;
		public void Run(Action<Combination, string> action)
		{
			var valProv = new AllPersonValidatorsProvider(_validation);
			var images = Run("all", valProv.GetValidators(), action);

			//var personsData = new (IPersonValidatorsProvider valProv, string rootFolder)[]
			//{
			//	(new WarriorValidatorsProvider(_validation), "Warrior"),
			//	(new DruidValidatorsProvider(_validation), "Druid"),
			//	(new DarkMageValidatorsProvider(_validation), "Dark Mage"),
			//};
			//foreach (var item in personsData)
			//{
			//	var validators = item.valProv.GetValidators();
			//	var images = Run(item.rootFolder, validators, action);
			//}
		}

		public IEnumerable<Combination> GetAllValidCombinations(IEnumerable<Multitude<Multitude<ImageMetadata>>> personParts, IEnumerable<IValidator> validators)
		{
			HashSet<string> images = new HashSet<string>();

			int total = 4500;
			int current = 0;
			//List<Combination> combinations = new List<Combination>();
			do
			{
				foreach (var parts in personParts)
				{
					var imageMetadatas = parts.Select(x => x.RandomPickUp()); //parts.Select(x=>_validation.Execute()) _validation.Execute()
					var combination = _mapper.Map(imageMetadatas);
					if (_validation.Execute(combination, validators))
					{
						if (!images.Add(combination.Id))
						{
							continue;
						}
						current++;
						yield return combination;
						Console.WriteLine($"-----Current valid item index: {current}-----");
						//combinations.Add(combination);
					}
				}
			}
			while (current < total);
			//return combinations;
		}

		public IEnumerable<Combination> GetAllValidCombinations(Multitude<Multitude<ImageMetadata>> parts, IEnumerable<IValidator> validators)
		{
			//var allCombinations = Helper.GetAllCombinations(parts)
			//	;

			//var allValidCombinations = allCombinations
			//	.Select(x => _mapper.Map(x))
			//	.Where(c => _validation.Execute(c, validators))
			//	.Take(500)
			//	.ToList();

			//return allValidCombinations;

			HashSet<string> images = new HashSet<string>();

			int total = 4500;
			int current = 0;
			List<Combination> combinations = new List<Combination>();
			do
			{
				var imageMetadatas = parts.Select(x => x.RandomPickUp()); //parts.Select(x=>_validation.Execute()) _validation.Execute()
				var combination = _mapper.Map(imageMetadatas);
				if (_validation.Execute(combination, validators))
				{
					if (!images.Add(combination.Id))
					{

					}
					current++;
					yield return combination;
					Console.WriteLine($"-----Current valid item index: {current}-----");
					combinations.Add(combination);
				}
			}
			while (current < total);
		}

		public Multitude<Multitude<ImageMetadata>> GetParts(string rootFolder)
		{
			var parts = new Multitude<Multitude<ImageMetadata>>();
			var folders = new (string folder, bool required)[]
			{
				("Background", true),
				("Weapon", false),
				("Person", true),
				("Eye", true),
				("Armor", false),
				("Amulets", false),
				("Piercing", false),
				("Hat", false),
				("Mouth", false)
			};

			foreach (var folder in folders)
			{
				var partVariants = DataAccess
				.GetDirectories(Path.Combine(rootFolder, $@"{folder.folder}"))
				.Append(Path.Combine(rootFolder, $@"{folder.folder}"))
				.GetFiles()
				.Select(x => x.Select(y => y.ToImageMetadata()))
				.SelectMany(x => x)
				.ToMultitude();
				if (!folder.required)
				{
					partVariants.Add(new ImageMetadata(null, "null", partVariants[0].RootFolderName, null, 0));
				}
				parts.Add(partVariants);
			}

			return parts;
		}

		public Combination[] Execute(IEnumerable<IValidator> validators, Action<Combination, string> onValidComb)
		{
			string darkMageRootPath = @"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Images\Dark Mage";
			string druidRootPath = @"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Images\Druid";
			string warriorRootPath = @"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Images\Warrior";

			List<string> rootPaths = new List<string>() { darkMageRootPath, druidRootPath, warriorRootPath };

			var characterParts = rootPaths.Select(x => GetParts(x));

			var allValidCombinations = GetAllValidCombinations(characterParts, validators);

			var bg_bluePath = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG\Z\Background\bg_blue.png"; //Gev
			var eye_folderPath = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG\Z\Eye"; // Gev
			BackgroundModifier backgroundModifier = new BackgroundModifier(bg_bluePath);
			EyeModifier eyeModifier = new EyeModifier(eye_folderPath);
			eyeModifier.Execute(allValidCombinations);
			backgroundModifier.Execute(allValidCombinations);

			var jsonFile = $@"C:\Users\C1\Downloads\CharacterGenerator\Target\Combinations_{DateTime.Now:yyyy-dd-M--HH-mm-ss}.json";
			allValidCombinations.WriteToFile(jsonFile);
			return null;
		}

		public Combination[] Run(string personFolder, IEnumerable<IValidator> validators, Action<Combination, string> onValidComb)
		{
			var parts = new Multitude<Multitude<ImageMetadata>>();
			var folders = new (string folder, bool required)[]
			{
				("Background", true),
				("Weapon", false),
				("Person", true),
				("Eye", true),
				("Armor", false),
				("Amulets", false),
				("Piercing", false),
				("Hat", false),
				("Mouth", false)
			};

			var rootFolder = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG";// Gev
			foreach (var folder in folders)
			{
				var partVariants = DataAccess
				.GetDirectories(Path.Combine(rootFolder, $@"{personFolder}\{folder.folder}"))
				.Append(Path.Combine(rootFolder, $@"{personFolder}\{folder.folder}"))
				.GetFiles()
				.Select(x => x.Select(y => y.ToImageMetadata()))
				.SelectMany(x => x)
				.ToMultitude();
				if (!folder.required)
				{
					partVariants.Add(new ImageMetadata(null, "null", partVariants[0].RootFolderName, null, 0));
				}
				parts.Add(partVariants);


			}

			var allCombinations = GetAllValidCombinations(parts, validators).ToMultitude();

			var bg_bluePath = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG\Z\Background\bg_blue.png"; //Gev
			var eye_folderPath = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG\Z\Eye"; // Gev
			BackgroundModifier backgroundModifier = new BackgroundModifier(bg_bluePath);
			EyeModifier eyeModifier = new EyeModifier(eye_folderPath);
			eyeModifier.Execute(allCombinations);
			backgroundModifier.Execute(allCombinations);


			var jsonFile = $@"C:\Users\C1\Downloads\CharacterGenerator\Target\Combinations_{DateTime.Now:yyyy-dd-M--HH-mm-ss}.json";
			allCombinations.WriteToFile(jsonFile);

			var all = jsonFile.ReadFromFile<List<Combination>>();
			try
			{
				return all
					.Select(x => { onValidComb?.Invoke(x, personFolder); return x; })
					.ToArray();
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}

	//public Combination[] Run(string personFolder, IEnumerable<IValidator> validators, Action<Combination, string> onValidComb)
	//{
	//	var parts = new Multitude<Multitude<ImageMetadata>>();
	//	var folders = new (string folder, bool required)[]
	//	{
	//			("Background", true),
	//			("Weapon", false),
	//			("Person", true),
	//			("Eye", true),
	//			("Armor", false),
	//			("Amulets", false),
	//			("Piercing", false),
	//			("Hat", false),
	//			("Mouth", false)
	//	};
	//	//var rootFolder = @"C:\Users\sargi\OneDrive\Desktop\CharacterGenerator\PNG\PNG";// Saq
	//	var rootFolder = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG";// Gev
	//	foreach (var folder in folders)
	//	{
	//		var partVariants = DataAccess
	//		.GetDirectories(Path.Combine(rootFolder, $@"{personFolder}\{folder.folder}"))
	//		.Append(Path.Combine(rootFolder, $@"{personFolder}\{folder.folder}"))
	//		.GetFiles()
	//		.Select(x => x.Select(y => y.ToImageMetadata()))
	//		.SelectMany(x => x)
	//		.ToMultitude();
	//		if (!folder.required)
	//		{
	//			partVariants.Add(new ImageMetadata(null, "null", partVariants[0].RootFolderName, null));
	//		}
	//		parts.Add(partVariants);
	//	}
	//	//int k = 1;
	//	//var alll = Helper.GetAllCombinations(parts)
	//	//	.AsParallel()
	//	//	.WithDegreeOfParallelism(2)
	//	//	.Select(x => { Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} | {k++}"); return x; })
	//	//	.ToList()
	//	//	;

	//	var allCombinations = GetAllValidCombinations(parts, validators).ToMultitude();

	//	//var bg_bluePath = @"C:\Users\sargi\OneDrive\Desktop\CharacterGenerator\PNG\PNG\Z\Background\bg_blue.png";// Saq
	//	//var eye_folderPath = @"C:\Users\sargi\OneDrive\Desktop\CharacterGenerator\PNG\PNG\Z\Eye";// Saq

	//	var bg_bluePath = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG\Z\Background\bg_blue.png"; //Gev
	//	var eye_folderPath = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG\Z\Eye"; // Gev
	//	BackgroundModifier backgroundModifier = new BackgroundModifier(bg_bluePath);
	//	EyeModifier eyeModifier = new EyeModifier(eye_folderPath);
	//	eyeModifier.Execute(allCombinations);
	//	backgroundModifier.Execute(allCombinations);


	//	var jsonFile = $@"C:\Users\C1\Downloads\CharacterGenerator\Target\Combinations_{DateTime.Now:yyyy-dd-M--HH-mm-ss}.json";
	//	allCombinations.WriteToFile(jsonFile);

	//	var all = jsonFile.ReadFromFile<List<Combination>>();
	//	try
	//	{
	//		//var allValidImages = _validation
	//		//   .Execute(allCombinations, validators)
	//		//	.ToArray();
	//		return all
	//			.Select(x => { onValidComb?.Invoke(x, personFolder); return x; })
	//			.ToArray();
	//	}
	//	catch (Exception ex)
	//	{
	//		throw;
	//	}
	//	//foreach (var pv in parts)
	//	//{
	//	//	foreach (var var in pv)
	//	//	{
	//	//		var.Image.Dispose();
	//	//	}
	//	//}
	//}


	public interface IModifier<T>
	{
		T Execute(T data);
	}

	public interface ICombModifier : IModifier<CombinationData>
	{
	}

	public class CombinationData
	{
		public Combination Combination { get; }
		public List<Combination> All { get; }
	}
	public class ConditionalModifier : IModifier<Combination>
	{
		private readonly Func<Combination, bool> _matchCondition;
		private readonly Action<Combination> _action;
		public ConditionalModifier(Func<Combination, bool> matchCondition, Action<Combination> action)
		{
			_matchCondition = matchCondition;
			_action = action;
		}
		public Combination Execute(Combination t)
		{
			if (_matchCondition(t))
			{
				_action(t);
			}
			return t;
		}
	}
}
