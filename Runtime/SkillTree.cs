using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Packages.com.dehagge.skillsystem.Runtime.Nodes;
using UnityEngine;
using XNode;

namespace Packages.com.dehagge.skillsystem.Runtime
{
    [Serializable, CreateAssetMenu(fileName = "New Skill Tree", menuName = "DeHagge/New Skill Tree")]
    public class SkillTree : NodeGraph
    {
        public IEnumerable<Skill> GetAllSkillsInTree()
        {
            return nodes.Cast<SkillNode>().Select(node => node.Skill);
        }

        public IEnumerable<Skill> GetPrecedingSkills(Skill skill)
        {
            var skillNode = nodes.Cast<SkillNode>().FirstOrDefault(node => node.Skill == skill);
            if (skillNode == null) return null;
            var precedingNodes = skillNode.GetPreviousSkillNodes();
            return precedingNodes.IsNullOrEmpty() ? null : precedingNodes.Select(node => node.Skill);
        }

        public IEnumerable<SkillNode> GetSkillNodesWithoutPredecessors()
        {
            return nodes.Cast<SkillNode>().Where(node => node.GetPreviousSkillNodes() == null);
        }
    }
}