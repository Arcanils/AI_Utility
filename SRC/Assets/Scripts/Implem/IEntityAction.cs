using UnityEngine;

namespace AI.AI_Utility
{
    public interface IEntityAction
    {
        void Idle();
        void Eat();
		void Drink();
        void MoveTo();
		void Death();
		void Sleep();
	}

	public interface IWolfAction : IEntityAction
	{
		void Attack();
		void Howl();
	}

	public interface IDearAction : IEntityAction
	{
		void Flee();
	}

	public class WolfAgent : IWolfAction
	{
		public void Attack()
		{
			throw new System.NotImplementedException();
		}

		public void Death()
		{
			throw new System.NotImplementedException();
		}

		public void Drink()
		{
			throw new System.NotImplementedException();
		}

		public void Eat()
		{
			throw new System.NotImplementedException();
		}

		public void Howl()
		{
			throw new System.NotImplementedException();
		}

		public void Idle()
		{
			throw new System.NotImplementedException();
		}

		public void MoveTo()
		{
			throw new System.NotImplementedException();
		}

		public void Sleep()
		{
			throw new System.NotImplementedException();
		}
	}

	public class DearAgent : IDearAction
	{
		public void Death()
		{
			throw new System.NotImplementedException();
		}

		public void Drink()
		{
			throw new System.NotImplementedException();
		}

		public void Eat()
		{
			throw new System.NotImplementedException();
		}

		public void Flee()
		{
			throw new System.NotImplementedException();
		}

		public void Idle()
		{
			throw new System.NotImplementedException();
		}

		public void MoveTo()
		{
			throw new System.NotImplementedException();
		}

		public void Sleep()
		{
			throw new System.NotImplementedException();
		}
	}

}
