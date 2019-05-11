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
		public string Name;

        public IdInfoIndex RefConsideration;
		public int ModeCurve;
		public bool Invert;
		public float[] ExtraValues;
	}

	[Serializable]
	public class ActionInfo
	{
		public string Name;

		public IdInfoIndex RefAction;
	}

	[Serializable]
	public class OptionInfo
    {
		public string Name;

		public int ActionInfoIndex;
		public int[] ConsiderationInfoIndexes;
		public int ModeMeasure;
	}

	[Serializable]
	public class BehaviourInfo
	{
		public string Name;

		public int[] OptionInfoIndexes;
		public int[] ConsiderationInfoIndexes;
	}

}
