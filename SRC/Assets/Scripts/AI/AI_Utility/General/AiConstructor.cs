using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public abstract class AiConstructor
	{
		public IAiCollection AIs { get; protected set; }
		public IActionCollection Actions { get { return AIs.Actions; } }
		public IConsiderationCollection Considerations { get { return AIs.Considerations; } }
		public IOptionCollection Options { get { return AIs.Options; } }
		public IBehaviourCollection Behaviours { get { return AIs.Behaviours; } }

		public IUtilityAi Create(string aiId)
		{
			return AIs.CreateAi(aiId);
		}
	}
}
