using CharacterGenerator.Entities;
using CharacterGenerator.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
	public class ValidationResult
	{
		public bool Success { get; set; }
		public IValidator FailureReason { get; set; }
		public Combination Combination { get; set; }
	}
}
