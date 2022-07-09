using CharacterGenerator.Extensions;
using CharacterGenerator.Validators.Abstractions;
using CharacterGenerator.Validators.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Validators
{
	interface IPersonValidatorsProvider
	{
		List<IValidator> GetValidators();
	}

	internal abstract class PersonValidatorsProvider : IPersonValidatorsProvider
	{
		protected readonly IValidationContext _validation;

		public PersonValidatorsProvider(IValidationContext validationContext)
		{
			_validation = validationContext;
		}

		public List<IValidator> GetValidators()
		{
			var validators = GetCommonValidators();
			validators.AddRange(GetValidatorsInternal());

			return validators;
		}

		public abstract IEnumerable<IValidator> GetValidatorsInternal();


		private static List<IValidator> _commons = null;
		public List<IValidator> GetCommonValidators()
		{
			int x = 1;
			_commons = _commons ?? new MaxCountValidator("empty", c => false, 1, _validation)

				//.Next(new TagMatchValidator(c => c.Person, c => c.Armour))
				//.Next(new TagMatchValidator(c => c.Person, c => c.Weapon))
				//.Next(new TagMatchValidator(c => c.Amulet, c => c.Piercing))
				.Next(new AmuletArmorExchange())
				.Next(new IncompatibleDirectoryValidator())
				.Next(new IncompatibleImageValidator())
				.Next(new MaxCountValidator("bg_gray", c => c.Background.Id == "bg_gray", 4500, _validation).WithFailureReason(c => c.Background))
				//.Next(new MaxCountValidator("bg_gray", c => c.Background.Id == "bg_gray", 3150, _validation))
				//.Next(new MaxCountValidator("bg_blue", c => c.Background.Id == "bg_blue", 1350, _validation).WithFailureReason(c => c.Background))

				.Next(new MaxCountValidator("Eye_1", c => c.Eye.Id == "Eye_1", x * 243, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("Eye_2", c => c.Eye.Id == "Eye_2", x * 1955, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("Eye_3", c => c.Eye.Id == "Eye_3", x * 733, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("Eye_4", c => c.Eye.Id == "Eye_4", x * 1222, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("Eye_5", c => c.Eye.Id == "Eye_5", x * 169, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("Eye_6", c => c.Eye.Id == "Eye_6", x * 491, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("Eye_7", c => c.Eye.Id == "Eye_7", x * 44, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("Eye_8", c => c.Eye.Id == "Eye_8", x * 44, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("EyeSuperrare_1", c => c.Eye.Id == "Superrare_1", 17 - 17, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("EyeSuperrare_2", c => c.Eye.Id == "Superrare_2", 17 - 17, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("EyeSuperrare_3", c => c.Eye.Id == "Superrare_3", 17 - 17, _validation).WithFailureReason(c => c.Eye))
				.Next(new MaxCountValidator("Hat_9", c => c.Hat.Id == "Hat_9", x * 110, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_10", c => c.Hat.Id == "Hat_10", x * 110, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_11", c => c.Hat.Id == "Hat_11", x * 110, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_12", c => c.Hat.Id == "Hat_12", x * 28, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_13", c => c.Hat.Id == "Hat_13", x * 110, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_14", c => c.Hat.Id == "Hat_14", x * 55, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_15", c => c.Hat.Id == "Hat_15", x * 55, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_16", c => c.Hat.Id == "Hat_16", x * 28, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_17", c => c.Hat.Id == "Hat_17", x * 110, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_18", c => c.Hat.Id == "Hat_18", x * 28, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_19", c => c.Hat.Id == "Hat_19", x * 28, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_20", c => c.Hat.Id == "Hat_20", x * 22, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_21", c => c.Hat.Id == "Hat_21", x * 55, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_22", c => c.Hat.Id == "Hat_22", x * 17, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Hat_23", c => c.Hat.Id == "Hat_23", x * 17, _validation).WithFailureReason(c => c.Hat))
				.Next(new MaxCountValidator("Amulet_24", c => c.Amulet.Id == "Amulet_24", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_25", c => c.Amulet.Id == "Amulet_25", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_26", c => c.Amulet.Id == "Amulet_26", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_27", c => c.Amulet.Id == "Amulet_27", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_28", c => c.Amulet.Id == "Amulet_28", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_29", c => c.Amulet.Id == "Amulet_29", x * 55, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_30", c => c.Amulet.Id == "Amulet_30", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_31", c => c.Amulet.Id == "Amulet_31", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_32", c => c.Amulet.Id == "Amulet_32", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_33", c => c.Amulet.Id == "Amulet_33", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_34", c => c.Amulet.Id == "Amulet_34", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_35", c => c.Amulet.Id == "Amulet_35", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_36", c => c.Amulet.Id == "Amulet_36", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_37", c => c.Amulet.Id == "Amulet_37", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_38", c => c.Amulet.Id == "Amulet_38", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_39", c => c.Amulet.Id == "Amulet_39", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_40", c => c.Amulet.Id == "Amulet_40", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_41", c => c.Amulet.Id == "Amulet_41", x * 132, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_42", c => c.Amulet.Id == "Amulet_42", x * 66, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Amulet_43", c => c.Amulet.Id == "Amulet_43", x * 55, _validation).WithFailureReason(c => c.Amulet))
				.Next(new MaxCountValidator("Piercing_44", c => c.Piercing.Id == "Piercing_44", x * 248, _validation).WithFailureReason(c => c.Piercing))
				.Next(new MaxCountValidator("Piercing_45", c => c.Piercing.Id == "Piercing_45", x * 248, _validation).WithFailureReason(c => c.Piercing))
				.Next(new MaxCountValidator("Piercing_46", c => c.Piercing.Id == "Piercing_46", x * 248, _validation).WithFailureReason(c => c.Piercing))
				.Next(new MaxCountValidator("Piercing_47", c => c.Piercing.Id == "Piercing_47", x * 303, _validation).WithFailureReason(c => c.Piercing))
				.Next(new MaxCountValidator("Piercing_48", c => c.Piercing.Id == "Piercing_48", x * 248, _validation).WithFailureReason(c => c.Piercing))
				.Next(new MaxCountValidator("Piercing_49", c => c.Piercing.Id == "Piercing_49", x * 248, _validation).WithFailureReason(c => c.Piercing))
				.Next(new MaxCountValidator("Piercing_50", c => c.Piercing.Id == "Piercing_50", x * 248, _validation).WithFailureReason(c => c.Piercing))
				.Next(new MaxCountValidator("Piercing_51", c => c.Piercing.Id == "Piercing_51", x * 138, _validation).WithFailureReason(c => c.Piercing))
				.Next(new MaxCountValidator("Piercing_52", c => c.Piercing.Id == "Piercing_52", x * 248, _validation).WithFailureReason(c => c.Piercing))
				.Next(new MaxCountValidator("Piercing_53", c => c.Piercing.Id == "Piercing_53", x * 248, _validation).WithFailureReason(c => c.Piercing))
				.Next(new MaxCountValidator("Mouth_54", c => c.Mouth.Id == "Mouth_54", x * 138, _validation).WithFailureReason(c => c.Mouth))
				.Next(new MaxCountValidator("Mouth_55", c => c.Mouth.Id == "Mouth_55", x * 110, _validation).WithFailureReason(c => c.Mouth))
				.Next(new MaxCountValidator("Mouth_56", c => c.Mouth.Id == "Mouth_56", x * 110, _validation).WithFailureReason(c => c.Mouth))
				.Next(new MaxCountValidator("Mouth_57", c => c.Mouth.Id == "Mouth_57", x * 138, _validation).WithFailureReason(c => c.Mouth))
				.Next(new MaxCountValidator("mouth_58", c => c.Mouth.Id == "mouth_58", x * 116, _validation).WithFailureReason(c => c.Mouth))
				.Next(new MaxCountValidator("Mouth_59", c => c.Mouth.Id == "Mouth_59", x * 116, _validation).WithFailureReason(c => c.Mouth))
				.Next(new MaxCountValidator("Mouth_60", c => c.Mouth.Id == "Mouth_60", x * 94, _validation).WithFailureReason(c => c.Mouth))
				.Next(new MaxCountValidator("mouth_61", c => c.Mouth.Id == "mouth_61", x * 94, _validation).WithFailureReason(c => c.Mouth))
				//.Next(new MaxCountValidator("bg_gray", c => c.Background.Id == "bg_gray", 3150, _validation))
				//.Next(new MaxCountValidator("bg_blue", c => c.Background.Id == "bg_blue", 1350, _validation))

				;

			return _commons;
		}
	}
}
