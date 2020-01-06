using AutoMapper;
using Domain.Sports;
using Infrastructure.Sports;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using LeagueFactory = Infrastructure.Sports.LeagueFactory;

namespace Infrastructure.Test
{
    [TestFixture]
    public class Sqlite
    {
        private readonly IMapper _mapper;

        [SetUp]
        public void Setup()
        {
        }

        public Sqlite()
        {
            var config = new MapperConfiguration(o =>
            {
                o.AddMaps(typeof(LeagueDao));
            });
            _mapper = config.CreateMapper();
        }

        [Test]
        public async Task Simple()
        {
            var options = new DbContextOptionsBuilder<SportsDbContext>()
           //.UseInMemoryDatabase(databaseName: "test1")
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
                    .Include(x => x.Seasons).ThenInclude(x => x.TeamMaps).ToListAsync();
                
                var leagueDao = result[0];
                var league = _mapper.Map<League>(leagueDao);


                //should be able to get the team maps with the navigation properties
                Console.WriteLine(result[0].Seasons[0].TeamMaps[0]);
            }

        }
    }
}
