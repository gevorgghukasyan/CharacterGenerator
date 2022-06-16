using CharacterGenerator.Entities;
using CharacterGenerator.Entities.IPFS;

namespace CharacterGenerator.Common.Mapper
{
	public class FromCombinationIPFSMetadataToMapper : IMapper<Combination, IPFSMetadata>
	{
		static int count = 0;
		public IPFSMetadata Map(Combination t)
		{
			count++;
			return new IPFSMetadata(
				"",
				$"Character_{count}",
				new Attributes[]
						{
							new Attributes("Person",t.Person.Id.ToLower().Contains("empty")? null :t.Person.Id),
							new Attributes("Hat",t.Hat.Id.ToLower().Contains("empty")? null :t.Hat.Id),
							new Attributes("Eye",t.Eye.Id.ToLower().Contains("empty")? null :t.Eye.Id),
							new Attributes("Armor",t.Armor.Id.ToLower().Contains("empty")? null :t.Armor.Id),
							new Attributes("Amulet",t.Amulet.Id.ToLower().Contains("empty")? null :t.Amulet.Id),
							new Attributes("Background",t.Background.Id.ToLower().Contains("empty")? null :t.Background.Id),
							new Attributes("Mouth",t.Mouth.Id.ToLower().Contains("empty")? null :t.Mouth.Id ),
							new Attributes("Weapon",t.Weapon.Id.ToLower().Contains("empty")? null :t.Weapon.Id ),
						}, t.Rarity);


		}
	}
}
