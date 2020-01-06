using Domain.Sports;
using NUnit.Framework;

namespace Domain.Test.Model
{
    public class EntityEqualsTests
    {
        public static League nba1 = LeagueFactory.NBA(1);
        public static League nba1_copy = LeagueFactory.NBA(1);
        public static League nhl1 = LeagueFactory.NHL(1);
        public static Conference c1 = Conference.New(nba1, 1, "a", "a");

        [Test]
        public void Null_Invalid()
        {
            //AreEqual doesn't call object.Equals
            Assert.IsFalse((nba1 as object).Equals(null));
        }

        [Test]
        public void SameReference_Valid()
        {
            Assert.IsTrue((nba1 as object).Equals((object)nba1));
        }

        [Test]
        public void NonEntity_Invalid()
        {
            Assert.IsFalse(nba1.Equals("abc"));
        }

        [Test]
        public void DifferentEntityTypeSameId_Invalid()
        {
            Assert.IsFalse(nba1.Equals(c1));
        }

        [Test]
        public void DifferentReferenceSameId_Valid()
        {
            Assert.IsTrue(nba1.Equals(nba1_copy));
        }

        [Test]
        public void DifferentReferenceDifferentId_Invalid()
        {
            Assert.IsFalse(nba1.Equals(nhl1));
        }

        [Test]
        public void ToStringTests()
        {
            //var a = l1.ToString();
            //var b = l1.Value.ToString();

            var s1 = nba1.ToString();
            var s1_copy = nba1_copy.ToString();
            var s2 = nhl1.ToString();
            var s1_conference = c1.ToString();

            Assert.AreEqual(s1, s1_copy);
            Assert.AreNotEqual(s1, s2);
            Assert.AreNotEqual(s1, s1_conference);
        }

        [Test]
        public void HashCodeTests()
        {
            var h1 = nba1.GetHashCode();
            var h1_copy = nba1_copy.GetHashCode();
            var h2 = nhl1.GetHashCode();
            var h1_conference = c1.GetHashCode();

            Assert.AreEqual(h1, h1_copy);
            Assert.AreNotEqual(h1, h2);
            Assert.AreNotEqual(h1, h1_conference);
        }
    }
}
