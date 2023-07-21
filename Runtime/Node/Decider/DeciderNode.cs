using Sirenix.OdinInspector;
using UnityEngine;

namespace UtilityAI
{
    [DisallowMultipleNodes]
    [NodeTint("#5DADE2")]
    [CreateNodeMenu("Utility AI/决策器/决策器")]
    [NodeTitle("决策器")]
    public class DeciderNode : AIBaseNode
    {
        [LabelText("更新间隔")]
        [ShowInInspector]
        private float updateInterval;
        [Input(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        [LabelText("In")]
        [Space]
        public SelectorNode selector;

        private SelectorNode Selector => GetFirst<SelectorNode>(nameof(selector));
        public float UpdateInterval => updateInterval;

        public IAction Decision(IAIContext context)
        {
            return Selector.Select(context);
        }
    }
}