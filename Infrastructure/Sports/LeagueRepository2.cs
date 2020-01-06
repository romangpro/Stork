using Application.Interfaces;
using Domain.Sports;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Sports
{
    public class LeagueRepository2 : ILeagueRepository, ITestInMemory
    {
        public static List<League> Leagues = Enumerable.Range(0, 4).Select(x => Domain.Sports.LeagueFactory.NBA_WithNChildren(3,3)).ToList();         
        public static uint LeagueId = 0;

        public LeagueRepository2()
        {
            Leagues[0].Seasons[0].AddTeamMap(new[] { (Leagues[0].Teams[0], Leagues[0].Conferences[0], Leagues[0].Divisions[0]) });
        }

        public Task<List<League>> GetAllAsync()
        {
            return Task.FromResult(Leagues);
        }

        public Task<League> GetAsync(LeagueId key)
        {
            return Task.FromResult(Leagues.FirstOrDefault(x => x.Id == key));
        }

        public Task<League> GetByAbbrAsync(string abbr)
        {
            return Task.FromResult(Leagues.FirstOrDefault(x => x.Abbr == abbr));
        }

        public Task<League> GetByNameAsync(string name)
        {
            return Task.FromResult(Leagues.FirstOrDefault(x => x.Name == name));
        }

        public Task<League> CreateAsync(League item)
        {
            item.Id = new LeagueId(++LeagueId);
            Leagues.Add(item);
            return Task.FromResult(item);
        }

        public Task<bool> UpdateAsync(League item)
        {
            var index = Leagues.FindIndex(x=>x.Id == item.Id);
            if (index == -1)
                throw new KeyNotFoundException("League item not found");
            Leagues[index] = item;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(LeagueId key)
        {
            var index = Leagues.FindIndex(x => x.Id == key);
            if (index == -1)
                throw new KeyNotFoundException("League item not found");
            Leagues.RemoveAt(index);
            return Task.FromResult(true);
        }
    }
}
