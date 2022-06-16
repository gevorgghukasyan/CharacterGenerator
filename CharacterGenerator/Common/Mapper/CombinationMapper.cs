using CharacterGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Common.Mapper
{
	public class CombinationMapper : IMapper<Combination, IEnumerable<ImageMetadata>>
	{
		IEnumerable<ImageMetadata> IMapper<Combination, IEnumerable<ImageMetadata>>.Map(Combination t)
		{
			return new List<ImageMetadata>()
			{
				t.Background,
				t.Weapon,
				t.Person,
				t.Eye,
				t.Armour,
				t.Amulet,
				t.Piercing,
				t.Hat,
				t.Mouth
			};
		}
	}
}
