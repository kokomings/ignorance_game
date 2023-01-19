using System.Collections.Generic;
using System.Linq;

namespace MonsterFaction.Characters.Ability
{
    public abstract class RandomAbilityProvider
    {
        protected List<StatAbility> statSkillList;
        public RandomAbilityProvider()
        {
            initialize();
        }

        protected abstract void initialize();

        // TO-DO: 랜덤으로 변경.
        public StatAbility GetRandomSkill() { return statSkillList.First(); }
        public StatAbility GetRandomSkillOfRank(Rank rank) { return statSkillList.Find(skill => skill.Rank == rank); }
    }
}
