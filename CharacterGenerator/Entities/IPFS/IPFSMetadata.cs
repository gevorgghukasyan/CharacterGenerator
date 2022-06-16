using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Entities.IPFS
{
	public class IPFSMetadata
	{
		public string image { get; set; }
		public string name { get; set; }
		public Attributes[] attributes { get; set; }
		public float rarity {get; set; }

		public IPFSMetadata(string image, string name, Attributes[] attributes, float rarity)
		{
			this.image = image;
			this.name = name;
			this.attributes = attributes;
			this.rarity = rarity;
		}
	}

	public class Attributes
	{
		public string trait_type { get; set; }
		public string value { get; set; }

		public Attributes(string traitType, string value)
		{
			trait_type = traitType;
			this.value = value;
		}
	}
}
