using CharacterGenerator.Entities;
using CharacterGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CharacterGenerator
{
    public class BackgroundModifier : IModifier<List<Combination>>
	{
        private readonly string _backgroundPath;

        public BackgroundModifier(string backgroundPath)
        {
            _backgroundPath = backgroundPath;
        }

		private bool InPercent(
			Combination combination,
			List<Combination> combinations,
			Func<Combination, ImageMetadata> attribute1Selector,
			Func<Combination, ImageMetadata> attribute2Selector,
			int maxPercent)
		{
			var count1 = combinations.Count(x => attribute1Selector(combination).Equals(attribute1Selector(x)));
			if (count1 > (combinations.Count * maxPercent / 100))
			{
				return false;
			}
			var count2 = combinations.Count(x => attribute2Selector(combination).Equals(attribute2Selector(x)));
			if (count2 > (combinations.Count * maxPercent / 100))
			{
				return false;
			}

			return true;
		}

		public List<Combination> Execute(List<Combination> all)
		{
			var max3perc = all.Where(x =>
				InPercent(x, all, c => c.Eye, c => c.Armour, 3));
			var s = max3perc.Count();
			//var bg = _backgroundPath.ImageFromFile().ResizeImage(new System.Drawing.Size(500, 500));
			var fn = _backgroundPath.GetFileName();
			var lfn = _backgroundPath.GetLastFolderName();
			var t = _backgroundPath.GetTag();
			max3perc.ForEach(x => x.Background = new ImageMetadata(
						_backgroundPath,
						fn,
						lfn,
						t
					));
			return all;
		}
	}
}
