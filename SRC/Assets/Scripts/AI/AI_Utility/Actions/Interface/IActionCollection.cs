using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IActionCollection
	{
		bool Add(IAction action);
		IAction Create();
		bool Contains(string actionId);
		void Clear();
	}
}
