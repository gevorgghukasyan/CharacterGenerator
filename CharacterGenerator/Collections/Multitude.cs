using CharacterGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Collections
{
	public class Multitude<T> : List<T>
	{
        private readonly Func<T, string> _idSelector;

        public string Name => this.Select(_idSelector).JoinString("_");

        public Multitude(Func<T, string> idSelector) : this(Enumerable.Empty<T>(), idSelector)
		{

		}

		public Multitude(IEnumerable<T> collection, Func<T, string> idSelector) : base(collection)
		{
            _idSelector = idSelector;
        }
		//public Multitude(IEnumerable<T> collection)
		//{
		//	if (collection == null)
		//	{
		//		throw new ArgumentNullException(nameof(collection));
		//	}

		//	ICollection<T> collection2 = collection as ICollection<T>;
		//	if (collection2 != null)
		//	{
		//		int count = collection2.Count;
		//		if (count == 0)
		//		{
		//			_items = _emptyArray;
		//			return;
		//		}

		//		_items = new T[count];
		//		collection2.CopyTo(_items, 0);
		//		_size = count;
		//		return;
		//	}

		//	_size = 0;
		//	_items = _emptyArray;
		//	foreach (T item in collection)
		//	{
		//		Add(item);
		//	}
		//}
	}
}
