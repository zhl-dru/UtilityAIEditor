using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    [CreateNodeMenu("Utility AI/ÆÀ¹ÀÆ÷/ÆÀ¹ÀÆ÷¼¯")]
    [NodeTitle("ÆÀ¹ÀÆ÷¼¯")]
    public class EvaluatorGraphNode : EvaluatorNode
    {
        [LabelText("×ÓÍ¼")]
        [ShowInInspector]
        [Required]
        private EvaluatorGraph evaluatorGraph;

        public IEnumerable<EvaluatorNode> Evaluators => evaluatorGraph.Evaluators;

        public override float Evaluate(IAIContext context)
        {
            return 0f;
        }
    }
}