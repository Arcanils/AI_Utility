using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IBehaviourCollection
	{
		IOptionCollection Options { get; }
		bool Add(IBehaviour behaviour);
		IBehaviour Create(string behaviourId);
		bool Contains(string behaviourId);
		void Clear();
	}
}
