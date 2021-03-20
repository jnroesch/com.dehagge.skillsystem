using UnityEngine;

namespace Packages.com.dehagge.skillsystem.Runtime
{
    public enum SkillType
    {
        Passive,
        Active
    }
    
    [CreateAssetMenu(fileName = "New Skill", menuName = "DeHagge/New Skill")]
    public class Skill : ScriptableObject
    {
        public Sprite Icon;
        public SkillType SkillType;
    }
}
