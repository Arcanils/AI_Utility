using System;
using System.Collections;

namespace AI.AI_Utility
{
    public class DynamicAction : IAction , IActionExecute
	{
        private ActionToExecute m_refActionToExecute;
        private Info.ActionInfo m_info;

		private InfoId m_id;
		private float m_cd;
		private EActionStatus m_status;
		private EActionType m_actionType;
		private UnityEngine.Object m_actor;

		private IEnumerator m_routineAction;

		public DynamicAction(InfoId id, ActionToExecute action)
		{
			m_id = id;
			m_refActionToExecute = action;
		}

		public DynamicAction(DynamicAction actionToCopy)
		{
			this.m_refActionToExecute = actionToCopy.m_refActionToExecute;
			this.m_info = actionToCopy.m_info;
			this.m_id = actionToCopy.m_id;
		}


		#region IAction implem

		InfoId IAction.Id { get { return m_id; } }
		float IAction.Cooldown { get { return m_cd; } }
		bool IAction.InCooldown  {get { return false; } }
		EActionStatus IAction.Status { get { return m_status; } }
		EActionType IAction.ActionType { get { return m_actionType; } }

		IAction IClone<IAction>.Clone()
		{
			return new DynamicAction(this);
		}
		
		void IAction.Initialize(Info.ActionInfo info)
		{
			m_info = info;
		}

		void IAction.Execute(IContext context)
		{
			m_routineAction = m_refActionToExecute(this);
		}

		EActionStatus IAction.ManualUpdate(float deltaTime)
		{
			if (m_routineAction == null)
				return EActionStatus.Failure;

			m_routineAction.MoveNext();
			return m_status;
		}
		#endregion

		#region IActionExecute implem

		EActionStatus IActionExecute.Status { get { return m_status; } set { m_status = value; } }
		UnityEngine.Object IActionExecute.Actor { get { return m_actor; } }

		#endregion
	}
}
