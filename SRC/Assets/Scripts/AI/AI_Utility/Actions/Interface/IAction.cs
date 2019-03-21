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

    [System.Flags]
    public enum EActionType
    {
        Interruptable,
    }

    public interface IAction : IClone<IAction>
    {
		InfoId Id { get; }

		float Cooldown { get; set; }
		bool InCooldown { get; }

		EActionStatus Status { get; }
        EActionType ActionType { get; }

        void Execute(IContext context);
	}
}
