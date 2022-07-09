using CharacterGenerator.DAL;
using CharacterGenerator.Entities;
using CharacterGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace CharacterGenerator
{
	public class BackgroundModifier : IModifier<IEnumerable<Combination>>
	{
		private readonly string _backgroundPath;

		public BackgroundModifier(string backgroundPath)
		{
			_backgroundPath = backgroundPath;
		}

		private bool InPercent(
			Combination combination,
			IEnumerable<Combination> combinations,
			Func<Combination, ImageMetadata> attribute1Selector,
			Func<Combination, ImageMetadata> attribute2Selector,
			int maxPercent)
		{
			var count1 = combinations.Count(x => attribute1Selector(combination).Equals(attribute1Selector(x)));
			if (count1 > (combinations.Count() * maxPercent / 100))
			{
				return false;
			}
			var count2 = combinations.Count(x => attribute2Selector(combination).Equals(attribute2Selector(x)));
			if (count2 > (combinations.Count() * maxPercent / 100))
			{
				return false;
			}

			return true;
		}
		private float GetAverage(List<float> capacities)
		{
			return capacities.Average(x => x);
		}

		private bool InPercent(
		Combination combination,
		int maxPercent)
		{
			//{
			//	List<float> capacities = new List<float>();

			//	if (combination.Mouth != null)
			//	{
			//		capacities.Add(combination.Mouth.PrevalenceInPercentage);
			//	}
			//	if (combination.Hat != null) 
			//	{
			//		capacities.Add(combination.Hat.PrevalenceInPercentage);

			//	}
			//	if (combination.Weapon!= null)
			//	{
			//		capacities.Add(combination.Weapon.PrevalenceInPercentage);
			//	}
			//	if (combination.Amulet != null) 
			//	{
			//		capacities.Add(combination.)
			//	}

			//}
			if (combination.Rarity < maxPercent)
			{
				return true;
			}

			return false;
		}

		public IEnumerable<Combination> Execute1(IEnumerable<Combination> all)
		{
			var max3perc = all.Where(x =>
				InPercent(x, 5));
			//InPercent(x, all, c => c.Eye, c => c.Armor, 3));

			//var bg = _backgroundPath.ImageFromFile().ResizeImage(new System.Drawing.Size(500, 500));
			var fn = _backgroundPath.GetFileName();
			var lfn = _backgroundPath.GetLastFolderName();
			var t = _backgroundPath.GetTag();
			var lastFolderName = new DirectoryInfo(_backgroundPath).Parent.Name;

			max3perc.ForEach(x => x.Background = new ImageMetadata(
						_backgroundPath,
						fn,
						lfn,
						t,
						DataAccess.Percents[fn],
						lastFolderName
					));


			return all;
		}

		public IEnumerable<Combination> Execute2(IEnumerable<Combination> all)
		{
			var max3perc = all.Where(x =>
				InPercent(x, 5));
			//InPercent(x, all, c => c.Weapon, c => c.Amulet, 3));

			//var bg = _backgroundPath.ImageFromFile().ResizeImage(new System.Drawing.Size(500, 500));
			var fn = _backgroundPath.GetFileName();
			var lfn = _backgroundPath.GetLastFolderName();
			var t = _backgroundPath.GetTag();
			var lastFolderName = new DirectoryInfo(_backgroundPath).Parent.Name;

			max3perc.ForEach(x => x.Background = new ImageMetadata(
						_backgroundPath,
						fn,
						lfn,
						t,
						DataAccess.Percents[fn],
						lastFolderName
					));


			return all;
		}

		public IEnumerable<Combination> Execute3(IEnumerable<Combination> all)
		{
			var max3perc = all.Where(x =>
				InPercent(x, 5));
			//InPercent(x, all, c => c.Mouth, c => c.Hat, 3));

			//var bg = _backgroundPath.ImageFromFile().ResizeImage(new System.Drawing.Size(500, 500));
			var fn = _backgroundPath.GetFileName();
			var lfn = _backgroundPath.GetLastFolderName();
			var t = _backgroundPath.GetTag();
			var lastFolderName = new DirectoryInfo(_backgroundPath).Parent.Name;

			max3perc.ForEach(x => x.Background = new ImageMetadata(
						_backgroundPath,
						fn,
						lfn,
						t,
						DataAccess.Percents[fn],
						lastFolderName
					));


			return all;
		}

		public IEnumerable<Combination> Execute(IEnumerable<Combination> all)
		{
			all = Execute1(all);
			all = Execute2(all);
			all = Execute3(all);

			return all;
		}
	}
}
