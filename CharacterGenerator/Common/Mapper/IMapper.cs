using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Common.Mapper
{
	public interface IMapper<T1, T2>
	{
		T2 Map(T1 t);
	}

	public interface IMapper<T1, T2, T3>
	{
		T3 Map(T1 t1, T2 t2);
	}
}
