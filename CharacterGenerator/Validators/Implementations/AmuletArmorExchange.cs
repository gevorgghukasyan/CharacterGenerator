using CharacterGenerator.Entities;
using CharacterGenerator.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Validators.Implementations
{
	public class AmuletArmorExchange : IValidator
	{
		public bool Execute(Combination item)
		{

			Console.WriteLine($"-------------{item.Amulet.LastFolderName}-------------");
			if (item.Amulet.LastFolderName == "Amulets_1")
			{
				if (item.Amulet.ZIndex > item.Armor.ZIndex)
				{
					var amuletTargetZIndex = item.Armor.ZIndex;
					item.Armor.ZIndex = item.Amulet.ZIndex;
					item.Amulet.ZIndex = amuletTargetZIndex;
				}
				else
				{

				}
			}

			return true;
		}
	}

	public class RareEyesExchange : IValidator
	{
		public bool Execute(Combination item)
		{
			if (item.Amulet.LastFolderName == "Amulets_2")
			{
				var amuletTargetZIndex = item.Armor.ZIndex;
				item.Armor.ZIndex = item.Amulet.ZIndex;
				item.Amulet.ZIndex = amuletTargetZIndex;
			}

			return true;
		}
	}
}
