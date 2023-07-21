using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    public abstract class EvaluatorSingleNode : EvaluatorNode
    {
        [LabelText("Çé¾°")]
        [Required]
        [ShowInInspector]
        [Space]
        protected SceneScriptableObject scene;


        [LabelText("È¨ÖØ")]
        [ShowInInspector]
        [Space]
        [PropertyOrder(99)]
        protected float weight = 1f;
    }
}