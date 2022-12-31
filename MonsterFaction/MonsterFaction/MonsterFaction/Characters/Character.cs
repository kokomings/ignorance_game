namespace MonsterFaction.Characters
{
    abstract public class Character
    {
        protected readonly CharacterStatus characterStatus;
        protected Body body;

        public Character(Stat baseStat)
        {
            this.characterStatus = new CharacterStatus(baseStat);
            this.body = new Body(baseStat.HP);
        }
    }
}
