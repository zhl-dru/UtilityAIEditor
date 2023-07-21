using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    public interface IScorer
    {
        float Scorer(IAIContext context);
    }
}