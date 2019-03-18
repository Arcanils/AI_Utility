using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IBehaviour : ICompositeConsideration
	{
		ISelector Selector { get; set; }
		bool AddOption(string optionId);
		IAction Select(IContext context);
	}
}
