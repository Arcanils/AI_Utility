using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public class AiCollection : IAiCollection
	{
		private Dictionary<string, IUtilityAi> m_ais;

		public IActionCollection Actions { get { return m_actions; } }
		public IConsiderationCollection Considerations { get { return m_considerations; } }
		public IOptionCollection Options { get { return m_options; } }
		public IBehaviourCollection Behaviours { get { return m_behaviours; } }

		private IActionCollection m_actions;
		private IConsiderationCollection m_considerations;
		private IOptionCollection m_options;
		private IBehaviourCollection m_behaviours;


		public AiCollection(Info.AiInfoDatabase db)
		{
			m_ais = new Dictionary<string, IUtilityAi>();
			m_actions = new ActionCollection();
			m_considerations = new ConsiderationCollection();
			m_options = new OptionCollection(Actions, Considerations);
			m_behaviours = new BehaviourCollection(Options);

			Populate(db);
		}

		public void Populate(Info.AiInfoDatabase db)
		{
			db.FillCollections(ref m_actions, ref m_considerations);
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
