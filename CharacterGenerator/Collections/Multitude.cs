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
		private string _name = null;

		public string Name
		{
			get
			{
				if (_name == null)
				{
					_name = this
						.Select(x =>
									 GetType()
									.GetProperty("Id")
									.GetValue(x)
									.ToString())
												.JoinString("_");
				}

				return _name;
			}
		}

		public Multitude() : base()
		{

		}

		public Multitude(IEnumerable<T> collection) : base(collection)
		{

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
