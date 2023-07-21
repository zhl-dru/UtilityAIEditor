using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    /// <summary>
    /// 这个评估器接受一个计分器节点输入
    /// 可以用于在一个动作下使用多个计分器计算
    /// </summary>
    [CreateNodeMenu("Utility AI/评估器/计分器评估器")]
    [NodeTitle("计分器评估器")]
    public class ScorerEvaluator : EvaluatorNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        [LabelText("In")]
        public ScorerNode scorer;

        public override float Evaluate(IAIContext context)
        {
            return scorer.Scorer(context);
        }
    }
}