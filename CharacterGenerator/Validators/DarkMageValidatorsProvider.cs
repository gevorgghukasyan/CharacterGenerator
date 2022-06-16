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
			   .Next(new MaxCountValidator("100", c => c.Armour.Id == "100", 165, _validation))// darkmag
			   .Next(new MaxCountValidator("101", c => c.Armour.Id == "101", 95, _validation))
			   .Next(new MaxCountValidator("102", c => c.Armour.Id == "102", 45, _validation))
			   .Next(new MaxCountValidator("103", c => c.Armour.Id == "103", 160, _validation))
			   .Next(new MaxCountValidator("104", c => c.Armour.Id == "104", 90, _validation))
			   .Next(new MaxCountValidator("105", c => c.Armour.Id == "105", 40, _validation))
			   .Next(new MaxCountValidator("106", c => c.Armour.Id == "106", 150, _validation))
			   .Next(new MaxCountValidator("107", c => c.Armour.Id == "107", 80, _validation))
			   .Next(new MaxCountValidator("108", c => c.Armour.Id == "108", 30, _validation))
			   .Next(new MaxCountValidator("109", c => c.Armour.Id == "109", 145, _validation))
			   .Next(new MaxCountValidator("110", c => c.Armour.Id == "110", 75, _validation))
			   .Next(new MaxCountValidator("111", c => c.Armour.Id == "111", 25, _validation))

			   .Next(new MaxCountValidator("Weapon_112", c => c.Weapon.Id == "Weapon_112", 190, _validation))//darkmag
			   .Next(new MaxCountValidator("Weapon_113", c => c.Weapon.Id == "Weapon_113", 160, _validation))
			   .Next(new MaxCountValidator("Weapon_114", c => c.Weapon.Id == "Weapon_114", 140, _validation))
			   .Next(new MaxCountValidator("Weapon_115", c => c.Weapon.Id == "Weapon_115", 120, _validation))
			   .Next(new MaxCountValidator("Weapon_116", c => c.Weapon.Id == "Weapon_116", 80, _validation))
			   .Next(new MaxCountValidator("Weapon_117", c => c.Weapon.Id == "Weapon_117", 60, _validation));
		}
	}
}
