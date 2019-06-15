using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
    public class DynamicAiConstructor : AiConstructor
    {
		public DynamicAiConstructor(Info.AiInfoDatabase db)
		{
			Init(db);
		}

		private void Init(Info.AiInfoDatabase db)
		{
			AIs = new AiCollection(db);
		}

        public IUtilityAi Create(Info.AiInfo info)
        {
            if (!AIs.Contains(info.Id))
            {
                _CreateAiDynamic(info);
            }

            return AIs.GetAi(info.Id);
        }

        private void _CreateAiDynamic(Info.AiInfo info)
        {
            var actions = new List<IAction>();
			foreach (var actioninfo in info.Actions)
			{
				var newAction = Actions.Create(actioninfo.RefAction);

				if (newAction == null)
				{
					throw new NullReferenceException();
				}
				newAction.Initialize(actioninfo);
				actions.Add(newAction);
			}

			var considerations = new List<IConsideration>();
			foreach (var considerationinfo in info.Considerations)
			{
				var newConsideration = Considerations.Create(considerationinfo.RefConsideration);

				if (newConsideration == null)
				{
					throw new NullReferenceException();
				}
				newConsideration.Initialize(considerationinfo);
				considerations.Add(newConsideration);
			}
			var options = new List<IOption>();
			foreach (var optionInfo in info.Options)
			{
				var action = actions[optionInfo.ActionInfoIndex];
				var subConsiderations = new List<IConsideration>();
				foreach (var indexConsideration in optionInfo.ConsiderationInfoIndexes)
				{
					subConsiderations.Add(considerations[indexConsideration]);
				}
				var newOption = new DynamicOption(action, subConsiderations, optionInfo);
				options.Add(newOption);
			}

			var behaviours = new List<IBehaviour>();
			foreach (var behaviourInfo in info.Behaviours)
			{
				var subOptions = new List<IOption>();
				foreach (var indexOption in behaviourInfo.OptionInfoIndexes)
				{
					subOptions.Add(options[indexOption]);
				}
				var subConsiderations = new List<IConsideration>();
				foreach (var indexConsideration in behaviourInfo.ConsiderationInfoIndexes)
				{
					subConsiderations.Add(considerations[indexConsideration]);
				}
				var newBehaviour = new DynamicBehaviours(subOptions, subConsiderations, behaviourInfo);
				behaviours.Add(newBehaviour);
			}

			var newAi = new DynamicAi(behaviours);
			AIs.Add(newAi);
		}
    }
}
