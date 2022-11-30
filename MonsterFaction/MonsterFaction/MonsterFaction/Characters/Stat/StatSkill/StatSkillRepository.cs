using System.Collections.Generic;
using System.Linq;

namespace MonsterFaction.Characters
{
    public abstract class StatSkillRepository
    {
        protected List<StatSkill> statSkillList;
        public StatSkillRepository()
        {
            initialize();
        }

        protected abstract void initialize();

        // TO-DO: 랜덤으로 변경.
        public StatSkill GetRandomSkill() { return statSkillList.First(); }
        public StatSkill GetRandomSkillOfRank(Rank rank) { return statSkillList.Find(skill => skill.Rank == rank); }
    }
}
