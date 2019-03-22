using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assets.Scripts.Implem
{
    public interface IEntityAction
    {
        void Idle();
        void Eat();
        void MoveTo();
    }

    public delegate void ActionToExecute<T>(IEntityAction actor);

    [HandlerAttribute()]
    public class LoaderHandler<T>
    {
        private readonly Dictionary<string, ActionToExecute<T>> m_actions;

        public LoaderHandler()
        {
            m_actions = new Dictionary<string, ActionToExecute<T>>();
            LoadActions();
        }

        public void LoadActions()
        {
            m_actions.Clear();
            var typeDelegate = typeof(ActionToExecute<T>);
            var type = typeof(HandlerEntity);
            BindingFlags s_reflectionBindingFlags = BindingFlags.Static | BindingFlags.NonPublic;
            MethodInfo[] methodInfos = type.GetMethods(s_reflectionBindingFlags);
            foreach (var info in methodInfos)
            {
                var idAction = info.Name;
                var action = Delegate.CreateDelegate(typeDelegate, info) as ActionToExecute<T>;
                m_actions.Add(idAction, action);
            }
        }
    }

    public class LoaderHandlers
    {
        private readonly Dictionary<string, LoaderHandler<TargetException>> m_actions;
    }

    public class HandlerAttribute : Attribute
    {
    }

    public class AgentActionAttribute : Attribute
    {
    }

    public static class HandlerEntity
    {
        [AgentActionAttribute()]
        private static void Idle(IEntityAction actor)
        {
            actor.Idle();
        }
    }

    public class EntityAgent : IEntityAction
    {
        public void Idle()
        {
            throw new NotImplementedException();
        }
    }
}
