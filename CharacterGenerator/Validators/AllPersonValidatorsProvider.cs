using CharacterGenerator.Validators.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace CharacterGenerator.Validators
{
    internal class AllPersonValidatorsProvider : PersonValidatorsProvider
    {
		private PersonValidatorsProvider[] _personValidatorsProviders;

        public AllPersonValidatorsProvider(IValidationContext validationContext) : base(validationContext)
        {
			_personValidatorsProviders = new PersonValidatorsProvider[]
			{
				new WarriorValidatorsProvider(validationContext),
				new DruidValidatorsProvider(validationContext),
				new DarkMageValidatorsProvider(validationContext),
			};
		}

        public override IEnumerable<IValidator> GetValidatorsInternal()
        {
			return _personValidatorsProviders.SelectMany(vp => vp.GetValidatorsInternal());
        }
    }
}
