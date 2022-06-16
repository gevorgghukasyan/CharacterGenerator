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
		private readonly Func<Combination, bool> _matchFunc;

		private readonly IValidationContext _validationContext;
		public int Passed { get; set; }
		public int MaxCount { get; }

		public bool _inScope { get; set; }
		public bool _valid;

		public MaxCountValidator(string name, Func<Combination, bool> func, int maxCount, IValidationContext validationContext)
		{
			Name = name;
			_matchFunc = func;
			MaxCount = maxCount;
			_validationContext = validationContext;

			_validationContext.OnResult += _validationContext_OnResult;
		}

		int executions;
		int increments;

		private void _validationContext_OnResult(object sender, ValidationResult e)
		{
			if (_matchFunc(e.Combination) && _valid && e.Success)
			{
				increments++;
				Passed++;
				if(Passed > MaxCount)
				{

				}
			}
		}

		public bool Execute(Combination item)
		{
			executions++;
			if (Passed > MaxCount)
			{

			}
			//Console.WriteLine($"Max Count: {Name} | {Passed}/{MaxCount} | {item.Id}");

			if (Passed < 0)
			{
				throw new Exception();
			}
			if (!_matchFunc(item))
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

			//OnValidationFailed?.Invoke(this, item);

			_valid = false;

			return false;
		}

		public CheckResult Check(List<Combination> combinations)
		{
			var count = combinations.Count(_matchFunc);
			if(count == MaxCount)
			{
				return new CheckResult(CheckResultStatus.Success, $"{this.Name} | {this.Passed}/{this.MaxCount}");
			}

			if(count < MaxCount)
			{
				return new CheckResult(CheckResultStatus.Warning, $"{this.Name} | {this.Passed}/{this.MaxCount}");
			}

			return new CheckResult(CheckResultStatus.Error, $"{this.Name} | {this.Passed}/{this.MaxCount}");
		}
	}

	public class CheckResult
	{
		public CheckResultStatus Status { get; set; }

		public CheckResult(CheckResultStatus status, string message = null)
		{
			Status = status;
			Message = message;
		}

		public string Message { get; set; }
	}

	public enum CheckResultStatus
	{
		Success,
		Warning,
		Error
	}

	public class ValidationFailedEventArgs<T> : EventArgs
	{
		public T Reason { get; internal set; }
	}

	public class FailureReasonValidator<TReason> : IValidator
	{
		public IValidator InnerValidator;
		private readonly Func<Combination, TReason> reason;

		public FailureReasonValidator(IValidator validator, Func<Combination, TReason> reason)
		{
			this.InnerValidator = validator;
			this.reason = reason;
		}

		//public event EventHandler<ImageMetadata> OnInvalidItem;
		public event EventHandler<ValidationFailedEventArgs<TReason>> OnValidationFailed;

		public bool Execute(Combination item)
		{
			var valid = InnerValidator.Execute(item);
			if (!valid)
			{
				OnValidationFailed?.Invoke(this, new ValidationFailedEventArgs<TReason> { Reason = reason(item) });
			}

			return valid;
		}
	}

	static class ValEx
	{
		public static FailureReasonValidator<TReason> WithFailureReason<TReason>(this IValidator validator, Func<Combination, TReason> reason)
		{
			return new FailureReasonValidator<TReason>(validator, reason);
		}
	}
}
