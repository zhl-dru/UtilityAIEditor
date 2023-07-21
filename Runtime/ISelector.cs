using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    public interface ISelector
    {
        IAction Select(IAIContext context);
    }
}