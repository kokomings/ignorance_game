namespace MonsterFaction.Domain
{
    public struct Stat
    {
        int attack;
        int defense;

        public Stat(int attack, int defense)
        {
            this.attack = attack;
            this.defense = defense;
        }

        public Stat()
        {
            Stat(0, 0);
        }

        public static Stat operator +(Stat left, Stat right)
        {
            return Stat(
                left.attack + right.attack, 
                left.defense + right.defense
                );
        }
    }
}
