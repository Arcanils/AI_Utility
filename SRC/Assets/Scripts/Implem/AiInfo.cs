using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility.Info
{
	[Serializable]
	public class AiInfo
    {
        public InfoId Id;
        public ConsiderationInfo[] Considerations;
		public ActionInfo[] Actions;
		public OptionInfo[] Options;
		public BehaviourInfo[] Behaviours;
	}

	[Serializable]
	public class ConsiderationInfo
    {
        public InfoId Id;
        public int ContextId;
		public int ModeCurve;
		public float[] ExtraValues;
	}

	[Serializable]
	public class ActionInfo
    {
        public InfoId Id;
        public int ContextId;
		public int ActionToLaunchId;
	}

	[Serializable]
	public class OptionInfo
    {
        public InfoId Id;
        public string RefActionId;
		public string[] RefsConsiderationId;
		public int ModeMeasure;
	}

	[Serializable]
	public class BehaviourInfo
	{
		public InfoId Id;
		public string[] RefsOptionsId;
		public string[] RefsConsiderationId;
	}

}
