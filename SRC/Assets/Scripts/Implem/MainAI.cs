using AI.AI_Utility.Info;
using System.Collections.Generic;
using UnityEngine;


namespace AI.AI_Utility
{
	public class MainAI : MonoBehaviour
	{
		[SerializeField]
		private AiInfoDatabaseScriptable m_dbScriptable;
		[SerializeField]
		private AiInfoScriptable[] m_aiInfoScriptables;

		public void Awake()
		{
			CreateAI();
		}

		public void TestMethod()
		{
			var loader = new LoaderHandlers();
			loader.LoadActions();
			loader.DisplayContents();
		}

		public void CreateAI()
		{
			var db = m_dbScriptable.DB;
			db.Load();

			var constructor = new DynamicAiConstructor();

			foreach(var info in m_aiInfoScriptables)
			{
				constructor.Create(info.Data);
			}
		}

		//TODO
		public string[] GetContextActions()
		{
			return new string[]
			{
				"IEntityAction",
				"IDearAction",
				"IWolfAction",
			};
		}

		public string[] GetActionNames(int contextIndex)
		{
			return new string[] { "Idle", "Drink" };
		}
	}
}