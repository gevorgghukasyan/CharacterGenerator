using CharacterGenerator.Entities;
using CharacterGenerator.Validators.Abstractions;
using System.Collections.Generic;
namespace CharacterGenerator
{
	public class PersonData
	{
		public List<IValidator> validators { get; set; }
		public List<List<ImageMetadata>> AttributeLists { get; set; }
	}
}
