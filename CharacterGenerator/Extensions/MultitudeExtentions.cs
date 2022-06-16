using CharacterGenerator.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Extensions
{
	public static class MultitudeExtentions
	{
		public static Multitude<T> ToMultitude<T>(this IEnumerable<T> source, Func<T, string> idSelector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			return new Multitude<T>(source, idSelector);
		}
	}
}
