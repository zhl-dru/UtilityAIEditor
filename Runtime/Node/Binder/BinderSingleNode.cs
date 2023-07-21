using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    [CreateNodeMenu("Utility AI/绑定器/动作绑定器")]
    [NodeTitle("动作绑定器")]
    public class BinderSingleNode : BinderNode
    {
        [LabelText("动作")]
        [ShowInInspector]
        [Required]
        private ActionScriptableObject action;
        [Input(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        [LabelText("In")]
        public ScorerNode scorer;



        public override ScorerNode Scorers => GetFirst<ScorerNode>(nameof(scorer));
        public ActionScriptableObject Action => action;
    }
}