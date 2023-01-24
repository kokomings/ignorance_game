using MonsterFaction.Characters.Ability;
using MonsterFaction.Characters.Battle;
using System.Security.Cryptography.X509Certificates;

namespace MonsterFaction.Characters
{
    public class Human : Character
    {
        public Human() : base(new Stat { HP = 100, MoveSpeed = 1.0f }) { }
        public Damage Damage = new Damage(10, DamageType.Normal);
    }
}
