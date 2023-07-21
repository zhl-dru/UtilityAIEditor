using Sirenix.OdinInspector;
using UnityEngine;

namespace UtilityAI
{
    [CreateNodeMenu("Utility AI/ÆÀ¹ÀÆ÷/ÇúÏßÆÀ¹ÀÆ÷")]
    [NodeTitle("ÇúÏßÆÀ¹ÀÆ÷")]
    public class CurveEvaluator : EvaluatorSingleNode
    {
        [LabelText("ÇúÏß")]
        [SerializeField]
        private AnimationCurve curve;



        public override float Evaluate(IAIContext context)
        {
            return curve.Evaluate(scene.Evaluate(context));
        }
    }
}