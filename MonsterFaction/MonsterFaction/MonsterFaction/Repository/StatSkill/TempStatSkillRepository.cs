using MonsterFaction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.Repository
{
    public class TempStatSkillRepository: StatSkillRepository
    {
        protected override void loadStatSkill()
        {
            this.statSkillList = new List<StatSkill>();
            statSkillList.Add(new StatSkill("Sharpness", Rank.D, new Stat { Attack = 10 }));
            statSkillList.Add(new StatSkill("Sharpness", Rank.C, new Stat { Attack = 20 }));
            statSkillList.Add(new StatSkill("Hard Skin", Rank.D, new Stat { Defense = 10 }));
            statSkillList.Add(new StatSkill("Hard Skin", Rank.C, new Stat { Defense = 20 }));
            statSkillList.Add(new StatSkill("Power", Rank.D, new Stat { Attack = 5, Defense = 5 }));
            statSkillList.Add(new StatSkill("Power", Rank.C, new Stat { Attack = 10, Defense = 10 }));
        }
    }
}
