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

	public interface IActionExecute
	{
		UnityEngine.Object Actor { get; }
		EActionStatus Status { get; set; }
	}

    public interface IAction : IClone<IAction>
	{
		InfoId Id { get; }

		float Cooldown { get;}
		bool InCooldown { get; }

		EActionStatus Status { get; }
        EActionType ActionType { get; }

		void Initialize(Info.ActionInfo info);

        void Execute(IContext context);
		EActionStatus ManualUpdate(float deltaTime);
	}
}
