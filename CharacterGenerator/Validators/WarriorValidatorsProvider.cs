using CharacterGenerator.Extensions;
using CharacterGenerator.Validators.Abstractions;
using CharacterGenerator.Validators.Implementations;
using System.Collections.Generic;

namespace CharacterGenerator.Validators
{
    class WarriorValidatorsProvider : PersonValidatorsProvider
	{
		public WarriorValidatorsProvider(IValidationContext validationContext) : base(validationContext)
		{
		}

		public override IEnumerable<IValidator> GetValidatorsInternal()
		{
			return new List<IValidator>()
				.Next(new MaxCountValidator("Armour_65", c => c.Armour.Id == "65", 165, _validation))
				.Next(new MaxCountValidator("Armour_66", c => c.Armour.Id == "66", 95, _validation))
				.Next(new MaxCountValidator("Armour_67x", c => c.Armour.Id == "67x", 45, _validation))
				.Next(new MaxCountValidator("Armour_67", c => c.Armour.Id == "67", 160, _validation))
				.Next(new MaxCountValidator("Armour_68", c => c.Armour.Id == "68", 90, _validation))
				.Next(new MaxCountValidator("Armour_69", c => c.Armour.Id == "69", 40, _validation))
				.Next(new MaxCountValidator("Armour_70", c => c.Armour.Id == "70", 150, _validation))
				.Next(new MaxCountValidator("Armour_71", c => c.Armour.Id == "71", 80, _validation))
				.Next(new MaxCountValidator("Armour_72", c => c.Armour.Id == "72", 30, _validation))
				.Next(new MaxCountValidator("Armour_73", c => c.Armour.Id == "73", 145, _validation))
				.Next(new MaxCountValidator("Armour_74", c => c.Armour.Id == "74", 75, _validation))
				.Next(new MaxCountValidator("Armour_75", c => c.Armour.Id == "75", 25, _validation))

				.Next(new MaxCountValidator("Weapon_76", c => c.Weapon.Id == "Weapon_76", 190, _validation))//warrior
				.Next(new MaxCountValidator("Weapon_77", c => c.Weapon.Id == "Weapon_77", 160, _validation))
				.Next(new MaxCountValidator("Weapon_78", c => c.Weapon.Id == "Weapon_78", 140, _validation))
				.Next(new MaxCountValidator("Weapon_79", c => c.Weapon.Id == "Weapon_79", 120, _validation))
				.Next(new MaxCountValidator("Weapon_80", c => c.Weapon.Id == "Weapon_80", 80, _validation))
				.Next(new MaxCountValidator("Weapon_81", c => c.Weapon.Id == "Weapon_81", 60, _validation));
		}

	}
}
