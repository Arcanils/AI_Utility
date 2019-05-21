using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public class Consideration : IConsideration
	{
		private Utility m_utility;
		private

		public Consideration(Consideration otherConsideration)
		{

		}

		#region IConsideration Implem

		string IConsideration.NameId { get { return ""; } }
		Utility IConsideration.DefaultUtility { get; set; }
		Utility IConsideration.Utility { get { return m_utility; } }
		float IConsideration.Weight { get; set; }

		IConsideration IClone<IConsideration>.Clone()
		{
			return new Consideration(this);
		}

		void IConsideration.Consider(IContext context)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
