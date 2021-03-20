using System.Collections.Generic;
using System.Linq;
using Packages.com.dehagge.skillsystem.Runtime.Nodes;
using UnityEngine;
using Zenject;

namespace Packages.com.dehagge.skillsystem.Runtime.Services.SkillService
{
    public class DefaultSkillService : ISkillService
    {
        private readonly SkillTree _skillTree;

        private Dictionary<Skill, bool> _unlockedSkills;
        
        [Inject]
        public DefaultSkillService(SkillTree skillTree)
        {
            _skillTree = skillTree;

            InitializeSkillDictionary();

            var initialSkills = GetInitialSkills();
            UnlockInitialSkills(initialSkills);
        }

        private void InitializeSkillDictionary()
        {
            _unlockedSkills = new Dictionary<Skill, bool>();
            foreach (var skill in _skillTree.GetAllSkillsInTree())
            {
                _unlockedSkills.Add(skill, false);
            }
        }

        private IEnumerable<Skill> GetInitialSkills()
        {
            var nodesWithoutPredecessor = _skillTree.GetSkillNodesWithoutPredecessors();
            var skills = nodesWithoutPredecessor.Select(node => node.Skill);
            return skills;
        }

        public bool IsSkillUnlocked(Skill skill)
        {
            return _unlockedSkills[skill];
        }

        private void UnlockInitialSkills(IEnumerable<Skill> initialSkills)
        {
            foreach (var skill in initialSkills)
            {
                TryUnlockSkill(skill);
            }
        }
        
        public bool TryUnlockSkill(Skill skill)
        {
            if (IsSkillUnlocked(skill)) return false;
            
            var precedingSkills = _skillTree.GetPrecedingSkills(skill);
            if (precedingSkills == null || !precedingSkills.Any())
            {
                return UnlockSkill(skill);
            }
            
            if (precedingSkills.Any(precedingSkill => !IsSkillUnlocked(precedingSkill)))
            {
                Debug.Log("not all requirements met");
                return false;
            }

            return UnlockSkill(skill);
        }

        private bool UnlockSkill(Skill skill)
        {
            Debug.Log("successfully unlocked "+skill.name);
            _unlockedSkills[skill] = true;
            return true;
        }
    }
}