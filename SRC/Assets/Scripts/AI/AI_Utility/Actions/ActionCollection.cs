using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
    public class ActionCollection : IActionCollection
    {
        private Dictionary<InfoId, IAction> m_actions;

        public ActionCollection()
        {
            m_actions = new Dictionary<InfoId, IAction>();
        }

        public bool Add(IAction action)
        {
            if (action == null || action.Equals(null))
                return false;

            var id = action.Id;
            if (Contains(id))
                return false;

            m_actions.Add(id, action);

            return true;
        }

        public void Clear()
        {
            m_actions.Clear();
        }

        public bool Contains(InfoId id)
        {
            return m_actions.ContainsKey(id);
        }

        public IAction Create(InfoId id)
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
