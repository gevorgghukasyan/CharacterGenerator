using CharacterGenerator.Extensions;
using CharacterGenerator.Validators.Abstractions;
using CharacterGenerator.Validators.Implementations;
using System.Collections.Generic;

namespace CharacterGenerator.Validators
{
    class DruidValidatorsProvider : PersonValidatorsProvider
	{
		public DruidValidatorsProvider(IValidationContext validationContext) : base(validationContext)
		{
		}

		public override IEnumerable<IValidator> GetValidatorsInternal()
		{
			return new List<IValidator>()
			   .Next(new MaxCountValidator("Armour_82", c => c.Armour.Id == "82", 165, _validation))// druid
			   .Next(new MaxCountValidator("Armour_83", c => c.Armour.Id == "83", 95, _validation))
			   .Next(new MaxCountValidator("Armour_84", c => c.Armour.Id == "84", 45, _validation))
			   .Next(new MaxCountValidator("Armour_85", c => c.Armour.Id == "85", 160, _validation))
			   .Next(new MaxCountValidator("Armour_86", c => c.Armour.Id == "86", 90, _validation))
			   .Next(new MaxCountValidator("Armour_87", c => c.Armour.Id == "87", 40, _validation))
			   .Next(new MaxCountValidator("Armour_88", c => c.Armour.Id == "88", 150, _validation))
			   .Next(new MaxCountValidator("Armour_89", c => c.Armour.Id == "89", 80, _validation))
			   .Next(new MaxCountValidator("Armour_90", c => c.Armour.Id == "90", 30, _validation))
			   .Next(new MaxCountValidator("Armour_91", c => c.Armour.Id == "91", 145, _validation))
			   .Next(new MaxCountValidator("Armour_92", c => c.Armour.Id == "92", 75, _validation))
			   .Next(new MaxCountValidator("Armour_93", c => c.Armour.Id == "93", 25, _validation))

			   .Next(new MaxCountValidator("Weapon_94", c => c.Weapon.Id == "Weapon_94", 190, _validation))// druid
			   .Next(new MaxCountValidator("Weapon_95", c => c.Weapon.Id == "Weapon_95", 160, _validation))
			   .Next(new MaxCountValidator("Weapon_96", c => c.Weapon.Id == "Weapon_96", 140, _validation))
			   .Next(new MaxCountValidator("Weapon_97", c => c.Weapon.Id == "Weapon_97", 120, _validation))
			   .Next(new MaxCountValidator("Weapon_98", c => c.Weapon.Id == "Weapon_98", 80, _validation))
			   .Next(new MaxCountValidator("Weapon_99", c => c.Weapon.Id == "Weapon_99", 60, _validation));
		}
	}
}
