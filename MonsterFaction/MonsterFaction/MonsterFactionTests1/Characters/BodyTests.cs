using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonsterFaction.Characters.Tests
{
    [TestClass()]
    public class BodyTests
    {
        [TestMethod()]
        public void SetMaxHPTest()
        {
            Body body = new Body(100);
            Assert.AreEqual(100, body.CurrentHP);

            body.SetBaseMaxHP(120);
            Assert.AreEqual(120, body.CurrentHP);

            body.Damaged(100);
            Assert.AreEqual(20, body.CurrentHP);

            body.SetBaseMaxHP(100);
            Assert.AreEqual(20, body.CurrentHP);

            body.SetBaseMaxHP(180);
            Assert.AreEqual(100, body.CurrentHP);
        }

        [TestMethod()]
        public void GetBuffStatTest()
        {
            Body body = new Body(100);

            body.AddBuff(1, new Stat { Attack = 10 });
            body.AddBuff(1, new Stat { Defense = 9 });
            body.AddBuff(1, new Stat { Attack = 2, Defense = 2 });

            Assert.AreEqual(new Stat { Attack = 12, Defense = 11 }, body.BuffStat);
        }

        [TestMethod()]
        public void AddBuffHpTest()
        {
            Body body = new Body(100);

            body.AddBuff(1, new Stat { HP = 20 });
            Assert.AreEqual(120, body.MaxHP);
            Assert.AreEqual(120, body.CurrentHP);

            body.Damaged(20);
            body.AddBuff(1, new Stat { HP = 30 });
            Assert.AreEqual(150, body.MaxHP);
            Assert.AreEqual(130, body.CurrentHP);
        }

        [TestMethod()]
        public void TimeFlowTest()
        {
            Body body = new Body(100);

            body.AddBuff(1, new Stat { HP = 20 });
            body.AddBuff(2, new Stat { Attack = 10 });
            body.AddBuff(3, new Stat { Defense = 9 });
            body.AddBuff(4, new Stat { Attack = 2, Defense = 2 });
            Assert.AreEqual(new Stat { HP = 20, Attack = 12, Defense = 11 }, body.BuffStat);
            Assert.AreEqual(120, body.MaxHP);

            body.TimeFlow();
            Assert.AreEqual(new Stat { Attack = 12, Defense = 11 }, body.BuffStat);
            Assert.AreEqual(100, body.MaxHP);

            body.TimeFlow();
            Assert.AreEqual(new Stat { Attack = 2, Defense = 11 }, body.BuffStat);

            body.TimeFlow();
            Assert.AreEqual(new Stat { Attack = 2, Defense = 2 }, body.BuffStat);

            body.TimeFlow();
            Assert.AreEqual(new Stat(), body.BuffStat);
        }

        [TestMethod()]
        public void DeadTest()
        {
            Body body = new Body(100);
            body.Damaged(120);

            Assert.AreEqual(0, body.CurrentHP);
            Assert.IsTrue(body.IsDead);

            body.Heal(100);
            Assert.AreEqual(0, body.CurrentHP);
            Assert.IsTrue(body.IsDead);

            body.AddBuff(1, new Stat { HP = 20 });
            body.SetBaseMaxHP(150);
            Assert.AreEqual(0, body.CurrentHP);
            Assert.IsTrue(body.IsDead);
        }
    }
}