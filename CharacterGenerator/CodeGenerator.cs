using CharacterGenerator.DAL;
using CharacterGenerator.Extensions;
using CharacterGenerator.Validators;
using CharacterGenerator.Validators.Abstractions;
using CharacterGenerator.Validators.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator
{
	public class CodeGenerator
	{
		public static void Run()
		{
			//var validation = new Validation();
			//var amuletMecGluxMaxCountVal = new MaxCountValidator(c => c.Amulet.Id == "Mec glux", 6, validation);

			//var validCombinations = validation.Execute(null, new IValidator[] {
			//	amuletMecGluxMaxCountVal,
			//});

			Func<string, int, string> valCodeFunc = (name, count) => $"new MaxCountValidator(\"{name}\", c => c.{name.Split('_')[0]}.Id == \"{name}\", {count}, validation)";

			var validatorsCode = DataAccess
				.GetExcelFile(@"C:\Users\C1\Desktop\xx1.xlsx")
				.Select(kv => valCodeFunc(kv.Key, int.Parse(kv.Value)))
				.Select(v => $".Next({v})")
				.JoinString(Environment.NewLine);
		}
	}
}
