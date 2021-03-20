using System;

namespace Packages.com.dehagge.skillsystem.Runtime.SkillRequirements
{
    public class SkillPointAmount : SkillRequirement
    {
        private readonly int _skillPointsNeeded;

        public SkillPointAmount(int skillPointsNeeded)
        {
            _skillPointsNeeded = skillPointsNeeded;
        }
        
        public override bool IsRequirementFulfilled()
        {
            return 1 > _skillPointsNeeded;
        }
    }
}