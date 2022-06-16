using CharacterGenerator.Entities;
using System;
namespace CharacterGenerator
{
	public class ConditionalModifier : IModifier<Combination>
	{
		private readonly Func<Combination, bool> _matchCondition;
		private readonly Action<Combination> _action;
		public ConditionalModifier(Func<Combination, bool> matchCondition, Action<Combination> action)
		{
			_matchCondition = matchCondition;
			_action = action;
		}

		public Combination Execute(Combination t)
		{
			if (_matchCondition(t))
			{
				_action(t);
			}
			return t;
		}
	}
}
