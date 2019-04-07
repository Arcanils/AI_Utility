using AI.AI_Utility.Info;
using System.Collections.Generic;
using UnityEngine;


namespace AI.AI_Utility
{
	public class MainAI : MonoBehaviour
	{
		public void Awake()
		{
			TestMethod();
		}

		public void TestMethod()
		{
			var loader = new LoaderHandlers();
			loader.LoadActions();
			loader.DisplayContents();
		}


		public void CreateFakeData()
		{
			var id = new InfoId() { NamespaceId = "Entity", NameId = "Dear" };
			var considerations = new ConsiderationInfo[]
			{
				new ConsiderationInfo()
				{
					RefConsideration = new InfoId() { NamespaceId = "Self", NameId = "Thirst"},
					ExtraValues = new float[] { 0f, 0f, 1f, 1f },
				}
			};
			var actions = new ActionInfo[]
			{
				new ActionInfo()
				{
					RefAction = new InfoId() { NamespaceId = "IEntityAction", NameId = "Idle"},
				},
				new ActionInfo()
				{
					RefAction = new InfoId() { NamespaceId = "IEntityAction", NameId = "Drink"},
				},
			};
			var options = new OptionInfo[]
			{
				new OptionInfo()
				{
					Id = new InfoId() { NamespaceId = "Entity", NameId = "Drink"},
					ActionIndex = 1,
					ConsiderationsIndex = new int[] {0},
				},
				new OptionInfo()
				{
					Id = new InfoId() { NamespaceId = "Entity", NameId = "Idle"},
					ActionIndex = 0,
					ConsiderationsIndex = null,
				},
			};
			var behaviours = new BehaviourInfo[]
			{
				new BehaviourInfo()
				{
					Id = new InfoId() { NamespaceId = "Entity", NameId = "Normal"}
				}
			};
			var fakeDataDead = new Info.AiInfo()
			{
				Id = id,
				Actions = actions,
				Considerations = considerations,
				Options = options,
				Behaviours = behaviours,
			};
		}

		public void FakeDatabaseConsiderations(ref List<ConsiderationInfo> considerationsDB)
		{
			considerationsDB = new List<ConsiderationInfo>()
			{
				new ConsiderationInfo()
				{
					RefConsideration = new InfoId() { NamespaceId = "Self", NameId = "Thirst"},
					ExtraValues = new float[] { 0f, 0f, 1f, 1f },
				}
			};
		}
		public void FakeDatabaseActions(ref List<ActionInfo> actionDB)
		{
			actionDB = new List<ActionInfo>()
			{
				new ActionInfo()
				{
					RefAction = new InfoId() { NamespaceId = "IEntityAction", NameId = "Idle"},
				},
				new ActionInfo()
				{
					RefAction = new InfoId() { NamespaceId = "IEntityAction", NameId = "Drink"},
				},
			};
		}

		public void FakeDatabaseOptions(ref List<OptionInfo> optionDB)
		{
			optionDB = new List<OptionInfo>()
			{
				new OptionInfo()
				{
					Id = new InfoId() { NamespaceId = "Entity", NameId = "Drink"},
					ActionIndex = 1,
					ConsiderationsIndex = new int[] {0},
				},
				new OptionInfo()
				{
					Id = new InfoId() { NamespaceId = "Entity", NameId = "Idle"},
					ActionIndex = 0,
					ConsiderationsIndex = null,
				},
			};
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