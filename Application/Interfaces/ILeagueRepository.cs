using Domain.Sports;

namespace Application.Interfaces
{
    public interface ILeagueRepository : INameAbbrRepository<League, LeagueId>
    {
        //Task<Team> CreateTeam(AddTeamCommand cmd);
    }
}
