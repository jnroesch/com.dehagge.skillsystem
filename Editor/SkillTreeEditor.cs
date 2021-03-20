using JetBrains.Annotations;
using Packages.com.dehagge.skillsystem.Runtime;
using XNodeEditor;

namespace Packages.com.dehagge.skillsystem.Editor
{
    [UsedImplicitly]
    [CustomNodeGraphEditor(typeof(SkillTree))]
    public class SkillTreeEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(System.Type type)
        {
            return $"Nodes/{type.Name}";
        }
    }
}