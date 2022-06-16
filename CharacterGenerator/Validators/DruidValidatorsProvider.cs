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
			   .Next(new MaxCountValidator("82", c => c.Armor.Id == "82", 165, _validation).WithFailureReason(c => c.Armor))// druid
			   .Next(new MaxCountValidator("83", c => c.Armor.Id == "83", 95, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("84", c => c.Armor.Id == "84", 45, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("85", c => c.Armor.Id == "85", 160, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("86", c => c.Armor.Id == "86", 90, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("87", c => c.Armor.Id == "87", 40, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("88", c => c.Armor.Id == "88", 150, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("89", c => c.Armor.Id == "89", 80, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("90", c => c.Armor.Id == "90", 30, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("91", c => c.Armor.Id == "91", 145, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("92", c => c.Armor.Id == "92", 75, _validation).WithFailureReason(c => c.Armor))
			   .Next(new MaxCountValidator("93", c => c.Armor.Id == "93", 25, _validation).WithFailureReason(c => c.Armor))
			   //  .Next(new MaxCountValidator("Armor_82", c => c.Armor.Id == "82", 165, _validation).WithFailureReason(c => c.Armor))// druid
			   //.Next(new MaxCountValidator("Armor_83", c => c.Armor.Id == "83", 95, _validation).WithFailureReason(c => c.Armor))
			   //.Next(new MaxCountValidator("Armor_84", c => c.Armor.Id == "84", 45, _validation).WithFailureReason(c => c.Armor))
			   //.Next(new MaxCountValidator("Armor_85", c => c.Armor.Id == "85", 160, _validation).WithFailureReason(c => c.Armor))
			   //.Next(new MaxCountValidator("Armor_86", c => c.Armor.Id == "86", 90, _validation).WithFailureReason(c => c.Armor))
			   //.Next(new MaxCountValidator("Armor_87", c => c.Armor.Id == "87", 40, _validation).WithFailureReason(c => c.Armor))
			   //.Next(new MaxCountValidator("Armor_88", c => c.Armor.Id == "88", 150, _validation).WithFailureReason(c => c.Armor))
			   //.Next(new MaxCountValidator("Armor_89", c => c.Armor.Id == "89", 80, _validation).WithFailureReason(c => c.Armor))
			   //.Next(new MaxCountValidator("Armor_90", c => c.Armor.Id == "90", 30, _validation).WithFailureReason(c => c.Armor))
			   //.Next(new MaxCountValidator("Armor_91", c => c.Armor.Id == "91", 145, _validation).WithFailureReason(c => c.Armor))
			   //.Next(new MaxCountValidator("Armor_92", c => c.Armor.Id == "92", 75, _validation).WithFailureReason(c => c.Armor))
			   //.Next(new MaxCountValidator("Armor_93", c => c.Armor.Id == "93", 25, _validation).WithFailureReason(c => c.Armor))

			   .Next(new MaxCountValidator("Weapon_94", c => c.Weapon.Id == "Weapon_94", 190, _validation).WithFailureReason(c => c.Weapon))// druid
			   .Next(new MaxCountValidator("Weapon_95", c => c.Weapon.Id == "Weapon_95", 160, _validation).WithFailureReason(c => c.Weapon))
			   .Next(new MaxCountValidator("Weapon_96", c => c.Weapon.Id == "Weapon_96", 140, _validation).WithFailureReason(c => c.Weapon))
			   .Next(new MaxCountValidator("Weapon_97", c => c.Weapon.Id == "Weapon_97", 120, _validation).WithFailureReason(c => c.Weapon))
			   .Next(new MaxCountValidator("Weapon_98", c => c.Weapon.Id == "Weapon_98", 80, _validation).WithFailureReason(c => c.Weapon))
			   .Next(new MaxCountValidator("Weapon_99", c => c.Weapon.Id == "Weapon_99", 60, _validation).WithFailureReason(c => c.Weapon));
		}
	}
}
