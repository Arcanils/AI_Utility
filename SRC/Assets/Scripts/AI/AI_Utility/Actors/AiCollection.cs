using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public class AiCollection : IAiCollection
	{
		private Dictionary<string, IUtilityAi> m_ais;

		public IActionCollection Actions { get; protected set; }

		public IConsiderationCollection Considerations { get; protected set; }

		public IOptionCollection Options { get; protected set; }

		public IBehaviourCollection Behaviours { get; protected set; }


		public AiCollection()
		{
			m_ais = new Dictionary<string, IUtilityAi>();
			Actions = new ActionCollection();
			Considerations = new ConsiderationCollection();
			Options = new OptionCollection(Actions, Considerations);
			Behaviours = new BehaviourCollection(Options);
		}


		public bool Add(IUtilityAi ai)
		{
			if (ai == null || ai.Equals(null))
				return false;

			var id = ai.NameId;
			if (Contains(id))
				return false;

			m_ais.Add(id, ai);

			return true;
		}

		public void Clear()
		{
			m_ais.Clear();
		}

		public bool Contains(string id)
		{
			return m_ais.ContainsKey(id);
		}

		public IUtilityAi CreateAi(string id)
		{
			IUtilityAi ai;

			if (!m_ais.TryGetValue(id, out ai))
			{
				//Error case
				return null;
			}

			return ai.Clone();
		}

		public IUtilityAi GetAi(string aiId)
		{
			throw new NotImplementedException();
		}
	}
}
