using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IConsiderationCollection
	{
		void Add(IConsideration consideration);
		IConsideration Create(string considerationId);
		bool Contains(string considerationId);
		void Clear();
	}
}
