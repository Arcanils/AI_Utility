using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AI.AI_Utility
{
	public abstract class GenericActionBase<TContext> : IAction where TContext : class, IContext
	{
		private float m_cooldown;
		private float m_startedTime;
		private readonly IActionCollection m_collection;

		public string NameId { get; private set; }
		public float Cooldown
		{
			get { return m_cooldown; }
			set { m_cooldown = Mathf.Max(0f, value); }
		}

		public bool InCooldown
		{
			get
			{
				if (Status == EActionStatus.Running ||
				   Status == EActionStatus.Idle)
					return false;

				return Time.time - m_startedTime < m_cooldown;
			}
		}

		public EActionStatus Status { get; protected set; }

		public void Execute(IContext context)
		{
			throw new NotImplementedException();
		}

		protected void EndInSuccess(TContext context)
		{
			if (Status != EActionStatus.Running)
				return;

			Status = EActionStatus.Success;
			FinalizeAction(context);
		}

		/// <summary>
		///   Ends the action and sets its status to <see cref="F:Crystal.ActionStatus.Failure"/>.
		/// </summary>
		/// <param name="context">The context.</param>
		protected void EndInFailure(TContext context)
		{
			if (Status != EActionStatus.Running)
				return;

			Status = EActionStatus.Failure;
			FinalizeAction(context);
		}

		private void FinalizeAction(TContext context)
		{
			OnStop(context);
		}

		#region OverrideFct

		protected virtual void OnExecute(TContext context)
		{
			EndInSuccess(context);
		}

		protected virtual void OnUpdate(TContext context)
		{
		}

		protected virtual void OnStop(TContext context)
		{
		}

		#endregion
	}
}
