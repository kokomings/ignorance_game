using System.Collections.Generic;

namespace MonsterFaction.Characters
{
    public class Character
    {
        public Stat BaseStat { get; set; } = new Stat();
        private List<StatSkill> statSkills = new List<StatSkill>();

        public Character(Stat stat)
        {
            BaseStat = stat;
        }

        public void AddSkill(StatSkill skill)
        {
            statSkills.Add(skill);
        }

        public Stat GetTotalStat()
        {
            var totalStat = BaseStat;
            foreach (StatSkill statSkill in statSkills)
            {
                totalStat += statSkill.Stat;
            }
            return totalStat;
        }
    }
}
