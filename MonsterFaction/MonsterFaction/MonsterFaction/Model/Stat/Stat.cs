namespace MonsterFaction.Model
{
    public readonly struct Stat
    {
        public readonly int HP { get; init; }
        public readonly int Attack { get; init; }
        public readonly int Defense { get; init; }
        public static Stat operator +(Stat left, Stat right)
        {
            return new Stat
            {
                HP = left.HP + right.HP,
                Attack = left.Attack + right.Attack,
                Defense = left.Defense + right.Defense
            };
        }
    }
}
