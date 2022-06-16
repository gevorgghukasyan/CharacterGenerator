using CharacterGenerator.Entities;
using CharacterGenerator.Extensions;
using CharacterGenerator.Validators.Abstractions;
using CharacterGenerator.Validators.Implementations;
using System.Collections.Generic;

namespace CharacterGenerator.Validators
{
    class DarkMageValidatorsProvider : PersonValidatorsProvider
	{
		public DarkMageValidatorsProvider(IValidationContext validationContext) : base(validationContext)
		{
		}

		public override IEnumerable<IValidator> GetValidatorsInternal()
		{
			return new List<IValidator>()
			   //.Next(new MaxCountValidator("100", c => c.Armour.Id == ignore, 0, _validation, null))// darkmag
			   .Next(new MaxCountValidator("100", c => c.Armor.Id == "100", 165, _validation).WithFailureReason(c => c.Armor))// darkmag
			   .Next(new MaxCountValidator("101", c => c.Armor.Id == "101", 95, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("102", c => c.Armor.Id == "102", 45, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("103", c => c.Armor.Id == "103", 160, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("104", c => c.Armor.Id == "104", 90, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("105", c => c.Armor.Id == "105", 40, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("106", c => c.Armor.Id == "106", 150, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("107", c => c.Armor.Id == "107", 80, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("108", c => c.Armor.Id == "108", 30, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("109", c => c.Armor.Id == "109", 145, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("110", c => c.Armor.Id == "110", 75, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("111", c => c.Armor.Id == "111", 25, _validation).WithFailureReason(c => c.Armor))

			   .Next(new MaxCountValidator("Weapon_112", c => c.Weapon.Id == "Weapon_112", 190, _validation).WithFailureReason(c => c.Weapon))//darkmag
			   .Next(new MaxCountValidator("Weapon_113", c => c.Weapon.Id == "Weapon_113", 160, _validation).WithFailureReason(c => c.Weapon))
			   .Next(new MaxCountValidator("Weapon_114", c => c.Weapon.Id == "Weapon_114", 140, _validation).WithFailureReason(c => c.Weapon))
			   .Next(new MaxCountValidator("Weapon_115", c => c.Weapon.Id == "Weapon_115", 120, _validation).WithFailureReason(c => c.Weapon))
			   .Next(new MaxCountValidator("Weapon_116", c => c.Weapon.Id == "Weapon_116", 80, _validation).WithFailureReason(c => c.Weapon))
			   .Next(new MaxCountValidator("Weapon_117", c => c.Weapon.Id == "Weapon_117", 60, _validation).WithFailureReason(c => c.Weapon));
		}
	}
}
