using AI.AI_Utility.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IConsiderationCollection
	{
		bool Add(IConsideration consideration, IdInfoIndex id);
		IConsideration Create(IdInfoIndex id);
		bool Contains(IdInfoIndex id);
		void Clear();
	}
}
