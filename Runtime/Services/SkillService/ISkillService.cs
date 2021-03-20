namespace Packages.com.dehagge.skillsystem.Runtime.Services.SkillService
{
    public interface ISkillService
    {
        bool TryUnlockSkill(Skill skill);
        bool IsSkillUnlocked(Skill skill);
    }
}