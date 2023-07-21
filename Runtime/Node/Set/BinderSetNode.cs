using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    [DisallowMultipleNodes]
    [NodeTint("#641E16")]
    [CreateNodeMenu("Utility AI/子图输出/动作绑定器集")]
    [NodeTitle("动作绑定器集")]
    public class BinderSetNode : AIBaseNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Strict)]
        [LabelText("In")]
        public BinderNode binder;

        public IEnumerable<BinderNode> Binders => GetAllOnPort<BinderNode>(nameof(binder));
    }
}