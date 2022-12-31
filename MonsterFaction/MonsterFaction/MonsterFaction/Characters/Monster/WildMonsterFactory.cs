namespace MonsterFaction.Characters.Monster
{
    public class WildMonsterFactory
    {
        private RandomStatSkillProvider repository = new TempStatSkillRepository();
        private MonsterDictionary monsterDictionary = new();

        public WildMonster CreateMonster(MonsterName name, int level)
        {
            var newMonster = new WildMonster(monsterDictionary.GetStat(name), level, name);
            newMonster.AddStatSkill(repository.GetRandomSkillOfRank(getRandomRank(level)));
            newMonster.AddStatSkill(repository.GetRandomSkillOfRank(getRandomRank(level)));
            newMonster.AddStatSkill(repository.GetRandomSkillOfRank(getRandomRank(level)));
            return newMonster;
        }

        private Rank getRandomRank(int level)
        {
            // TODO: level 에 따라 확률 조정.
            return Rank.D;
        }
    }
}
