using AI.AI_Utility.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IActionCollection
	{
		bool Add(IAction action, IdInfoIndex id);
		IAction Create(IdInfoIndex id);
		bool Contains(IdInfoIndex id);
		void Clear();
	}
}
