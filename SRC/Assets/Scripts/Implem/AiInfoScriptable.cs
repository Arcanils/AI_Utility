using UnityEngine;

namespace AI.AI_Utility.Info
{
	[CreateAssetMenu(fileName = "AiInfo_001", menuName ="AI/AiInfo")]
	class AiInfoScriptable : ScriptableObject
	{
		public AiInfo Data;


#if UNITY_EDITOR
		[ContextMenu("PopulateFakeData")]
		private void PopulateFakeData()
		{
			var id = new InfoId() { NamespaceId = "Entity", NameId = "Dear" };
			var considerations = new ConsiderationInfo[]
			{
				new ConsiderationInfo()
				{
					Name = "Thirst",
					RefConsideration = new IdInfoIndex(0,0),
					ModeCurve = 0,
					Invert = false,
					ExtraValues = new float[] { 0f, 0f, 1f, 1f },
				}
			};
			var actions = new ActionInfo[]
			{
				new ActionInfo()
				{
					Name = "Idle",
					RefAction  = new IdInfoIndex(0,0),
				},
				new ActionInfo()
				{
					Name = "Drink",
					RefAction  = new IdInfoIndex(0,1),
				},
			};
			var options = new OptionInfo[]
			{
				new OptionInfo()
				{
					Name = "Drink",
					ActionInfoIndex  = 1,
					ConsiderationInfoIndexes = new int[]{0},
					ModeMeasure = 0,
				},
				new OptionInfo()
				{
					Name = "Idle",
					ActionInfoIndex  = 0,
					ConsiderationInfoIndexes = new int[]{},
					ModeMeasure = 0,
				},
			};
			var behaviours = new BehaviourInfo[]
			{
				new BehaviourInfo()
				{
					Name = "Normal",
					OptionInfoIndexes = new int[]{0,1},
					ConsiderationInfoIndexes = new int[]{0},
				}
			};
			Data = new AiInfo()
			{
				Id = id,
				Actions = actions,
				Considerations = considerations,
				Options = options,
				Behaviours = behaviours,
			};

			UnityEditor.EditorUtility.SetDirty(this);
		}
#endif
	}
}
