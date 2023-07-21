using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    /// <summary>
    /// 将评估方法写在SceneScriptableObject中
    /// 直接使用SceneScriptableObject返回的值
    /// </summary>
    [CreateNodeMenu("Utility AI/评估器/自定义评估器")]
    [NodeTitle("自定义评估器")]
    public class CustomizeEvaluator : EvaluatorSingleNode
    {
        public override float Evaluate(IAIContext context)
        {
            return scene.Evaluate(context);
        }
    }
}