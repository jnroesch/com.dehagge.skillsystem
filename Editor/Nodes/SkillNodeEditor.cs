using JetBrains.Annotations;
using Packages.com.dehagge.skillsystem.Runtime.Nodes;
using UnityEngine;
using XNodeEditor;

namespace Packages.com.dehagge.skillsystem.Editor.Nodes
{
    [UsedImplicitly]
    [CustomNodeEditorAttribute(typeof(SkillNode))]
    public class SkillNodeEditor : NodeEditor
    {
        public override void OnHeaderGUI()
        {
            var node = target as SkillNode;
            var skill = node.Skill;
            if (skill != null)
            {
                GUILayout.Label(skill.name, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Box(skill.Icon != null ? skill.Icon.texture : Texture2D.whiteTexture);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }
            else
            {
                base.OnHeaderGUI();
            }
        }
    }
}