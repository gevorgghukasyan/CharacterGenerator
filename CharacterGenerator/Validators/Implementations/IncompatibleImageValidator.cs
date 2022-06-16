using CharacterGenerator.Entities;
using CharacterGenerator.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Validators.Implementations
{
	public class IncompatibleImageValidator : IValidator
	{
		public bool Execute(Combination item)
		{
			return
				!((item.Piercing.Id == "Piercing_47" && item.Mouth.Id == "mouth_61")
				|| (item.Mouth.Id == "mouth_61" && item.Hat.Id == "Hat_11")
				|| ((item.Eye?.Id == "Eye_8" || item.Eye?.Id == "Eye_7") && item.Piercing.Id == "Piercing_50")
				|| (item.Mouth.Id == "mouth_61" && item.Hat.Id == "Hat_11"));
		}
	}
}
