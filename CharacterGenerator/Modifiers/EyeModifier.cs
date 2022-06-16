using CharacterGenerator.Common.Mapper;
using CharacterGenerator.DAL;
using CharacterGenerator.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace CharacterGenerator
{
    public class EyeModifier : IModifier<List<Combination>>
	{
		private readonly IMapper<Combination, IEnumerable<ImageMetadata>> _combinationMapper;
        private readonly string _folder;

        public EyeModifier(string folder)
		{
			_combinationMapper = new CombinationMapper();
            _folder = folder;
        }

		private ImageMetadata GetById(string id)
		{
			return id.ToImageMetadata();
		}

		private int GetRang(Combination combination)
		{
			var imageMetadata = _combinationMapper
				.Map(combination)
				.ToList();
			imageMetadata.RemoveAll(i => i == null);
			return imageMetadata.Count;
		}
		public List<Combination> Execute(List<Combination> all)
		{
			var mod1 = new ConditionalModifier(c => true,
				c => c.Eye = GetById(Path.Combine(_folder, "Superrare_1.png")));
			var mod2 = new ConditionalModifier(c => true,
				c => c.Eye = GetById(Path.Combine(_folder, "Superrare_2.png")));
			var mod3 = new ConditionalModifier(c => true,
				c => c.Eye = GetById(Path.Combine(_folder, "Superrare_3.png")));
			var shouldBeModified = all
		.OrderByDescending(GetRang)
		.Take(44);
			for (int i = 0; i < shouldBeModified.Count(); i++)
			{
				if (i < 13)
				{
					mod1.Execute(shouldBeModified.ElementAt(i));
				}
				else if (i < 26)
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
	}
}
