using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace UtilityAI
{
    [NodeTint("#F44336")]
    public abstract class SelectorNode : AIBaseNode, ISelector
    {
        [Input(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Strict)]
        [LabelText("In")]
        public BinderNode binder;
        [Output(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        [LabelText("Out")]
        public SelectorNode selector;

        public IEnumerable<BinderNode> Binders => GetAllOnPort<BinderNode>(nameof(binder));
        public abstract IAction Select(IAIContext context);

        protected void Step(BinderNode binder, Action<BinderSingleNode> action)
        {
            if (binder != null)
            {
                if (binder is BinderSingleNode)
                {
                    var node = binder as BinderSingleNode;
                    action.Invoke(node);
                }
                else if (binder is BinderGraphNode)
                {
                    var node = binder as BinderGraphNode;
                    foreach (var n in node.Binders)
                    {
                        Step(n, action);
                    }
                }
            }
        }
    }
}