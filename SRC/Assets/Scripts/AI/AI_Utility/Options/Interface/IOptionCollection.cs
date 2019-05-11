using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface IOptionCollection
	{
		IActionCollection Actions { get; }
		IConsiderationCollection Considerations { get; }

		bool Add(IOption option);
		IOption Create(string optionId);
		bool Contains(string optionId);
		void Clear();
	}
}
