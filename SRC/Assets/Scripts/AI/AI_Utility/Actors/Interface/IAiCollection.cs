using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IAiCollection
	{
		IActionCollection Actions { get; }
		IConsiderationCollection Considerations { get; }
		IOptionCollection Options { get; }
		IBehaviourCollection Behaviours { get; }

		bool Add(IUtilityAi ai);
		IUtilityAi GetAi(string aiId);
		IUtilityAi CreateAi(string aiId);
		bool Contains(string aiId);
		void Clear();

	}
}
