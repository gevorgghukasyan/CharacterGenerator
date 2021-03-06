using CharacterGenerator.Entities;
using CharacterGenerator.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CharacterGenerator
{
	public static class Helper
	{
		public static IEnumerable<List<T>> GetAllCombinations<T>(List<List<T>> domains)
		{
			return GetCombinations(domains/*.Where(x => x.Count > 0).ToList()*/, new List<T>());
		}

		public static IEnumerable<List<T>> GetCombinations<T>(List<List<T>> domains, List<T> vector)
		{
			int count = 0;
			if (domains.Count == vector.Count)
			{
				yield return vector;
				yield break;
				Console.WriteLine(count++);
			}
			foreach (var value in domains[vector.Count])
			{
				var newVector = vector.ToList();
				newVector.Add(value);
				foreach (var item in GetCombinations(domains, newVector))
				{
					yield return item;
				}
			}
		}
	}
}
