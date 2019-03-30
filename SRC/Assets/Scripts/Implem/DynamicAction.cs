using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
    public interface IActionExecute
    {
        EActionStatus Status { get; }
        void Execute();
    }
    public class DynamicAction : IAction
    {
        private IActionExecute m_refActionToExecute;
        private Info.ActionInfo m_info;

        public float Cooldown
        {
            get
            {
				return 0f;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public InfoId Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool InCooldown
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EActionStatus Status
        {
            get
            {
                throw new NotImplementedException();
            }
        }

		public EActionType ActionType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IAction Clone()
        {
            throw new NotImplementedException();
        }

        public void Execute(IContext context)
        {
            throw new NotImplementedException();
        }
    }
}
