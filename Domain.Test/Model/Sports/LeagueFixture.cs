using Domain.Sports;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Domain.Test.Model.Sports
{
    [TestFixture]
    public class LeagueFixture
    {
        /// <summary>
        /// ValueObject are compared by list of Properties, but Entity either by reference or Id, only!
        /// NHL(1) == NBA(1). Likewise, L1.Team(1) == L2.Team(1)
        /// </summary>

        [TestCaseSource(nameof(AddConference_TestCases))]
        public bool AddConference(League league, Conference conf)
        {
            return league.AddConference(conf) == null;
        }

        public static IEnumerable<TestCaseData> AddConference_TestCases()
        {
            string s = "{m}_";
            var league1 = LeagueFactory.NBA(1);
            var other1 = LeagueFactory.NHL(2);
            yield return new TestCaseData(league1, Conference.New(league1, 1, "a", "b")).SetName(s + "Valid").Returns(true);
            yield return new TestCaseData(league1, Conference.New(league1, 2, "a", "b1")).SetName(s + "NameNotUnique").Returns(false);
            yield return new TestCaseData(league1, Conference.New(league1, 3, "a1", "b")).SetName(s + "AbbrNotUnique").Returns(false);
            yield return new TestCaseData(league1, Conference.New(other1, 4, "a2", "b2")).SetName(s + "WrongLeague").Returns(false);
        }

        [TestCaseSource(nameof(AddDivision_TestCases))]
        public bool AddDivision(League league, Division div)
        {
            return league.AddDivision(div) == null;
        }

        public static IEnumerable<TestCaseData> AddDivision_TestCases()
        {
            string s = "{m}_";
            var league1 = LeagueFactory.NBA(1);
            var other1 = LeagueFactory.NHL(2);
            yield return new TestCaseData(league1, Division.New(league1, 1, "a", "b")).SetName(s + "Valid").Returns(true);
            yield return new TestCaseData(league1, Division.New(league1, 2, "a", "b1")).SetName(s + "NameNotUnique").Returns(false);
            yield return new TestCaseData(league1, Division.New(league1, 3, "a1", "b")).SetName(s + "AbbrNotUnique").Returns(false);
            yield return new TestCaseData(league1, Division.New(other1, 4, "a2", "b2")).SetName(s + "WrongLeague").Returns(false);
        }

        [TestCaseSource(nameof(AddTeam_TestCases))]
        public bool AddTeam(League league, Team team)
        {
            return league.AddTeam(team) == null;
        }

        public static IEnumerable<TestCaseData> AddTeam_TestCases()
        {
            string s = "{m}_";
            var league1 = LeagueFactory.NBA(1);
            var other1 = LeagueFactory.NHL(2);
            yield return new TestCaseData(league1, Team.New(league1, 1, "a", "b")).SetName(s + "Valid").Returns(true);
            yield return new TestCaseData(league1, Team.New(league1, 2, "a", "b1")).SetName(s + "NameNotUnique").Returns(false);
            yield return new TestCaseData(league1, Team.New(league1, 3, "a1", "b")).SetName(s + "AbbrNotUnique").Returns(false);
            yield return new TestCaseData(league1, Team.New(other1, 4, "a2", "b2")).SetName(s + "WrongLeague").Returns(false);
        }

        [TestCaseSource(nameof(AddSeason_TestCases))]
        public bool AddSeason(League league, Season season)
        {
            return league.AddSeason(season) == null;
        }

        public static Range<DateTime> NewRange(int x) => new Range<DateTime>(new DateTime(2018, 1, x), new DateTime(2018, 1, x + 1));

        public static IEnumerable<TestCaseData> AddSeason_TestCases()
        {
            string s = "{m}_";
            var league1 = LeagueFactory.NBA(1);
            var other1 = LeagueFactory.NHL(2);
            yield return new TestCaseData(league1, Season.New(league1, 1, NewRange(1))).SetName(s + "Valid").Returns(true);
            yield return new TestCaseData(league1, Season.New(other1, 2, NewRange(4))).SetName(s + "WrongLeague").Returns(false);
            yield return new TestCaseData(league1, Season.New(league1, 3, NewRange(1))).SetName(s + "OverlapRange").Returns(false);
        }
    }
}
