using CharacterGenerator.Collections;
using CharacterGenerator.Common.Mapper;
using CharacterGenerator.DAL;
using CharacterGenerator.Entities;
using CharacterGenerator.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace CharacterGenerator
{
	public class EyeModifier : IModifier<IEnumerable<Combination>>
	{
		private readonly IMapper<Combination, IEnumerable<ImageMetadata>> _combinationMapper;
		private readonly string _folder;

		public EyeModifier(string folder)
		{
			_combinationMapper = new CombinationMapper();
			_folder = folder;
		}

		private ImageMetadata GetById(string id, string type)
		{
			return id.ToImageMetadata(type);
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
		//public IEnumerable<Combination> GetLessCommonCombinations(IEnumerable<Combination> all) 
		//{
		//    foreach (var item in all)
		//    {
		//        var kyes = all.Select(x => (new List<string>().Add(x.Id)));

		//    }
		//}

		public IEnumerable<Combination> MakeNull(IEnumerable<Combination> all)
		{
			all.ForEach(x => x.Eye = null);
			return all;
		}

		public IEnumerable<Combination> Execute(IEnumerable<Combination> all)
		{
			List<List<string>> lists = new List<List<string>>();

			//all.Select(x => new Dictionary<string, Combination>().Add())


			//var sss = DataAccess.Percents.OrderByDescending(x => x.Value).Take(44);

			//foreach (var combination in sss)
			//{
			//    var s = all.Where(x => combination.)

			//}

			var mod1 = new ConditionalModifier(c => true,
				c => c.Eye = GetById(Path.Combine(_folder, "Superrare_1.png"), "Eye").ZIndex(1000));
			var mod2 = new ConditionalModifier(c => true,
				c => c.Eye = GetById(Path.Combine(_folder, "Superrare_2.png"), "Eye").ZIndex(1000));
			var mod3 = new ConditionalModifier(c => true,
				c => c.Eye = GetById(Path.Combine(_folder, "Superrare_3.png"), "Eye").ZIndex(1000));
			var shouldBeModified = all
		.OrderByDescending(GetRang)
		.Take(44);
			for (int i = 0; i < shouldBeModified.Count(); i++)
			{
				if (i < 14)
				{
					mod1.Execute(shouldBeModified.ElementAt(i));
				}
				else if (i < 29)
				{
					mod2.Execute(shouldBeModified.ElementAt(i));
				}
				else if (i < 44)
				{
					mod3.Execute(shouldBeModified.ElementAt(i));
				}
			}
			//.Select(mod.Execute);
			//.ForEach(x => x.Eye)
			//.ToList();
			//var max3perc = all.Where(x =>
			//	InPercent(x, all, c => c.Piercing, c => c.Armour, 3));
			//max3perc.ForEach(x => x.Background = new ImageMetadata(
			//			bg_blue.ImageFromFile(),
			//			bg_blue.GetFileName(),
			//			bg_blue.GetLastFolderName(),
			//			bg_blue.GetTag()
			//		));
			return all;
		}

		static private void EyeUp(Combination combination)
		{
			combination.Eye.ZIndex = 10;
		}
	}
}
