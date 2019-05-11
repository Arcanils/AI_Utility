using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public class ConsiderationCollection : IConsiderationCollection
	{
		private Dictionary<string, IConsideration> m_considerations;

		public ConsiderationCollection()
		{
			m_considerations = new Dictionary<string, IConsideration>();
		}

		public bool Add(IConsideration consideration)
		{
			if (consideration == null || consideration.Equals(null))
				return false;

			var id = consideration.NameId;
			if (Contains(id))
				return false;

			m_considerations.Add(id, consideration);

			return true;
		}

		public void Clear()
		{
			m_considerations.Clear();
		}

		public bool Contains(string id)
		{
			return m_considerations.ContainsKey(id);
		}

		public IConsideration Create(string id)
		{
			IConsideration consideration;

			if (!m_considerations.TryGetValue(id, out consideration))
			{
				//Error case
				return null;
			}

			return consideration.Clone();
		}
	}
}
