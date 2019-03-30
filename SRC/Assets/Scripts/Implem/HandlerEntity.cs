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


	[HandlerAttribute()]
	public static class HandlerEntity
	{
		[AgentActionAttribute()]
		private static void Idle(Object actor)
		{
			((IEntityAction)actor).Idle();
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
}
