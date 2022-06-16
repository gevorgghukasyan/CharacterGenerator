using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.UI
{
	public interface IUIInputValidator
	{
		bool Validate(string input);
	}

	public class UIInputValidator : IUIInputValidator
	{
		public bool Validate(string input)
		{
			throw new NotImplementedException();
		}

//		public void GetDirectories()
//		{
//			Console.WriteLine("Write Root Path");

//			System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

//			This method assumes that the application has discovery permissions

//			 for all folders under the specified path.
//			IEnumerable < System.IO.FileInfo > fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

//			string searchTerm = @"Visual Studio";

//			Search the contents of each file. 

//			 A regular expression created with the RegEx class
//			 could be used instead of the Contains method.
//			 queryMatchingFiles is an IEnumerable<string>.
//			var queryMatchingFiles =
//				from file in fileList
//				where file.Extension == ".htm"
//				let fileText = GetFileText(file.FullName)
//				where fileText.Contains(searchTerm)
//				select file.FullName;

//		Execute the query.
//	   Console.WriteLine("The term \"{0}\" was found in:", searchTerm);
//            foreach (string filename in queryMatchingFiles)
//            {
//                Console.WriteLine(filename);
//            }
//}
	}
}
