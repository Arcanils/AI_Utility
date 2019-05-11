﻿using System.Collections.Generic;
using UnityEngine;

namespace AI.AI_Utility.Info
{
	[System.Serializable]
	public struct IdInfoIndex
	{
		public readonly int ContextIndex;
		public readonly int NameIndex;

		public IdInfoIndex(int contextIndex, int nameIndex)
		{
			ContextIndex = contextIndex;
			NameIndex = nameIndex;
		}
	}


	[System.Serializable]
	public class AiInfoDatabase
	{
		private LoaderHandlers m_loader;

		private string[] m_actionContextNames;
		private string[][] m_actionNames;

		[SerializeField]
		private List<ActionInfo> m_actionInfos;

		private string[] m_considerationContextNames;
		private string[][] m_considerationNames;

		[SerializeField]
		private List<ConsiderationInfo> m_considerationInfos;

		[SerializeField]
		private List<OptionInfo> m_optionInfos;

		[SerializeField]
		private List<BehaviourInfo> m_behaviourInfos;


		private void Load()
		{
			m_loader = new LoaderHandlers();
			m_loader.LoadActions();

            ComputeConsiderationsAndActions();
		}


		private void ComputeConsiderationsAndActions()
		{
			m_loader.GetDatas(out m_actionContextNames, out m_actionNames, out m_considerationContextNames, out m_considerationNames);
		}

	}
}