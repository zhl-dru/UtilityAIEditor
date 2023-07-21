using UnityEngine;

namespace UtilityAI
{
    /// <summary>
    /// Scene表明一个情境
    /// 根据AIContext表达一种处境
    /// 例如剩余生命值的比例
    /// 通过解析AIContext,应当返回一个[0f,1f]内的值
    /// </summary>
    public abstract class SceneScriptableObject : ScriptableObject, IEvaluator
    {
        public abstract float Evaluate(IAIContext context);
    }
}