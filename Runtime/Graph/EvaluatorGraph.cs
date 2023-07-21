using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/评估器集")]
    public class EvaluatorGraph : AIBaseGraph
    {
        private EvaluatorSetNode evaluatorSet;
        public EvaluatorSetNode EvaluatorSet => GetUniqueNode(evaluatorSet);

        public IEnumerable<EvaluatorNode> Evaluators => EvaluatorSet.Evaluators;
    }
}