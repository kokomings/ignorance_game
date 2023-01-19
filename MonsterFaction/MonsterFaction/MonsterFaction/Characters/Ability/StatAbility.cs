using MonsterFaction.Characters.Ability;

namespace MonsterFaction.Characters.Ability
{
    public readonly struct StatAbility : IAbility
    {
        public readonly string Name { get; init; }
        public readonly Rank Rank { get; init; }
        public readonly Stat Stat { get; init; }

        public StatAbility(string name, Rank rank, Stat stat)
        {
            Name = name;
            Stat = stat;
            Rank = rank;
        }
    }
}

