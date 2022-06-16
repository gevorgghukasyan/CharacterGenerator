using CharacterGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Validators.Abstractions
{
	public interface IValidator
	{
		bool Execute(Combination item);
	}
}
