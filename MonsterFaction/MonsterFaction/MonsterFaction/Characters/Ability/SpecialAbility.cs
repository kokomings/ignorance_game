using MonsterFaction.Characters.Ability;

namespace MonsterFaction.Characters
{
    // 동작을 하드코딩 해야하는 어빌리티. 나중에 분류가 잘 되면 분리 가능.
    public readonly struct SpecialAbility : IAbility
    {
        public readonly string Name { get; init; }
        public readonly Rank Rank { get; init; }

        public SpecialAbility(string name, Rank rank)
        {
            Name = name;
            Rank = rank;
        }
    }
}
