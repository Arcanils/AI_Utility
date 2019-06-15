using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public class DynamicConsideration : IConsideration
	{
		private Utility m_utility;
		private InfoId m_id;
		private Info.ConsiderationInfo m_info;

		private readonly ConsiderationToGet m_callback;

		public DynamicConsideration(InfoId id, ConsiderationToGet callback)
		{
			m_utility = new Utility(0f, 1f);

			m_id = id;
			m_callback = callback;
		}

		public DynamicConsideration(DynamicConsideration otherConsideration)
		{

		}

		#region IConsideration Implem

		string IConsideration.NameId { get { return ""; } }
		Utility IConsideration.DefaultUtility { get; set; }
		Utility IConsideration.Utility { get { return m_utility; } }
		float IConsideration.Weight { get; set; }

		IConsideration IClone<IConsideration>.Clone()
		{
			return new DynamicConsideration(this);
		}

		void IConsideration.Consider(IContext context)
		{
			var value = m_callback(context);
			m_utility.Value = value;
		}

		void IConsideration.Initialize(Info.ConsiderationInfo info)
		{
			m_info = info;
		}



		#endregion
	}
}
