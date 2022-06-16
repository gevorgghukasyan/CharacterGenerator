using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.UI
{
	public interface IUIInputValidator
	{
		bool Validate(string input);
	}

	public class UIInputValidator : IUIInputValidator
	{
		public bool Validate(string input)
		{
			throw new NotImplementedException();
		}
	}
}
