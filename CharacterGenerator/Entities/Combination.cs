using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Entities
{
	public class Combination
	{
		public ImageMetadata Background { get; set; }
		public ImageMetadata Amulet { get; set; }
		public ImageMetadata Weapon { get; set; }
		public ImageMetadata Piercing { get; set; }
		public ImageMetadata Mouth { get; set; }
		public ImageMetadata Hat { get; set; }
		public ImageMetadata Eye { get; set; }
		public ImageMetadata Armour { get; set; }
		public ImageMetadata Person { get; set; }
		public string Id
		{
			get
			{
				var id = string.Join("_", Background?.Id, Amulet?.Id, Weapon?.Id, Piercing?.Id, Mouth?.Id, Hat?.Id, Eye?.Id, Armour?.Id, Person?.Id);
				return id;
			}
		}
	}
}
