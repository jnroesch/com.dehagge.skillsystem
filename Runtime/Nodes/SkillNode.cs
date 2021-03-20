using System.Collections.Generic;
using System.Linq;
using XNode;
using Node = Packages.com.dehagge.nodeeditor.Runtime.Node;

namespace Packages.com.dehagge.skillsystem.Runtime.Nodes
{
    [System.Serializable]
    public class SkillNode : Node
    {
        [Input(ShowBackingValue.Never)] public SkillNode Previous;
        [Output(ShowBackingValue.Never)] public SkillNode Next;

        public Skill Skill;

        public override object GetValue(NodePort port)
        {
            return null;
        }

        public IEnumerable<SkillNode> GetNextSkillNodes()
        {
            var connections = GetOutputPort(nameof(Next)).GetConnections();
            if (!connections.Any()) return null;
            return connections.Select(connection => connection.node).Cast<SkillNode>();
        }
        
        public IEnumerable<SkillNode> GetPreviousSkillNodes()
        {
            var connections = GetInputPort(nameof(Previous)).GetConnections();
            if (!connections.Any()) return null;
            return connections.Select(connection => connection.node).Cast<SkillNode>();
        }
    }
}
