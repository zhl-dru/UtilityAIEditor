using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/AI")]
    public class AIGraph : AIBaseGraph
    {
        private DeciderNode decider;
        public DeciderNode Decider => GetUniqueNode(decider);
    }
}