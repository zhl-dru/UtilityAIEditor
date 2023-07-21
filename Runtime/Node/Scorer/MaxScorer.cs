namespace UtilityAI
{
    [CreateNodeMenu("Utility AI/计分器/取高计分器")]
    [NodeTitle("取高计分器")]
    public class MaxScorer : ScorerNode
    {
        public override float Scorer(IAIContext context)
        {
            float score = float.MinValue;
            var evaluators = GetAllOnPort<EvaluatorNode>(nameof(evaluator));
            foreach (var evaluator in evaluators)
            {
                Step(evaluator,
                    (EvaluatorSingleNode single) =>
                    {
                        float value = single.Evaluate(context);
                        if (score < value) score = value;
                    });
            }
            return score;
        }
    }
}
