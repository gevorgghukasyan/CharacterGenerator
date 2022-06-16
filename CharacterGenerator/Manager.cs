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

		HashSet<string> Combinations = new HashSet<string>();

		private void _validation_OnResult(object sender, ValidationResult e)
		{
			var mc = (e.FailureReason as FailureReasonValidator<ImageMetadata>)?.InnerValidator as MaxCountValidator;

			Console.WriteLine($"Valid: {passed} | Ignored: {ignored} | {mc?.Name ?? e.FailureReason?.GetType().Name}  {mc?.MaxCount}");
			if (e.Success)
			{
				Combinations.Add(e.Combination.Id);
				passed++;
				Console.WriteLine(Combinations.Count);
				return;
			}
			ignored++;
		}

		int passed;
		int ignored;
		public void Run(Action<Combination, string> action)
		{
			var valProv = new AllPersonValidatorsProvider(_validation);
			//var images = Run("all", valProv.GetValidators(), action);

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

		Random personRnd = new Random();

		public IEnumerable<Combination> GetAllValidCombinations(PersonData[] personDatas, int maxCount)
		{
			//	foreach (var item in personDatas)
			//	{
			//		var ss = Helper.GetAllCombinations(item.AttributeLists).ToList();
			//	}


			List<Combination> combinations = new List<Combination>();
			HashSet<string> images = new HashSet<string>();
			int current = 0;

			//List<Combination> combinations = new List<Combination>();
			//        for (int i = 0; i < 3; i++)
			//        {
			//          var s = personParts.ElementAt(i);
			//        }

			do
			{
				//if (personDatas.All(p => p.AttributeLists.Any(a => a.Count == 0)))
				//{
				//	break;
				//}

				bool collision = true;
				Combination combination = null;
				PersonData person = null;
				bool outerBreak = false;
				int retryCount = 0;
				while (collision)
				{
					retryCount++;
					if (retryCount > 10000)
					{
						outerBreak = true;
						break;
					}
					//break;
					person = personDatas[personRnd.Next(0, 3)];
					var personParts = person.AttributeLists;
					var imageMetadatas = GetRandomCombination(personParts);//.Select(x => x.RandomPickUp()); //parts.Select(x=>_validation.Execute()) _validation.Execute()
					if (imageMetadatas == null)
					{
						continue;
					}
					if (imageMetadatas.Any(x => x == null))
					{
						outerBreak = true;
						break;
					}
					combination = _mapper.Map(imageMetadatas);
					if (!images.Add(combination.Id))
					{

						//break;
						collision = true;
						continue;
					}
					collision = false;
				}
				if (outerBreak)
				{
					break;
				}
				if (_validation.Execute(combination, person.validators))
				{
					current++;
					//break;
					Console.WriteLine($"-----Current valid item index: {current}-----");
					combinations.Add(combination);
					//yield return combination;
				}
			}
			while (current < maxCount);

			return combinations;
		}

		private IEnumerable<ImageMetadata> GetRandomCombination(List<List<ImageMetadata>> personParts)
		{
			//if (personParts.Any(x => x.Count == 0))
			//{
			//	return null;
			//}
			return personParts.Select(x => x.RandomPickUp());
		}

		public IEnumerable<Combination> GetAllValidCombinations(IEnumerable<Multitude<ImageMetadata>> parts, IEnumerable<IValidator> validators)
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

		public static List<List<ImageMetadata>> GetParts(string rootFolder)
		{
			var parts = new List<List<ImageMetadata>>();
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
				//if (folder.folder == "Eye")
				//{
				//	parts.Add(new Multitude<ImageMetadata>(x => x.Id) { ImageMetadata.NullObject(folder.folder) });
				//	continue;
				//}

				var partVariants = DataAccess
				.GetDirectories(Path.Combine(rootFolder, $@"{folder.folder}"))
				.Append(Path.Combine(rootFolder, $@"{folder.folder}"))
				.GetFiles()
				.Select(x => x.Select(y => y.ToImageMetadata(folder.folder)))
				.SelectMany(x => x)
				.ToList();
				if (!folder.required)
				{
					partVariants.AddRange(Enumerable.Range(1, Math.Max(1, partVariants.Count * 10 / 9)).Select(x => ImageMetadata.NullObject(folder.folder)));
					//partVariants.Add(ImageMetadata.NullObject(folder.folder));
				}
				parts.Add(partVariants);
			}

			return parts;
		}

		public void Execute(PersonData[] personDatas, Action<Combination, string> onValidComb)
		{
			var vals = new HashSet<string>();

			foreach (var person in personDatas)
			{
				foreach (var validator in person.validators.OfType<FailureReasonValidator<ImageMetadata>>())
				{
					if (validator.InnerValidator is MaxCountValidator mv)
					{
						if (vals.Add(mv.Name))
						{
							validator.OnValidationFailed += (s, o) => Validator_OnValidationFailed(s, o, personDatas.Select(p => p.AttributeLists).ToArray());
						}
					}
				}
			}

			//var allValidCombinations = GetAllValidCombinations(characterParts, validators);
			var allValidCombinations = GetAllValidCombinations(personDatas, 4500).ToList();

			foreach (var person in personDatas)
			{
				foreach (var validator in person.validators.OfType<FailureReasonValidator<ImageMetadata>>())
				{
					if (validator.InnerValidator is MaxCountValidator mv)
					{
						var result = mv.Check(allValidCombinations);
						//if(result.Status != CheckResultStatus.Success)
						{
							Console.WriteLine($"{result.Status} | {result.Message}");
						}
					}
				}
			}

			var bg_bluePath = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG\Z\Background\bg_blue.png"; //Gev
			var eye_folderPath = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG\Z\Eye"; // Gev
			BackgroundModifier backgroundModifier = new BackgroundModifier(bg_bluePath);
			EyeModifier eyeModifier = new EyeModifier(eye_folderPath);


			//eyeModifier.MakeNull(allValidCombinations);
			eyeModifier.Execute(allValidCombinations);
			backgroundModifier.Execute(allValidCombinations);

			foreach (var person in personDatas)
			{
				foreach (var validator in person.validators.OfType<FailureReasonValidator<ImageMetadata>>())
				{
					if (validator.InnerValidator is MaxCountValidator mv)
					{
						var result = mv.Check(allValidCombinations);
						//if(result.Status != CheckResultStatus.Success)
						{
							Console.WriteLine($"{result.Status} | {result.Message}");
						}
					}
				}
			}

			FromCombinationIPFSMetadataToMapper iPFSMetadataToMapper = new FromCombinationIPFSMetadataToMapper();

			allValidCombinations.ForEach(x => x.Rarity = GetRang(x));
			var all = allValidCombinations.Select(c => c.Id).JoinString(Environment.NewLine);
			var jsonFile = $@"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Target\Combinations_{DateTime.Now:yyyy-dd-M--HH-mm-ss}.json";
			allValidCombinations.Select(x => iPFSMetadataToMapper.Map(x)).WriteToFile(jsonFile);

			Parallel.ForEach(allValidCombinations, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (combination) =>
			{
				Console.WriteLine(combination.Id);
				Generator.Generate(combination, @"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Target\images");
			});

			//allValidCombinations.ForEach(x => Generator.Generate(x, @"C:\Users\C1\Downloads\CharacterGeneratorData\PNG\Target\images"));
		}

		private float GetRang(Combination combination)
		{
			var imageMetadata = _combinationMapper
				.Map(combination)
				.ToList();
			imageMetadata.RemoveAll(i => i == null);
			return GetAverage(imageMetadata);
		}

		private float GetAverage(List<ImageMetadata> images)
		{
			return images.Where(x => x.LastFolderName != "Eye").Average(x => x.PrevalenceInPercentage);
		}

		private void Validator_OnValidationFailed(object sender, ValidationFailedEventArgs<ImageMetadata> e, List<List<ImageMetadata>>[] personsArray)
		{
			DeleteFromPerson(e.Reason, personsArray[0]);
			DeleteFromPerson(e.Reason, personsArray[1]);
			DeleteFromPerson(e.Reason, personsArray[2]);
		}

		private void DeleteFromPerson(ImageMetadata image, List<List<ImageMetadata>> person)
		{
			foreach (var attributes in person)
			{
				var index = attributes.IndexOf(image);
				//attributes.Where(a => a.Id == image.Id ?? a = null :)
				/*var rem =*/
				attributes.Remove(image);

				//if (index != -1)
				//{
				//	attributes.Insert(index, ImageMetadata.NullObject(image.LastFolderName));
				//}
				//;
			}
			//var key = personFolder.GetFileName();
			//image.ImagePath = null;
			//image.RootFolderName = "null";
			//image.Id = "null";
			//image.Tag = "null";
		}

		//      public Combination[] Run(string personFolder, IEnumerable<IValidator> validators, Action<Combination, string> onValidComb)
		//{
		//	var parts = new List<Multitude<ImageMetadata>>();
		//	var folders = new (string folder, bool required)[]
		//	{
		//		("Background", true),
		//		("Weapon", false),
		//		("Person", true),
		//		("Eye", true),
		//		("Armor", false),
		//		("Amulets", false),
		//		("Piercing", false),
		//		("Hat", false),
		//		("Mouth", false)
		//	};

		//	var rootFolder = @"C:\Users\C1\Downloads\CharacterGenerator\PNG\PNG";// Gev
		//	foreach (var folder in folders)
		//	{
		//		var partVariants = DataAccess
		//		.GetDirectories(Path.Combine(rootFolder, $@"{personFolder}\{folder.folder}"))
		//		.Append(Path.Combine(rootFolder, $@"{personFolder}\{folder.folder}"))
		//		.GetFiles()
		//		.Select(x => x.Select(y => y.ToImageMetadata()))
		//		.SelectMany(x => x)
		//		.ToMultitude(x=>x.Id);
		//		if (!folder.required)
		//		{
		//			partVariants.Add(new ImageMetadata(null, "null", partVariants[0].RootFolderName, null, 0));
		//		}
		//		parts.Add(partVariants);


		//	}

		//	var allCombinations = GetAllValidCombinations(parts, validators);

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
		//		return all
		//			.Select(x => { onValidComb?.Invoke(x, personFolder); return x; })
		//			.ToArray();
		//	}
		//	catch (Exception ex)
		//	{
		//		throw;
		//	}
		//}
	}
}
