using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonsterFaction.Characters.Tests
{
    [TestClass()]
    public class CharacterStatusTests
    {
        [TestMethod()]
        public void GetTotalStatTest()
        {
            var stat1 = new Stat { Attack = 10 };
            var stat2 = new Stat { Defense = 22 };
            var stat3 = new Stat { Attack = 7, Defense = 7 };

            var character = new CharacterStatus(stat1);
            character.AddSkill(new StatSkill { Stat = stat2 });
            character.AddSkill(new StatSkill { Stat = stat3 });

            Assert.AreEqual(
                stat1 + stat2 + stat3,
                character.GetTotalStat()
                );
        }
    }
}