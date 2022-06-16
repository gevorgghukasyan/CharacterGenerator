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

		public List<IValidator> GetCommonValidators()
		{
			return new MaxCountValidator("empty", c => false, 1, _validation)

				.Next(new TagMatchValidator(c => c.Person, c => c.Armour))
				.Next(new TagMatchValidator(c => c.Person, c => c.Weapon))
				.Next(new TagMatchValidator(c => c.Amulet, c => c.Piercing))
				.Next(new IncompatibleDirectoryValidator())
				.Next(new IncompatibleImageValidator())
				.Next(new MaxCountValidator("bg_gray", c => c.Background.Id == "bg_gray", 10000, _validation))
				//.Next(new MaxCountValidator("bg_gray", c => c.Background.Id == "bg_gray", 3150, _validation))
				.Next(new MaxCountValidator("bg_blue", c => c.Background.Id == "bg_blue", 0, _validation))


				.Next(new MaxCountValidator("Eye_1", c => c.Eye.Id == "Eye_1", 221, _validation))
				.Next(new MaxCountValidator("Eye_2", c => c.Eye.Id == "Eye_2", 1777, _validation))
				.Next(new MaxCountValidator("Eye_3", c => c.Eye.Id == "Eye_3", 666, _validation))
				.Next(new MaxCountValidator("Eye_4", c => c.Eye.Id == "Eye_4", 1111, _validation))
				.Next(new MaxCountValidator("Eye_5", c => c.Eye.Id == "Eye_5", 154, _validation))
				.Next(new MaxCountValidator("Eye_6", c => c.Eye.Id == "Eye_6", 444, _validation))
				.Next(new MaxCountValidator("Eye_7", c => c.Eye.Id == "Eye_7", 35, _validation))
				.Next(new MaxCountValidator("Eye_8", c => c.Eye.Id == "Eye_8", 35, _validation))
				.Next(new MaxCountValidator("EyeSuperrare_1", c => c.Eye.Id == "Superrare_1", 14, _validation))
				.Next(new MaxCountValidator("EyeSuperrare_2", c => c.Eye.Id == "Superrare_2", 15, _validation))
				.Next(new MaxCountValidator("EyeSuperrare_3", c => c.Eye.Id == "Superrare_3", 15, _validation))
				.Next(new MaxCountValidator("Hat_9", c => c.Hat.Id == "Hat_9", 100, _validation))
				.Next(new MaxCountValidator("Hat_10", c => c.Hat.Id == "Hat_10", 100, _validation))
				.Next(new MaxCountValidator("Hat_11", c => c.Hat.Id == "Hat_11", 100, _validation))
				.Next(new MaxCountValidator("Hat_12", c => c.Hat.Id == "Hat_12", 25, _validation))
				.Next(new MaxCountValidator("Hat_13", c => c.Hat.Id == "Hat_13", 100, _validation))
				.Next(new MaxCountValidator("Hat_14", c => c.Hat.Id == "Hat_14", 50, _validation))
				.Next(new MaxCountValidator("Hat_15", c => c.Hat.Id == "Hat_15", 50, _validation))
				.Next(new MaxCountValidator("Hat_16", c => c.Hat.Id == "Hat_16", 25, _validation))
				.Next(new MaxCountValidator("Hat_17", c => c.Hat.Id == "Hat_17", 100, _validation))
				.Next(new MaxCountValidator("Hat_18", c => c.Hat.Id == "Hat_18", 25, _validation))
				.Next(new MaxCountValidator("Hat_19", c => c.Hat.Id == "Hat_19", 25, _validation))
				.Next(new MaxCountValidator("Hat_20", c => c.Hat.Id == "Hat_20", 20, _validation))
				.Next(new MaxCountValidator("Hat_21", c => c.Hat.Id == "Hat_21", 50, _validation))
				.Next(new MaxCountValidator("Hat_22", c => c.Hat.Id == "Hat_22", 15, _validation))
				.Next(new MaxCountValidator("Hat_23", c => c.Hat.Id == "Hat_23", 15, _validation))
				.Next(new MaxCountValidator("Amulet_24", c => c.Amulet.Id == "Amulet_24", 120, _validation))
				.Next(new MaxCountValidator("Amulet_25", c => c.Amulet.Id == "Amulet_25", 120, _validation))
				.Next(new MaxCountValidator("Amulet_26", c => c.Amulet.Id == "Amulet_26", 120, _validation))
				.Next(new MaxCountValidator("Amulet_27", c => c.Amulet.Id == "Amulet_27", 120, _validation))
				.Next(new MaxCountValidator("Amulet_28", c => c.Amulet.Id == "Amulet_28", 120, _validation))
				.Next(new MaxCountValidator("Amulet_29", c => c.Amulet.Id == "Amulet_29", 50, _validation))
				.Next(new MaxCountValidator("Amulet_30", c => c.Amulet.Id == "Amulet_30", 120, _validation))
				.Next(new MaxCountValidator("Amulet_31", c => c.Amulet.Id == "Amulet_31", 120, _validation))
				.Next(new MaxCountValidator("Amulet_32", c => c.Amulet.Id == "Amulet_32", 120, _validation))
				.Next(new MaxCountValidator("Amulet_33", c => c.Amulet.Id == "Amulet_33", 120, _validation))
				.Next(new MaxCountValidator("Amulet_34", c => c.Amulet.Id == "Amulet_34", 120, _validation))
				.Next(new MaxCountValidator("Amulet_35", c => c.Amulet.Id == "Amulet_35", 120, _validation))
				.Next(new MaxCountValidator("Amulet_36", c => c.Amulet.Id == "Amulet_36", 120, _validation))
				.Next(new MaxCountValidator("Amulet_37", c => c.Amulet.Id == "Amulet_37", 120, _validation))
				.Next(new MaxCountValidator("Amulet_38", c => c.Amulet.Id == "Amulet_38", 120, _validation))
				.Next(new MaxCountValidator("Amulet_39", c => c.Amulet.Id == "Amulet_39", 120, _validation))
				.Next(new MaxCountValidator("Amulet_40", c => c.Amulet.Id == "Amulet_40", 120, _validation))
				.Next(new MaxCountValidator("Amulet_41", c => c.Amulet.Id == "Amulet_41", 120, _validation))
				.Next(new MaxCountValidator("Amulet_42", c => c.Amulet.Id == "Amulet_42", 60, _validation))
				.Next(new MaxCountValidator("Amulet_43", c => c.Amulet.Id == "Amulet_43", 50, _validation))
				.Next(new MaxCountValidator("Piercing_44", c => c.Piercing.Id == "Piercing_44", 225, _validation))
				.Next(new MaxCountValidator("Piercing_45", c => c.Piercing.Id == "Piercing_45", 225, _validation))
				.Next(new MaxCountValidator("Piercing_46", c => c.Piercing.Id == "Piercing_46", 225, _validation))
				.Next(new MaxCountValidator("Piercing_47", c => c.Piercing.Id == "Piercing_47", 275, _validation))
				.Next(new MaxCountValidator("Piercing_48", c => c.Piercing.Id == "Piercing_48", 225, _validation))
				.Next(new MaxCountValidator("Piercing_49", c => c.Piercing.Id == "Piercing_49", 225, _validation))
				.Next(new MaxCountValidator("Piercing_50", c => c.Piercing.Id == "Piercing_50", 225, _validation))
				.Next(new MaxCountValidator("Piercing_51", c => c.Piercing.Id == "Piercing_51", 125, _validation))
				.Next(new MaxCountValidator("Piercing_52", c => c.Piercing.Id == "Piercing_52", 225, _validation))
				.Next(new MaxCountValidator("Piercing_53", c => c.Piercing.Id == "Piercing_53", 225, _validation))
				.Next(new MaxCountValidator("Mount_54", c => c.Mouth.Id == "Mount_54", 125, _validation))
				.Next(new MaxCountValidator("Mouth_55", c => c.Mouth.Id == "Mouth_55", 100, _validation))
				.Next(new MaxCountValidator("Mount_56", c => c.Mouth.Id == "Mount_56", 100, _validation))
				.Next(new MaxCountValidator("Mouth_57", c => c.Mouth.Id == "Mouth_57", 125, _validation))
				.Next(new MaxCountValidator("Mount_58", c => c.Mouth.Id == "Mount_58", 100, _validation))
				.Next(new MaxCountValidator("Mouth_59", c => c.Mouth.Id == "Mouth_59", 100, _validation))
				.Next(new MaxCountValidator("Mount_60", c => c.Mouth.Id == "Mount_60", 75, _validation))
				.Next(new MaxCountValidator("Mouth_61", c => c.Mouth.Id == "Mouth_61", 75, _validation))
				//.Next(new MaxCountValidator("bg_gray", c => c.Background.Id == "bg_gray", 3150, _validation))
				//.Next(new MaxCountValidator("bg_blue", c => c.Background.Id == "bg_blue", 1350, _validation))

				;

		}
	}
}
