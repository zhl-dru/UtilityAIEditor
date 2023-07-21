using Sirenix.OdinInspector;
using UnityEngine;

namespace UtilityAI
{
    /// <summary>
    /// 指定一个值,
    /// 大于该值时
    /// 如果inversion = false
    /// 返回1,否则返回0
    /// 否则相反
    /// </summary>
    [CreateNodeMenu("Utility AI/评估器/阈值评估器")]
    [NodeTitle("阈值评估器")]
    public class ValueEvaluator : EvaluatorSingleNode
    {
        [LabelText("阈值")]
        [SerializeField]
        private float value = 0.5f;
        [LabelText("反转")]
        [SerializeField]
        private bool inversion = false;

        public override float Evaluate(IAIContext context)
        {
            if (scene.Evaluate(context) > value)
            {
                return (inversion ? 0f : 1f) * weight;
            }
            else
            {
                return (inversion ? 1f : 0f) * weight;
            }
        }
    }
}