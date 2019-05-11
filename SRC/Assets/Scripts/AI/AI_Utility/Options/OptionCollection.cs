using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public class OptionCollection : IOptionCollection
	{
		private Dictionary<string, IOption> m_options;

		public IActionCollection Actions { get; private set; }
		public IConsiderationCollection Considerations { get; private set; }

		public OptionCollection(IActionCollection actions, IConsiderationCollection considerations)
		{
			m_options = new Dictionary<string, IOption>();
			Actions = actions;
			Considerations = considerations;
		}


		public bool Add(IOption option)
		{
			if (option == null || option.Equals(null))
				return false;

			var id = option.NameId;
			if (Contains(id))
				return false;

			m_options.Add(id, option);

			return true;
		}

		public void Clear()
		{
			m_options.Clear();
		}

		public bool Contains(string id)
		{
			return m_options.ContainsKey(id);
		}

		public IOption Create(string id)
		{
			IOption option;

			if (!m_options.TryGetValue(id, out option))
			{
				//Error case
				return null;
			}

			return option.Clone() as IOption;
		}
	}
}
