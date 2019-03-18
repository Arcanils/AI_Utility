using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface ICompositeConsideration : IConsideration
	{
		bool AddConsideration(IConsideration consideration);
		bool AddConsideration(string considerationId);
	}
}
