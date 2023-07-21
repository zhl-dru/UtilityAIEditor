using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/动作绑定集")]
    public class BinderGraph : AIBaseGraph
    {
        private BinderSetNode binderSet;
        public IEnumerable<BinderNode> Binders => BinderSet.Binders;
        public BinderSetNode BinderSet => GetUniqueNode(binderSet);
    }
}