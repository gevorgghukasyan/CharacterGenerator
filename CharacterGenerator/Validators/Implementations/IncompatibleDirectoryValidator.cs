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
				!((item.Amulet.RootFolderName == "Amulet_1" && item.Piercing.RootFolderName == "Piercing_2")
				|| (item.Amulet.RootFolderName == "Amulet_2" && item.Piercing.RootFolderName == "Piercing_1"));
		}
	}
}
