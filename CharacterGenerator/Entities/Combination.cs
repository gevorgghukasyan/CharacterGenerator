using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Entities
{
	public class Combination
	{
		public Combination()
		{

		}

		public ImageMetadata Background { get; set; }
		public ImageMetadata Amulet { get; set; }
		public ImageMetadata Weapon { get; set; }
		public ImageMetadata Piercing { get; set; }
		public ImageMetadata Mouth { get; set; }
		public ImageMetadata Hat { get; set; }
		public ImageMetadata Eye { get; set; }
		public ImageMetadata Armor { get; set; }
		public ImageMetadata Person { get; set; }
		public float Rarity { get; set; }

		public string Id
		{
			get
			{
				var id = string.Join("_", Background.Id, Amulet.Id, Weapon.Id, Piercing.Id, Mouth.Id, Hat.Id, Eye.Id, Armor.Id, Person.Id);
				return id;
			}
		}

		private float GetAverage(List<ImageMetadata> images)
		{
			return images.Where(x => x.LastFolderName != "Eye").Average(x => x.PrevalenceInPercentage);
		}

		//public float PrevalenceInPercentage
		//{
		//    get
		//    {
		//        if (this.PrevalenceInPercentage != 0)
		//            return this.PrevalenceInPercentage;

		//        return GetPrevalenceInPercentageArithmeticMean(this);
		//    }
		//}

		private float GetPrevalenceInPercentageArithmeticMean(Combination combination)
		{
			const float ITEM_COUNT = 8;

			return (combination.Hat.PrevalenceInPercentage
				+ combination.Mouth.PrevalenceInPercentage
				+ combination.Eye.PrevalenceInPercentage
				+ combination.Piercing.PrevalenceInPercentage
				+ combination.Background.PrevalenceInPercentage
				+ combination.Amulet.PrevalenceInPercentage
				+ combination.Armor.PrevalenceInPercentage
				+ combination.Weapon.PrevalenceInPercentage)
				/ ITEM_COUNT;
		}
	}
}
