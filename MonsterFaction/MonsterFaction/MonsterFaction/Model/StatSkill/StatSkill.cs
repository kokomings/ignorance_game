namespace MonsterFaction.Model
{
    public readonly struct StatSkill
    {
        public readonly string Name { get; init; }
        public readonly Rank Rank { get; init; }
        public readonly Stat Stat { get; init; }

        public StatSkill(string name, Rank rank, Stat stat)
        {
            Name = name;
            Stat = stat;
            Rank = rank;
        }
    }
    public enum Rank
    {
        S, A, B, C, D
    }
}

