using CharacterGenerator.Entities;
using CharacterGenerator.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Validators.Implementations
{
	public class MaxCountValidator : IValidator
	{
		public string Name { get; set; }
		private readonly Func<Combination, bool> _func;
		private readonly IValidationContext _validationContext;
		public int Passed { get; set; }
		public int MaxCount { get; }

		public bool _inScope { get; set; }
		public bool _valid;

		public MaxCountValidator(string name, Func<Combination, bool> func, int maxCount, IValidationContext validationContext)
		{
			Name = name;
			_func = func;
			MaxCount = maxCount;
			_validationContext = validationContext;

			_validationContext.OnResult += _validationContext_OnResult;
		}

		private void _validationContext_OnResult(object sender, ValidationResult e)
		{
			if (_inScope && _valid && e.Success)
			{
				Passed++;
			}
		}

		public bool Execute(Combination item)
		{
			if (Passed < 0)
			{
				throw new Exception();
			}
			if (!_func(item))
			{
				_inScope = false;
				_valid = true;
				return true;
			}
			_inScope = true;
			if (Passed < MaxCount)
			{
				_valid = true;
				return true;
			}

			_valid = false;

			return false;
		}
	}

	public class ValidatorRem : IValidator
	{
		private readonly IValidator validator;
		private readonly Func<Combination, ImageMetadata> reason;

		public ValidatorRem(IValidator validator, Func<Combination, ImageMetadata> reason)
		{
			this.validator = validator;
			this.reason = reason;
		}

		public event EventHandler<ImageMetadata> OnInvalidItem;

		public bool Execute(Combination item)
		{
			var valid = validator.Execute(item);
			if (!valid)
			{
				OnInvalidItem?.Invoke(this, reason(item));
			}

			return valid;
		}
	}

	static class ValEx
	{
		public static ValidatorRem ToRemVal(this IValidator validator, Func<Combination, ImageMetadata> reason)
		{
			return new ValidatorRem(validator, reason);
		}
	}
}
