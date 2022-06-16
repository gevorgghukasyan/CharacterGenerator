using CharacterGenerator.Entities;
using CharacterGenerator.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Validators.Implementations
{
	public class IncompatibleDirectoryValidator : IValidator
	{
		public bool Execute(Combination item)
		{
			return
				!((item.Amulet.LastFolderName == "Amulets_1" && item.Piercing.LastFolderName == "Piercing_2")
				|| (item.Amulet.LastFolderName == "Amulets_2" && item.Piercing.LastFolderName == "Piercing_1"));
		}
	}
}
