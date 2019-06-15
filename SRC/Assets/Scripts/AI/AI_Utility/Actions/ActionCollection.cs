using AI.AI_Utility.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
    public class ActionCollection : IActionCollection
    {
        private Dictionary<IdInfoIndex, IAction> m_actions;

        public ActionCollection()
        {
            m_actions = new Dictionary<IdInfoIndex, IAction>();
        }

        public bool Add(IAction action, IdInfoIndex id)
        {
            if (action == null || action.Equals(null))
                return false;
			
            if (Contains(id))
                return false;

            m_actions.Add(id, action);

            return true;
        }

        public void Clear()
        {
            m_actions.Clear();
        }

        public bool Contains(IdInfoIndex id)
        {
            return m_actions.ContainsKey(id);
        }

        public IAction Create(IdInfoIndex id)
        {
            IAction action;

            if (!m_actions.TryGetValue(id, out action))
            {
                //Error case
                return null;
            }

            return action.Clone();
        }
    }
}
