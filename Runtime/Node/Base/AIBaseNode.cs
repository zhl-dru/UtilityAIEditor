using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace UtilityAI
{
    public abstract class AIBaseNode : Node
    {
        protected IEnumerable<T> GetAllOnPort<T>(string fieldName) where T : AIBaseNode
        {
            NodePort port = GetPort(fieldName);
            for (int i = 0; i < port.ConnectionCount; ++i)
            {
                yield return port.GetConnection(i).node as T;
            }
        }
        protected T GetFirst<T>(string fieldName) where T : AIBaseNode
        {
            NodePort port = GetPort(fieldName);
            if (port.ConnectionCount > 0)
                return port.GetConnection(0).node as T;
            return null;
        }
        public override object GetValue(NodePort port)
        {
            return this;
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public class NodeTitleAttribute : Attribute
        {
            public string title;
            public NodeTitleAttribute(string title)
            {
                this.title = title;
            }
        }
    }
}