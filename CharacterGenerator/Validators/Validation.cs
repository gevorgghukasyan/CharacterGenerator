using CharacterGenerator.Entities;
using CharacterGenerator.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Validators
{
	public class Validation : IValidationContext
	{
		public event EventHandler<ValidationResult> OnResult;
		static int invalidCount = 0;
		static int validCount = 0;
		public IEnumerable<Combination> Execute(IEnumerable<Combination> combinations, IEnumerable<IValidator> validators)
		{
			foreach (var item in combinations)
			{
				var itemIsValid = true;

				foreach (var validator in validators)
				{
					bool valid = validator.Execute(item);
					if (!valid)
					{
						itemIsValid = false;
						OnResult?.Invoke(this, new ValidationResult { Combination = item, Success = false, FailureReason = validator });
						break;
					}
				}
				if (itemIsValid)
				{
					OnResult?.Invoke(this, new ValidationResult { Combination = item, Success = true });
					validCount++;
					Console.WriteLine(validCount);
					yield return item;
				}
			}
		}

		public bool Execute(Combination combination, IEnumerable<IValidator> validators)
		{
			foreach (var validator in validators)
			{
				bool valid = validator.Execute(combination);
				if (!valid)
				{
					OnResult?.Invoke(this, new ValidationResult { Combination = combination, Success = false, FailureReason = validator });
					return false;
				}
			}
			OnResult?.Invoke(this, new ValidationResult { Combination = combination, Success = true });
			return true;
		}
	}
}
