using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IConsideration : IClone<IConsideration>
	{
		string NameId { get; }

		Utility DefaultUtility { get; set; }
		Utility Utility { get; }
		float Weight { get; set; }

		void Consider(IContext context);
	}
}
