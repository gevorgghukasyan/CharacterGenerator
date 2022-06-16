using CharacterGenerator.Entities;
using CharacterGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Common.Mapper
{
	public class ImageMetadataMapper : IMapper<IEnumerable<ImageMetadata>, Combination>
	{
		public Combination Map(IEnumerable<ImageMetadata> t)
		{
			//if (t.Count() != 9)
			//	throw new ArgumentOutOfRangeException();

			var images = t.ToList();
			if (images.Count() == 8)
			{
				images.Insert(0, null);
			}

			return new Combination()
			{
				Background = images[0].Clone().ZIndex(0),
				Weapon = images[1].Clone().ZIndex(1),
				Person = images[2].Clone().ZIndex(2),
				Eye = images[3].Clone().ZIndex(3),
				Armor = images[4].Clone().ZIndex(4),
				Amulet = images[5].Clone().ZIndex(5),
				Piercing = images[6].Clone().ZIndex(6),
				Hat = images[7].Clone().ZIndex(7),
				Mouth = images[8].Clone().ZIndex(8)


				//            Armour = images[3],
				//Amulet = images[4],
				//Piercing = images[5],
				//Hat = images[6],
				//Mouth = images[7]
			};
		}
	}
}
