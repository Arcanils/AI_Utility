using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public class DynamicAi : IUtilityAi
	{
		string IUtilityAi.NameId
		{
			get
			{
				return null;
			}
		}
		ISelector IUtilityAi.Selector { get; set; }

		public DynamicAi()
		{

		}

		bool IUtilityAi.AddBehaviour(string behaviourId)
		{
			throw new NotImplementedException();
		}

		IUtilityAi IClone<IUtilityAi>.Clone()
		{
			throw new NotImplementedException();
		}

		bool IUtilityAi.RemoveBehaviour(string behaviourId)
		{
			throw new NotImplementedException();
		}

		IAction IUtilityAi.Select(IContext context)
		{
			throw new NotImplementedException();
		}
	}
}
