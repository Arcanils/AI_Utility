using AI.AI_Utility.Info;
using UnityEngine;


namespace AI.AI_Utility
{
	public class MainAI : MonoBehaviour
	{
		public AiInfo data;

		public void Awake()
		{
			TestMethod();
		}

		public void TestMethod()
		{
			var loader = new LoaderHandlers();
			loader.LoadActions();
			loader.DisplayContents();

			DynamicAiConstructor constructor = new DynamicAiConstructor();

			//construct ai

			constructor.Create(data);
		}
	}
}