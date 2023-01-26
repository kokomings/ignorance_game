using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterFaction.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.Util.Tests
{
    [TestClass()]
    public class TimeLimitedCollectionTests
    {
        [TestMethod()]
        public void AddTest()
        {
            TimeLimitedCollection<string> collection = new();
            int count = 0;
            foreach (var i in collection) count++;
            Assert.AreEqual(0, count);

            collection.Add("a", 10);
            collection.Add("b", 20);

            foreach (var i in collection) count++;
            Assert.AreEqual(2, count);
            Console.WriteLine(count);
        }

        [TestMethod()]
        public void TickTest()
        {
            TimeLimitedCollection<string> list = new();
            
            list.Add("a", 1);
            list.Add("b", 2);
            Assert.AreEqual("a b", string.Join(" ", list.ToArray())); // a:1, b:2

            list.Tick();
            Assert.AreEqual("b", string.Join(" ", list.ToArray()));  // a:0, b:1

            list.Add("c", 1);
            Assert.AreEqual("b c", string.Join(" ", list.ToArray())); // a:0, b:1, c:1

            list.Tick();
            Assert.AreEqual("", string.Join(" ", list.ToArray()));  // a:-1, b:0, c:0
        }
    }
}