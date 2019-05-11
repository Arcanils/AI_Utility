using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace AI.AI_Utility
{
    public delegate void ActionToExecute(UnityEngine.Object actor);
    public delegate float ConsiderationToGet(UnityEngine.Object actor);

    public class LoaderHandlers
	{
		private class LoaderHandler
        {
            public Dictionary<string, ActionToExecute> Actions { get; private set; }
            public Dictionary<string, ConsiderationToGet> Considerations { get; private set; }

            public LoaderHandler(Type t)
			{
				Actions = new Dictionary<string, ActionToExecute>();
				LoadActions(t);
			}

			public void LoadActions(Type t)
			{
				Actions.Clear();
                var c_actionAttributToCatch = typeof(AgentActionAttribute);
                var c_considerationAttributToCatch = typeof(ConsiderationAttribute);
                var typeDelegate = typeof(ActionToExecute);
				BindingFlags s_reflectionBindingFlags = BindingFlags.Static | BindingFlags.NonPublic;
                var allMethodsFromType = t.GetMethods(s_reflectionBindingFlags);

                var actionMethodInfos = allMethodsFromType.Where(method => method.GetCustomAttributes(
                    c_actionAttributToCatch, false).Length > 0).ToArray();
                var considerationMethodInfos = allMethodsFromType.Where(method => method.GetCustomAttributes(
                    c_considerationAttributToCatch, false).Length > 0).ToArray();

                foreach (var info in actionMethodInfos)
				{
					var idAction = info.Name;
					var action = Delegate.CreateDelegate(typeDelegate, info) as ActionToExecute;
					Actions.Add(idAction, action);
                }
                foreach (var info in considerationMethodInfos)
                {
                    var idConsideration = info.Name;
                    var consideration = Delegate.CreateDelegate(typeDelegate, info) as ConsiderationToGet;
                    Considerations.Add(idConsideration, consideration);
                }
            }

			public void DisplayContents()
			{
				foreach (var keyvalue in Actions)
                {
                    Debug.LogFormat("[LoaderHandler] : ACTION_METHOD:{0}", keyvalue.Key);
                }
                foreach (var keyvalue in Considerations)
                {
                    Debug.LogFormat("[LoaderHandler] : CONSIDERATION_METHOD:{0}", keyvalue.Key);
                }
            }
		}

		private readonly Dictionary<string, LoaderHandler> m_loaders;

		public LoaderHandlers()
		{
			m_loaders = new Dictionary<string, LoaderHandler>();
		}

		public void LoadActions()
		{
			var assembly = Assembly.GetAssembly(typeof(HandlerEntity));
			var types = assembly.GetTypes();

			var attributeToSelect = typeof(HandlerAttribute);

			foreach (var typeInAssembly in types)
			{
				if (typeInAssembly.GetCustomAttributes(attributeToSelect, true).FirstOrDefault() == null)
					continue;

				var handler = new LoaderHandler(typeInAssembly);
				m_loaders.Add(typeInAssembly.ToString(), handler);
			}
		}

		public void GetDatas(
            out string[] actionContextNames, 
            out string[][] actionNames, 
            out string[] considerationContextNames,
            out string[][] considerationNames)
        {
            actionContextNames = new string[m_loaders.Count];
            actionNames = new string[m_loaders.Count][];
            considerationContextNames = new string[m_loaders.Count];
            considerationNames = new string[m_loaders.Count][];

            var index = 0;
			foreach (var keyvalue in m_loaders)
            {
                actionContextNames[index] = keyvalue.Key;
                considerationContextNames[index] = keyvalue.Key;
                var actions = keyvalue.Value.Actions;
				var indexAction = 0;

				actionNames[index] = new string[actions.Count];
				foreach (var name in actions.Keys)
				{
					actionNames[index][indexAction++] = name;
                }

                var considerations = keyvalue.Value.Considerations;
                var indexConsiderations = 0;

                considerationNames[index] = new string[considerations.Count];
                foreach (var name in considerations.Keys)
                {
                    actionNames[index][indexConsiderations++] = name;
                }
                ++index;
			}
		}

		public void DisplayContents()
		{
			foreach (var keyvalue in m_loaders)
			{
				Debug.LogFormat("[LoaderHandlers] : TYPE:{0}", keyvalue.Key);
				keyvalue.Value.DisplayContents();
			}
		}
	}

}
