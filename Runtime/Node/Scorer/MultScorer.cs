using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    [CreateNodeMenu("Utility AI/计分器/乘法计分器")]
    [NodeTitle("乘法计分器")]
    public class MultScorer : ScorerNode
    {
        public override float Scorer(IAIContext context)
        {
            float score = 1f;
            var evaluators = GetAllOnPort<EvaluatorNode>(nameof(evaluator));
            foreach (var evaluator in evaluators)
            {
                Step(evaluator,
                    (EvaluatorSingleNode single) =>
                    {
                        score *= single.Evaluate(context);
                    });
            }
            return score;
        }
    }
}


