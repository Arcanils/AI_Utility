using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public class BehaviourCollection : IBehaviourCollection
	{
		private Dictionary<string, IBehaviour> m_behaviours;

		public IOptionCollection Options { get; private set; }

		public BehaviourCollection(IOptionCollection options)
		{
			m_behaviours = new Dictionary<string, IBehaviour>();
			Options = options;
		}


		public bool Add(IBehaviour behaviour)
		{
			if (behaviour == null || behaviour.Equals(null))
				return false;

			var id = behaviour.NameId;
			if (Contains(id))
				return false;

			m_behaviours.Add(id, behaviour);

			return true;
		}

		public void Clear()
		{
			m_behaviours.Clear();
		}

		public bool Contains(string id)
		{
			return m_behaviours.ContainsKey(id);
		}

		public IBehaviour Create(string id)
		{
			IBehaviour behaviour;

			if (!m_behaviours.TryGetValue(id, out behaviour))
			{
				//Error case
				return null;
			}

			return behaviour.Clone() as IBehaviour;
		}
	}
}
