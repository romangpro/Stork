using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Sports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Sports
{
    //Repository sole responsibility is persisting domain entity.
    //but internally, uses Dao that map 1:1 to tables - which allows arbitrary db schema
    //Eliding async/await https://blog.stephencleary.com/2016/12/eliding-async-await.html
    public class LeagueRepository : ILeagueRepository
    {
        private readonly SportsDbContext _db;
        private readonly IMapper _mapper;

        public LeagueRepository(SportsDbContext db, IMapper mapper)
        {
            _db = db; _mapper = mapper;
        }

        public Task<List<League>> GetAllAsync()
        {
            //IQuerable .ProjectTo is "old" way
            //_mapper.ProjectTo - translated to SQL and executed server side
            //IEnumerable<>.Select(_mapper.Map) - client evaluation and uses Include/ThenInclude
            return _mapper.ProjectTo<League>(_db.Leagues.AsNoTracking()).ToListAsync();
        }

        public async Task<League> GetAsync(LeagueId key)
        {
            return _mapper.Map<League>(await _db.Leagues.AsNoTracking().SingleOrDefaultAsync(x => x.LeagueId == (uint)key));
        }

        public Task<League> GetByAbbrAsync(string abbr)
        {
            return _db.Leagues.AsNoTracking().ProjectTo<League>(AutoMapperConfig.Config).SingleOrDefaultAsync(x => x.Abbr == abbr);
        }

        public Task<League> GetByNameAsync(string name)
        {
            return _db.Leagues.AsNoTracking().ProjectTo<League>(AutoMapperConfig.Config).SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<League> CreateAsync(League item)
        {
            var dao = _mapper.Map<LeagueDao>(item);
            var changes = await _db.Leagues.AddAsync(dao);
            var created = await _db.SaveChangesAsync();
            return null; // _mapper.Map<League>(changes.Result.Entity);
        }

        public Task<bool> UpdateAsync(League item)
        {




            //var index = Leagues.FindIndex(x => x.Id == item.Id);
            //if (index == -1)
            //    throw new KeyNotFoundException("League item not found");
            //Leagues[index] = item;
            //return Task.FromResult(true);
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(LeagueId key)
        {
            //check if exists
            //remove

            //var index = Leagues.FindIndex(x => x.Id == key);
            //if (index == -1)
            //    throw new KeyNotFoundException("League item not found");
            //Leagues.RemoveAt(index);
            //return Task.FromResult(true);
            throw new NotImplementedException();
        }
    }
}
