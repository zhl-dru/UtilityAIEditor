using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace UtilityAI
{
    public abstract class AIBaseGraph : NodeGraph
    {
        public T GetUniqueNode<T>(T t) where T : Node
        {
            if (t != null)
            {
                return t;
            }
            else
            {
                t = FindUniqueNode<T>();
                if (t == null)
                {
                    Debug.LogError(string.Format("图表{0}中没有{1}节点", name, nameof(T)));
                }
                return t;
            }
        }

        /// <summary>
        /// 查找图表中的第一个特定类型的节点
        /// 没有特别的保证,应该总是用于查找标记为[DisallowMultipleNodes]的节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T FindUniqueNode<T>() where T : Node
        {
            var result = nodes.FirstOrDefault(x => x is T);
            if (result != null)
            {
                return result as T;
            }
            return null;
        }
    }
}