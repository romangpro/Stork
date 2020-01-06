using Application.Interfaces;
using AutoMapper;
using Domain.Sports;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Sports
{
    public interface ILeagueService
    {
        Task<ICollection<LeagueDto>> GetAllAsync();
        Task<LeagueDto> GetAsync(uint id);
        Task<LeagueDto> CreateLeague(CreateLeagueCommand cmd);
        Task<bool> UpdateLeague(uint id, UpdateLeagueCommand cmd);
    }

    public class LeagueService : ILeagueService
    {
        private readonly ILogger<LeagueService> _logger;
        private readonly ILeagueRepository _repo;
        private readonly IMapper _mapper;

        public LeagueService(ILogger<LeagueService> logger, ILeagueRepository repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }



        public async Task<ICollection<LeagueDto>> GetAllAsync()
        {
            //test out mapper


            var leagues = await _repo.GetAllAsync();
            // LeagueDao (database) -> League (entity) -> LeagueDto (contract)
            return leagues.Select(x => _mapper.Map<LeagueDto>(x)).ToList();
        }

        public Task<LeagueDto> GetAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        Task<LeagueDto> ILeagueService.CreateLeague(CreateLeagueCommand cmd)
        {
            throw new System.NotImplementedException();
        }

        public async Task<League> CreateLeague(CreateLeagueCommand cmd)
        {
            var allleagues = await _repo.GetAllAsync();
            if (allleagues.UniqueNameAbbr(cmd))
            {
                var created = await _repo.CreateAsync(_mapper.Map<League>(cmd));
                if (created != null)
                {
                    return _mapper.Map<League>(created);
                }
            }
            return null;
        }

        public async Task<bool> UpdateLeague(uint id, UpdateLeagueCommand cmd)
        {
            //TODO: find by id and replace
            //var league = await _repo.CreateAsync(
                return false;
        }

        // is this testable. is there leakage
        // if we put the check LeagueId inside the validator, then it must be async - undesirable
        public async Task<ValidationResult> AddTeam(AddTeamCommand cmd)
        {
            var league = await _repo.GetAsync(cmd.LeagueId);
            if (league == null)
                return new ValidationResult(new[] { new ValidationFailure(nameof(cmd.LeagueId), $"League {cmd.LeagueId} not found") });
            var validator = new AddTeamValidator(league);
            var result = validator.Validate(cmd);
            if (result.IsValid)
            {
                //var team = await _repo.CreateTeam(cmd);
                //the teamId has to be globally unique, and MUST come from the repository
                var team = Team.New(league, 0, cmd.Name, cmd.Abbr);
                league.AddTeam(team);
            }
            return result;
        }



        //public async Task<ValidationResult> AddConference(AddConferenceCommand cmd)
        //{
        //    //var league = _repo.GetAsync(cmd.LeagueId);
        //    //if (league == null)
        //    //    return new ValidationResult() { Isva}

        //    return null;
        //}

        //public async Task<ValidationResult> AddDivision(CreateDivisionCommand cmd)
        //{
        //    return null;
        //}



        //public async Task<ValidationResult> AddSeason(CreateSeasonCommand cmd)
        //{
        //    return null;
        //}
    }
}
