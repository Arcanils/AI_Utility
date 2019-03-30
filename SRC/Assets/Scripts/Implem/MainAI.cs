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
	}
}