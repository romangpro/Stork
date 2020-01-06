using Domain.Sports;

namespace Application.Sports
{
    public class AddTeamCommand : NameAbbrCommand
    {
        public LeagueId LeagueId { get; set; }

        public AddTeamCommand() { }
    }
}
