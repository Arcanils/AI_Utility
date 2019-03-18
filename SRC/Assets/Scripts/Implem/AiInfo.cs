using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility.Info
{
	public class AiInfo
	{
		public ConsiderationInfo[] Considerations;
		public ActionInfo[] Actions;
		public OptionInfo[] Options;
		public BehaviourInfo[] Behaviours;
	}

	public class ConsiderationInfo
	{
		public string ConsiderationId;
		public int ContextId;
		public int ModeCurve;
		public float[] ExtraValues;
	}

	public class ActionInfo
	{
		public string ActionId;
		public int ContextId;
		public int ActionToLaunchId;
	}

	public class OptionInfo
	{
		public string OptionId;
		public string RefActionId;
		public string[] RefsConsiderationId;
		public int ModeMeasure;
	}

	public class BehaviourInfo
	{
		public string BehaviourId;
		public string[] RefsOptionsId;
		public string[] RefsConsiderationId;
	}

}
