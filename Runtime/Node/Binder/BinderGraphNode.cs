using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    [CreateNodeMenu("Utility AI/绑定器/动作绑定器集")]
    [NodeTitle("动作绑定器集")]
    public class BinderGraphNode : BinderNode
    {
        [LabelText("子图")]
        [ShowInInspector]
        [PropertyOrder(100)]
        [Required]
        private BinderGraph binderGraph;

        public IEnumerable<BinderNode> Binders => binderGraph.Binders;

        public override ScorerNode Scorers => null;
    }
}