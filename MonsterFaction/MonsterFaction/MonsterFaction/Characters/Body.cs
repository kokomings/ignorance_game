using System.Collections.Generic;
using System.Linq;
using MonsterFaction.Characters.Ability;

namespace MonsterFaction.Characters
{
    public class Body
    {
        private int baseHP;
        private int buffHP;
        private int currentHP;
        private List<Buff> buffs = new List<Buff>();

        public int CurrentHP { get => currentHP; }
        public int MaxHP { get => baseHP + buffHP; }
        public bool IsDead { get => currentHP <= 0; }

        private Stat buffStat;
        public Stat BuffStat { get => buffStat; }

        public Body(int maxHP)
        {
            baseHP = maxHP;
            currentHP = maxHP;
            sync();
        }

        public void SetBaseMaxHP(int newHP)
        {
            int gap = newHP - baseHP;

            baseHP = newHP;

            if (gap > 0 && !IsDead)
                currentHP += gap;
            sync();
        }
        public void AddBuff(int duration, Stat stat)
        {
            buffs.Add(new Buff(duration, stat));
            sync();
        }

        public void TimeFlow()
        {
            buffs = buffs.Select(buff => new Buff(buff.Duration - 1, buff.Stat)).ToList();
            buffs.RemoveAll(buff => buff.Duration <= 0);
            sync();
        }

        public void Heal(int heal)
        {
            if (!IsDead)
                currentHP += heal;
        }

        public void Damaged(int damage)
        {
            currentHP -= damage;
            if (currentHP < 0)
                currentHP = 0;
        }
        private void sync()
        {
            Stat sum = new Stat();
            foreach (var buff in buffs)
            {
                sum += buff.Stat;
            }
            buffStat = sum;
            setBuffMaxHP(sum.HP);
        }
        private void setBuffMaxHP(int newHP)
        {
            int gap = newHP - buffHP;

            buffHP = newHP;

            if (gap > 0 && !IsDead)
                currentHP += gap;

            if (currentHP > baseHP + buffHP)
                currentHP = baseHP;
        }
    }
    // 밖으로 뺄 수도 있음.
    public readonly struct Buff
    {
        // int 말고 double 로 현실 시간으로 표현하는 방법도 있을 듯.
        public readonly int Duration { get; }
        public readonly Stat Stat { get; }

        public Buff(int duration, Stat stat)
        {
            Duration = duration;
            Stat = stat;
        }
    }
}
