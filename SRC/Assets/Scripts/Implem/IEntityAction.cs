using UnityEngine;

namespace AI.AI_Utility
{
    public interface IEntityAction
    {
        void Idle();
        void Eat();
        void MoveTo();
	}

	public class EntityAgent : IEntityAction
	{
		public void Eat()
		{
			Debug.Log("Eat ! ");
		}

		public void Idle()
		{
			Debug.Log("Idle ! ");
		}

		public void MoveTo()
		{
			Debug.Log("Move to ! ");
		}
	}

}
