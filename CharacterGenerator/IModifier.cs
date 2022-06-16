namespace CharacterGenerator
{
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
}
