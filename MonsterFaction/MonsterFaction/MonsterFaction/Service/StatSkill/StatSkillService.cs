using MonsterFaction.Model;
using MonsterFaction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.Service
{
    public class StatSkillService
    {
        private StatSkillRepository repository = new TempStatSkillRepository();
        
        public StatSkillService(StatSkillRepository repository) {
            this.repository = repository;
        }

        // 나중에 StatSkill Rank 가 아니라 몬스터의 Rank 를 받을 수도.
        // TO-DO: 스킬이 겹치지 않게 하자.
        // TO-DO: 딱 해당 rank 꺼만 주지 말고, 위 아래로 확률 분포 시키자.
        public List<StatSkill> GetStatSkillsForMonster(Rank rank, int amount)
        {
            var result = new List<StatSkill>();
            while (amount-- > 0)
                result.Add(repository.GetRandomSkillOfRank(rank));
            return result;
        }
    }
}
