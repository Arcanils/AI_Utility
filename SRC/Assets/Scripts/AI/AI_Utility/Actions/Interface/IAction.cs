using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public enum EActionStatus
	{
		Failure,
		Success,
		Running,
		Idle, // None
	}

	public interface IAction
	{
		string NameId { get; }

		float Cooldown { get; set; }
		bool InCooldown { get; }

		EActionStatus Status { get; }

		void Execute(IContext context);
	}
}
