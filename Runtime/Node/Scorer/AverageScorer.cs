using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    [CreateNodeMenu("Utility AI/计分器/平均计分器")]
    [NodeTitle("平均计分器")]
    public class AverageScorer : ScorerNode
    {
        public override float Scorer(IAIContext context)
        {
            float score = 0;
            int num = 0;
            var evaluators = GetAllOnPort<EvaluatorNode>(nameof(evaluator));
            foreach (var evaluator in evaluators)
            {
                Step(evaluator,
                (EvaluatorSingleNode single) =>
                {
                    score += single.Evaluate(context);
                    num++;
                });
            }
            return score / num;
        }
    }
}