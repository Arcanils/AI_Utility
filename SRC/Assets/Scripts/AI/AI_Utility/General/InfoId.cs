using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.AI_Utility
{
    public struct InfoId
    {
        public string NameId;
        public string NamespaceId;
        public string Id { get { return string.Format("{0}_{1}", NamespaceId, NameId); } }

        public static implicit operator string(InfoId id)
        {
            return id.Id;
        }
    }
}
