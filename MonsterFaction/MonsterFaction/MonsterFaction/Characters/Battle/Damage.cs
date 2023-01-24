using System;

namespace MonsterFaction.Characters.Battle
{
    public class Damage
    {
        public int amount;
        public DamageType damageType;

        public Damage(int amount, DamageType damageType) 
        { 
            this.amount = amount;
            this.damageType = damageType;
        }

        public int calculate(int defense)
        {
            return Math.Min(amount - defense, 1);
        }
    }

    public enum DamageType
    {
        Normal
    }
}
