using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace UtilityAI
{
    public abstract class ScorerNode : AIBaseNode, IScorer
    {
        [Input(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Strict)]
        [LabelText("In")]
        public EvaluatorNode evaluator;
        [Output(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        [LabelText("Out")]
        public ScorerNode scorer;

        public abstract float Scorer(IAIContext context);

        protected void Step(EvaluatorNode evaluator, Action<EvaluatorSingleNode> action)
        {
            if (evaluator != null)
            {
                if (evaluator is EvaluatorSingleNode)
                {
                    var node = evaluator as EvaluatorSingleNode;
                    action.Invoke(node);
                }
                else if (evaluator is EvaluatorGraphNode)
                {
                    var node = evaluator as EvaluatorGraphNode;
                    foreach (var n in node.Evaluators)
                    {
                        Step(n, action);
                    }
                }
            }
        }
    }
}