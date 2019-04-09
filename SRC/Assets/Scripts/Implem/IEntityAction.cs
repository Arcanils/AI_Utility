using System;
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

    public interface IEntityConsideration
    {
        float Thirst { get; }
        float Hunger { get; }
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

	public class DearAgent : IDearAction, IEntityConsideration
    {
        private float m_hunger = 0f;
        public float Hunger
        {
            get
            {
                return m_hunger;
            }
        }

        private float m_thirst = 0f;
        public float Thirst
        {
            get
            {
                return m_thirst;
            }
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
