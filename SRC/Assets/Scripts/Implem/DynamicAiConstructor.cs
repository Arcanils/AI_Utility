using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
    public class DynamicAiConstructor : AiConstructor
    {

		private void Init()
		{
			AIs = new AiCollection();
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
        }
    }
}
