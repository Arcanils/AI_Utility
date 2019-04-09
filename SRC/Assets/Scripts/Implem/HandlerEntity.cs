using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
	public class HandlerAttribute : Attribute
	{
	}

	public class AgentActionAttribute : Attribute
	{
	}

    public class ConsiderationAttribute : Attribute { };



    [HandlerAttribute()]
	public static class HandlerEntity
	{
		[AgentActionAttribute()]
		private static void Idle(Object actor)
		{
			((IEntityAction)actor).Idle();
		}

        [ConsiderationAttribute()]
        private static float GetThirst(Object actor)
        {
            return ((IEntityConsideration)actor).Thirst;
        }
	}


	[HandlerAttribute()]
	public static class HandlerWolf
	{
		[AgentActionAttribute()]
		private static void Attack(Object actor)
		{
			((IEntityAction)actor).Idle();
		}

		[AgentActionAttribute()]
		private static void Run(Object actor)
		{
			((IEntityAction)actor).Idle();
		}
	}


	public static class HandlerDear
	{
		[AgentActionAttribute()]
		private static void Flee(Object actor)
		{
			((IDearAction)actor).Flee();
		}
	}
}
