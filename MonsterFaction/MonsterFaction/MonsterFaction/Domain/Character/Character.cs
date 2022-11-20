namespace MonsterFaction.Domain
{
    public class Character
    {
        Stat baseStat = new();
        List<StatSkill> statSkills = new List<StatSkill>();

        public Stat getTotalStat()
        {
            Stat totalStat = base_stat;
            foreach (StatSkill statSkill in statSkills)
            {
                totalStat += statSkill.stat;
            }
            return totalStat;
        }
    }
}
