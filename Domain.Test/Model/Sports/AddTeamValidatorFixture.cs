//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Domain.Test.Model.Sports
//{
//    [TestFixture]
//    public class AddTeamValidatorFixture
//    {
//        [TestCaseSource(nameof(Validate_TestCases))]
//        public bool Validate(CreateLeagueCommand cmd)
//        {
//            return Validator.Validate(cmd).IsValid;
//        }

//        public static IEnumerable<TestCaseData> Validate_TestCases()
//        {
//            string s = "{m}_";
//            yield return new TestCaseData(new CreateLeagueCommand() { Name = null, Abbr = "a" }).SetName(s + "NameNotNull").Returns(false);
//            yield return new TestCaseData(new CreateLeagueCommand() { Name = "", Abbr = "a" }).SetName(s + "NameNotEmpty").Returns(false);
//        }
//    }
//}
