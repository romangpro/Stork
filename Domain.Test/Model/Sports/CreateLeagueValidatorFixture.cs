//using Domain.Commands.Sports;
//using NUnit.Framework;
//using System.Collections.Generic;

//namespace Domain.Test.Model.Sports
//{
//    [TestFixture]
//    public class CreateLeagueValidatorFixture
//    {
//        public static CreateLeagueValidator Validator = new CreateLeagueValidator();

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
//            yield return new TestCaseData(new CreateLeagueCommand() { Name = new string('a', NameAbbrValidator.NAME_LENGTH + 1), Abbr = "a" }).SetName(s + "NameOverMaxLength").Returns(false);
//            yield return new TestCaseData(new CreateLeagueCommand() { Name = new string('a', NameAbbrValidator.NAME_LENGTH), Abbr = "a" }).SetName(s + "NameMaxLength").Returns(true);

//            yield return new TestCaseData(new CreateLeagueCommand() { Abbr = null, Name = "a" }).SetName(s + "AbbrNotNull").Returns(false);
//            yield return new TestCaseData(new CreateLeagueCommand() { Abbr = "", Name = "a" }).SetName(s + "AbbrNotEmpty").Returns(false);
//            yield return new TestCaseData(new CreateLeagueCommand() { Abbr = new string('a', NameAbbrValidator.ABBR_LENGTH + 1), Name = "a" }).SetName(s + "AbbrOverMaxLength").Returns(false);
//            yield return new TestCaseData(new CreateLeagueCommand() { Abbr = new string('a', NameAbbrValidator.ABBR_LENGTH), Name = "a" }).SetName(s + "AbbrMaxLength").Returns(true);
//        }
//    }
//}
