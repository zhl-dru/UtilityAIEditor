using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    public interface IEvaluator
    {
        float Evaluate(IAIContext context);
    }
}