using System.Collections.Generic;
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


		private string[] m_considerationContextNames;
		private string[][] m_considerationNames;

		public void Load()
		{
			m_loader = new LoaderHandlers();
			m_loader.LoadActions();

            ComputeConsiderationsAndActions();
		}

		public void FillCollections(ref IActionCollection actionCollection, ref IConsiderationCollection considerationCollection)
		{
			for (int i = 0, iLength = m_actionContextNames.Length; i < iLength; ++i)
			{
				var contextName = m_actionContextNames[i];
				for (int j = 0, jLength = m_actionNames[i].Length; j < jLength; ++j)
				{
					var actionName = m_actionNames[i][j];

					var action = m_loader.GetAction(contextName, actionName);

					if (action == null)
					{
						throw new System.NullReferenceException();
					}

					actionCollection.Add(action, new IdInfoIndex(i, j));
				}
			}

			for (int i = 0, iLength = m_considerationContextNames.Length; i < iLength; ++i)
			{
				var contextName = m_considerationContextNames[i];
				for (int j = 0, jLength = m_considerationNames[i].Length; j < jLength; ++j)
				{
					var considerationName = m_considerationNames[i][j];

					var consideration = m_loader.GetConsideration(contextName, considerationName);

					if (consideration == null)
					{
						throw new System.NullReferenceException();
					}

					considerationCollection.Add(consideration, new IdInfoIndex(i, j));
				}
			}
		}

		private void ComputeConsiderationsAndActions()
		{
			m_loader.GetDatas(out m_actionContextNames, out m_actionNames, out m_considerationContextNames, out m_considerationNames);
		}

	}
}
