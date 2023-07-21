using System;
using System.Reflection;
using UnityEngine;
using XNodeEditor;

namespace UtilityAI
{
    [CustomNodeEditor(typeof(AIBaseNode))]
    public class AINodeEditor : NodeEditor
    {
        private string title;

        public override void OnCreate()
        {
            base.OnCreate();
            var nodeTitleAttribute = target.GetType().GetCustomAttribute<AIBaseNode.NodeTitleAttribute>();
            if (nodeTitleAttribute != null)
            {
                title = nodeTitleAttribute.title;
            }
            if (string.IsNullOrEmpty(title))
                title = target.GetType().Name;
        }

        public override void OnHeaderGUI()
        {
            GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }
    }
}