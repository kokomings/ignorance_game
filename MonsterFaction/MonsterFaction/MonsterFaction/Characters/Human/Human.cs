using MonsterFaction.Characters.Ability;

namespace MonsterFaction.Characters
{
    public class Human : Character
    {
        public Human() : base(new Stat { HP = 100, MoveSpeed = 1.0f })
        {
        }
    }
}
