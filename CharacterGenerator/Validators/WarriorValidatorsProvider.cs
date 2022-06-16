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
				.Next(new MaxCountValidator("65", c => c.Armor.Id == "65", 165, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("66", c => c.Armor.Id == "66", 95, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("67x", c => c.Armor.Id =="67x", 45, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("67", c => c.Armor.Id == "67", 160, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("68", c => c.Armor.Id == "68", 90, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("69", c => c.Armor.Id == "69", 40, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("70", c => c.Armor.Id == "70", 150, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("71", c => c.Armor.Id == "71", 80, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("72", c => c.Armor.Id == "72", 30, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("73", c => c.Armor.Id == "73", 145, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("74", c => c.Armor.Id == "74", 75, _validation).WithFailureReason(c => c.Armor))
				.Next(new MaxCountValidator("75", c => c.Armor.Id == "75", 25, _validation).WithFailureReason(c => c.Armor))

				.Next(new MaxCountValidator("Weapon_76", c => c.Weapon.Id == "Weapon_76", 190, _validation).WithFailureReason(c => c.Weapon))//warrior
				.Next(new MaxCountValidator("Weapon_77", c => c.Weapon.Id == "Weapon_77", 160, _validation).WithFailureReason(c => c.Weapon))
				.Next(new MaxCountValidator("Weapon_78", c => c.Weapon.Id == "Weapon_78", 140, _validation).WithFailureReason(c => c.Weapon))
				.Next(new MaxCountValidator("Weapon_79", c => c.Weapon.Id == "Weapon_79", 120, _validation).WithFailureReason(c => c.Weapon))
				.Next(new MaxCountValidator("Weapon_80", c => c.Weapon.Id == "Weapon_80", 80, _validation).WithFailureReason(c => c.Weapon))
				.Next(new MaxCountValidator("Weapon_81", c => c.Weapon.Id == "Weapon_81", 60, _validation).WithFailureReason(c => c.Weapon));
		}
	}
}
