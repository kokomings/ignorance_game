using System.Collections.Generic;

namespace MonsterFaction.Characters.Ability
{
    public class TempAbilityRepository : RandomAbilityProvider
    {
        protected override void initialize()
        {
            statSkillList = new List<StatAbility>();
            statSkillList.Add(new StatAbility("Sharpness", Rank.D, new Stat { Attack = 10 }));
            statSkillList.Add(new StatAbility("Sharpness", Rank.C, new Stat { Attack = 20 }));
            statSkillList.Add(new StatAbility("Hard Skin", Rank.D, new Stat { Defense = 10 }));
            statSkillList.Add(new StatAbility("Hard Skin", Rank.C, new Stat { Defense = 20 }));
            statSkillList.Add(new StatAbility("Power", Rank.D, new Stat { Attack = 5, Defense = 5 }));
            statSkillList.Add(new StatAbility("Power", Rank.C, new Stat { Attack = 10, Defense = 10 }));
        }
    }
}
