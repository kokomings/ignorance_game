using System.Collections.Generic;
using MonsterFaction.Characters.Ability;

namespace MonsterFaction.Characters
{
    public class CharacterStatus
    {
        public Stat BaseStat { get; set; } = new Stat();
        private List<StatAbility> statSkills = new List<StatAbility>();

        public CharacterStatus(Stat stat)
        {
            BaseStat = stat;
        }

        public void AddSkill(StatAbility skill)
        {
            statSkills.Add(skill);
        }

        public Stat GetTotalStat()
        {
            var totalStat = BaseStat;
            foreach (StatAbility statSkill in statSkills)
            {
                totalStat += statSkill.Stat;
            }
            return totalStat;
        }
    }
}
