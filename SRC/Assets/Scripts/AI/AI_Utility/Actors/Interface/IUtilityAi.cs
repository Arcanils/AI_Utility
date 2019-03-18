using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IUtilityAi
	{
		string NameId { get; }
		ISelector Selector { get; set; }
		bool AddBehaviour(string behaviourId);
		bool RemoveBehaviour(string behaviourId);
		IAction Select(IContext context);
	}
}
