using CharacterGenerator.Entities;
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
			if(images.Count == 8)
            {
				images.Insert(0, null);
            }

		

			return new Combination()
			{
				Background = images[0],
				Weapon = images[1],
				Person = images[2],
				Eye = images[3],
				Armour = images[4],
				Amulet = images[5],
				Piercing = images[6],
				Hat = images[7],
				Mouth = images[8]
			};
		}
	}
}
