////using Domain.Model;
////using Domain.Model.Sports;
////using Domain.Test.Model;
////using NUnit.Framework;
////using System.Linq;

////namespace Tests
////{
////    public class ModelSportsTests
////    {
////        [SetUp]
////        public void Setup()
////        {
////        }

////        [Test]
////        public void CreateModel()
////        {
////            //League l = new League(new LeagueId(), Sport.Basketball, Sex.Men, "NBA");
////            //l.Seasons.Add(new Season());


////            Assert.Pass();
////        }

////        [Test]
////        public void TestLeagueSize()
////        {
////            League[] l = Enumerable.Range(0, 1000).Select(x => LeagueFactory.NBA((uint)x)).ToArray();
////            //48 bytes with LeagueId
////            //40 bytes without LeagueId


////            var name = l[999].Name;
////            string s = "size of the array: " + name;
////            Assert.Pass();
////        }
////    }

////    //name test from users perspective
////    //instead of : IsDeliveryValid_InvalidDate_ReturnsFalse()
////    // Delivery_with_a_past_date_is_invalid()
////}



//[Test]
//public void CreateSampleLeague()
//{
//    var lf = new LeagueFactory();
//    var l = lf.NewLeague(new CreateLeagueCommand()
//    {
//        Name = "LL",
//        Abbr = "L",
//        Sex = Sex.Men,
//        Sport = Sport.Baseball,
//        LeagueLocation = LeagueLocation.Canada
//    });
//    var x = new List<string>();

//    var c1 = new Conference(l, 1, "CC1", "C1");
//    var c2 = new Conference(l, 2, "CC2", "C2");
//    x.Add(l.AddConference(c1));
//    x.Add(l.AddConference(c2));
//    var d1 = new Division(l, 1, "DD1", "D1");
//    var d2 = new Division(l, 2, "DD2", "D2");
//    x.Add(l.AddDivision(d1));
//    x.Add(l.AddDivision(d2));
//    var t1 = new Team(l, 1, "TT1", "T1");
//    var t2 = new Team(l, 2, "TT2", "T2");
//    var t3 = new Team(l, 3, "TT3", "T3");
//    x.Add(l.AddTeam(t1));
//    x.Add(l.AddTeam(t2));
//    x.Add(l.AddTeam(t3));

//    var s1 = new Season(l, 1, "SS1", "S1", new Range<DateTime>(new DateTime(2017, 1, 1), new DateTime(2017, 9, 9)));
//    x.Add(l.AddSeason(s1));
//    x.Add(s1.AddTeamMap(new[] { (t1, c1, d1),
//                                  (t2, c2, d2) }));

//    var s2 = new Season(l, 2, "SS2", "S2", new Range<DateTime>(new DateTime(2018, 1, 1), new DateTime(2018, 9, 9)));
//    x.Add(l.AddSeason(s2));

//    var l4 = new League(4, "LL4", "L4", Sex.Women, Sport.Hockey, LeagueLocation.France);
//    var c4 = new Conference(l4, 4, "CC4", "C4");
//    var d4 = new Division(l4, 4, "DD4", "D4");
//    var t4 = new Team(l4, 4, "TT4", "T4");
//    x.Add(l4.AddConference(c4));
//    x.Add(l4.AddDivision(d4));
//    x.Add(l4.AddTeam(t4));
//    x.Add(s2.AddTeamMap(new[] { (t1, c1, d2),
//                                  (t2, c1, d2),
//                                  (t3, c1, d2),
//                                  (t4, c4, d4),
//                                  (t1, c4, d4)

//            }));
//    Console.WriteLine("done");


//    var g1 = new Game(s1.Id, 1, l.Id, new DateTime(2019, 1, 1), GameType.Training, new[] { t1.Id, t2.Id });
//    var gc1 = new GameContent(g1, 1, TypeEnum.LiveCapture, QualityEnum.Quality0, AngleEnum.Angle0);

//    var u = new User(1, "a", "b", "c", "d");
//    //u.AddDownloadPermission(new VideoPermission(s2.Id, new VideoAccess(QualityEnum.All, AngleEnum.All), null));
//    //u.AddDownloadPermission(new VideoPermission(s1.Id, new VideoAccess(QualityEnum.Quality0, AngleEnum.Angle0), null));
//    //u.AddDownloadPermission(new VideoPermission(t1.Id, new VideoAccess(QualityEnum.Quality1, AngleEnum.Angle1), null));
//    //u.AddDownloadPermission(new VideoPermission(t2.Id, new VideoAccess(QualityEnum.Quality2, AngleEnum.Angle2), null));
//    //u.AddDownloadPermission(new VideoPermission(g1.Id, new VideoAccess(QualityEnum.Quality0 | QualityEnum.Quality3, AngleEnum.Angle2), null));
//    //u.AddDownloadPermission(new VideoPermission(gc1.Id, new VideoAccess(QualityEnum.Quality0 | QualityEnum.Quality4, AngleEnum.Angle0), null));

//    var combined = u.HasDownloadPermission(gc1);

//    var q1 = QualityEnum.Quality0 | QualityEnum.Quality3;
//    var q2 = QualityEnum.Quality1 | QualityEnum.Quality4;
//    var q3 = q1 | q2;

//    //var x1 = new VideoAccess(QualityEnum.Quality0 | QualityEnum.Quality3, AngleEnum.Angle2);
//    //var x2 = new VideoAccess(QualityEnum.Quality1 | QualityEnum.Quality4, AngleEnum.None);
//    //var xx3 = x1.Or(x2);
//    //var xx33 = x2.Or(x1);
//    Console.WriteLine("combined permissions");
//    //l.AddSeason(new Season(1, new Range<DateTime>(new DateTime(2018, 1, 1), new DateTime(2018, 2, 2)), new[] { new GameId(1) }));
//}