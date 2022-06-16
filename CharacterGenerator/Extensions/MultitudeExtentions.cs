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
		public static Multitude<TSource> ToMultitude<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			return new Multitude<TSource>(source);
		}
	}
}
