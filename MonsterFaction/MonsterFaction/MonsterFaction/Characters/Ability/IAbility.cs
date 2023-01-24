namespace MonsterFaction.Characters.Ability
{
    public interface IAbility
    {
        public string Name { get; }
        public Rank Rank { get; }
    }
    public enum Rank
    {
        S, A, B, C, D
    }
}
