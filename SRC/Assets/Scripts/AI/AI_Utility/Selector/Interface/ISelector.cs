using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public interface ISelector
	{
		int Select(ICollection<Utility> elements);
	}
}
