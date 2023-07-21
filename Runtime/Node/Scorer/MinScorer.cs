using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    [CreateNodeMenu("Utility AI/计分器/取低计分器")]
    [NodeTitle("取低计分器")]
    public class MinScorer : ScorerNode
    {
        public override float Scorer(IAIContext context)
        {
            float score = float.MaxValue;
            var evaluators = GetAllOnPort<EvaluatorNode>(nameof(evaluator));
            foreach (var evaluator in evaluators)
            {
                Step(evaluator,
                    (EvaluatorSingleNode single) =>
                    {
                        float value = single.Evaluate(context);
                        if (score > value) score = value;
                    });
            }
            return score;
        }
    }
}
