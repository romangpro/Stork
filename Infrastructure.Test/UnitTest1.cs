using Infrastructure.Sports;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Test
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Entity_InMemory_BreakForeignKey()
        {
            var options = new DbContextOptionsBuilder<SportsDbContext>()
             .UseInMemoryDatabase(databaseName: "test1")
             .Options;

            using (var context = new SportsDbContext(options))
            {
                context.Leagues.Add(LeagueFactory.NewLeague(1));
                context.Leagues.Add(LeagueFactory.NewLeague(2));
                context.SaveChanges();
            }

            using (var context = new SportsDbContext(options))
            {
                var result = await context.Leagues
                    .Include(x => x.Conferences)
                    .Include(x => x.Divisions)
                    .Include(x => x.Teams)
                    .Include(x => x.Seasons).ThenInclude(x=>x.TeamMaps).ToListAsync();
                //should be able to get the team maps with the navigation properties
                Console.WriteLine(result[0].Seasons[0].TeamMaps[0]);
            }
        }

        //TODO: need to check we can change the children on aggregate
        [Test]
        public async Task Entity_SqlLite_ForeignKey()
        {
            var options = new DbContextOptionsBuilder<SportsDbContext>()
             .UseInMemoryDatabase(databaseName: "test2")
             .Options;

            using (var context = new SportsDbContext(options))
            {
                context.Leagues.Add(LeagueFactory.NewLeague(1));
                context.SaveChanges();
            }

            //change the team
            using (var context = new SportsDbContext(options))
            {
                var league = await context.Leagues.Include(x => x.Teams).FirstAsync();
                context.Update(league);
                league.Teams.First().Name = "abc";
                league.Teams.Add(new TeamDao() { Name="zz" });
                context.SaveChanges();
                var league2 = await context.Leagues.Include(x => x.Teams).FirstAsync();
                //league.Teams.Firs
                //var result = await context.Leagues
                //    .Include(x => x.Conferences)
                //    .Include(x => x.Divisions)
                //    .Include(x => x.Teams)
                //    .Include(x => x.Seasons).ThenInclude(x => x.TeamMaps).ToListAsync();
                //should be able to get the team maps with the navigation properties
                Console.WriteLine("done");
            }
        }
    }
}