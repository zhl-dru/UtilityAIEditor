using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    /// <summary>
    /// Action是一个动作
    /// AI最终用于执行的方案
    /// </summary>
    public abstract class ActionScriptableObject : ScriptableObject, IAction
    {
        public abstract void Execute(IAIContext context);
    }
}