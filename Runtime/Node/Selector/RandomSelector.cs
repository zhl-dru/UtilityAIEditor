using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UtilityAI
{
    /// <summary>
    /// 指定一个数量n
    /// 将从得分最高的n个动作中随机选择一个
    /// 当n大于所有可用动作时,从所有动作中随机选择
    /// </summary>
    [CreateNodeMenu("Utility AI/选择器/随机选择器")]
    [NodeTitle("随机选择器")]
    public class RandomSelector : SelectorNode
    {
        [LabelText("数量")]
        [ShowInInspector]
        private int count;

        public override IAction Select(IAIContext context)
        {
            List<ValueIndexPair> pairs = new List<ValueIndexPair>();
            List<BinderSingleNode> binderList = new List<BinderSingleNode>();
            var binders = GetAllOnPort<BinderNode>(nameof(binder));
            foreach (var binder in binders)
            {
                Step(binder,
                    (BinderSingleNode single) =>
                    {
                        float value = single.Scorers.Scorer(context);
                        binderList.Add(single);
                        pairs.Add(new ValueIndexPair(value, binderList.Count - 1));
                    }
                    );
            }
            List<BinderSingleNode> resultList = new List<BinderSingleNode>();
            int i = 0;
            foreach (var pair in pairs.OrderByDescending(x => x.Score))
            {
                resultList.Add(binderList[pair.Index]);
                i++;
                if (i > count - 1) break;
            }
            int index = Random.Range(0, resultList.Count);
            return resultList[index].Action;
        }

        private struct ValueIndexPair
        {
            public float Score;
            public int Index;

            public ValueIndexPair(float score, int index)
            {
                Score = score;
                Index = index;
            }
        }
    }
}