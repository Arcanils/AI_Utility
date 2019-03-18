using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IOption : ICompositeConsideration
	{
		IAction Action { get; }
		bool SetAction(string actionId);
	}
}
