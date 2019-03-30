using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace AI.AI_Utility
{
	public delegate void ActionToExecute(UnityEngine.Object actor);

	public class LoaderHandlers
	{
		private class LoaderHandler
		{
			public Dictionary<string, ActionToExecute> Actions { get; private set; }

			public LoaderHandler(Type t)
			{
				Actions = new Dictionary<string, ActionToExecute>();
				LoadActions(t);
			}

			public void LoadActions(Type t)
			{
				Actions.Clear();
				var c_attributToCatch = typeof(AgentActionAttribute);
				var typeDelegate = typeof(ActionToExecute);
				BindingFlags s_reflectionBindingFlags = BindingFlags.Static | BindingFlags.NonPublic;
				MethodInfo[] methodInfos = t.GetMethods(s_reflectionBindingFlags).Where(
					method => method.GetCustomAttributes(c_attributToCatch, false).Length > 0).ToArray();

				foreach (var info in methodInfos)
				{
					var idAction = info.Name;
					var action = Delegate.CreateDelegate(typeDelegate, info) as ActionToExecute;
					Actions.Add(idAction, action);
				}
			}

			public void DisplayContents()
			{
				foreach (var keyvalue in Actions)
				{
					Debug.LogFormat("[LoaderHandler] : METHOD:{0}", keyvalue.Key);
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
