using Domain.Sports;
using NUnit.Framework;
using System.Collections.Generic;

namespace Domain.Test.Model
{
    //test names need to be "human readable" and not just "classA" when this does that. 
    public class IdEqualsCompareTests
    {
        public static LeagueId lid1 = new LeagueId(1);
        public static LeagueId lid2 = new LeagueId(2);
        public static GameId gid1 = new GameId(1);
        public static LeagueId lid1_copy = new LeagueId(1);

        [Test]
        public void BothNull_Valid() //??desirable
        {
            LeagueId id = null;
            Assert.IsTrue(null == id);
        }

        [Test]
        public void EqualsNull_Invalid()
        {
            Assert.IsFalse(lid1.Equals(null));
        }

        [Test]
        public void ObjectEqualsNotNull_Invalid()
        {
            var o1 = (object)lid1;
            Assert.IsFalse(o1.Equals(null));
        }

        [Test]
        public void ObjectEqualsSameReference_Invalid()
        {
            var o1 = (object)lid1;
            var o1_copy = (object)lid1;
            Assert.IsTrue(o1.Equals(o1_copy));
        }

        [Test]
        public void Equals1_Invalid()
        {
            Assert.IsFalse(lid1.Equals(1));
        }

        [Test]
        public void HashSetSame_Valid()
        {
            HashSet<LeagueId> set = new HashSet<LeagueId> { lid1 };
            Assert.IsTrue(set.Contains(lid1_copy));
        }

        [Test]
        public void HashSetDiff_Invalid()
        {
            HashSet<LeagueId> set = new HashSet<LeagueId> { lid1 };
            Assert.IsFalse(set.Contains(lid2));
        }

        [Test]
        public void DifferentTypeSameValue_Invalid()
        {
            Assert.IsFalse(lid1.Equals(gid1));
        }

        [Test]
        public void SameTypeDifferentValue_Invalid()
        {
            Assert.IsFalse(lid1.Equals(lid2));
        }

        [Test]
        public void SameTypeSameValue_Valid()
        {
            Assert.IsTrue(lid1.Equals(lid1_copy));
        }
    }
}
