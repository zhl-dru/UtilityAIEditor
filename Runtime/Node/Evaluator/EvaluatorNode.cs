using Sirenix.OdinInspector;
using System;
using XNode;

namespace UtilityAI
{
    [NodeTint("#A9DFBF")]
    public abstract class EvaluatorNode : AIBaseNode, IEvaluator
    {
        [Output(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        [LabelText("Out")]
        public EvaluatorNode evaluator;

#if UNITY_EDITOR
        [LabelText("注释")]
        [MultiLineProperty]
        public string Annotate;
#endif

        public abstract float Evaluate(IAIContext context);
    }
}