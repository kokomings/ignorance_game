using MonsterFaction.Characters.Ability;

namespace MonsterFaction.Characters.Monster
{
    public class WildMonster: Character
    {
        public int Level { get; private set; }
        // TODO: 지금은 Level x baseStat 에 비례해서 스탯을 증가시키는데, 좀 더 세심한 정책으로 가져가자.
        public MonsterName Name { get; private set; }
        public WildMonster(Stat stat, int level, MonsterName name) : base(stat * level) 
        {
            Level = level;
        }

        public void AddStatSkill(StatAbility statSkill)
        {
            this.characterStatus.AddSkill(statSkill);
        }
    }
}
