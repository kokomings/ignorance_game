using MonsterFaction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.Repository
{
    public abstract class StatSkillRepository
    {
        protected List<StatSkill> statSkillList;
        public StatSkillRepository()
        {
            loadStatSkill();
        }

        protected abstract void loadStatSkill();

        // TO-DO: 랜덤으로 변경.
        public StatSkill GetRandomSkill() { return statSkillList.First(); }
        public StatSkill GetRandomSkillOfRank(Rank rank) { return statSkillList.Find(skill => skill.Rank == rank); }
    }
}
