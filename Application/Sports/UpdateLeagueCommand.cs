using Domain.Sports;

namespace Application.Sports
{
    public class UpdateLeagueCommand : NameAbbrCommand
    {
        public Sex Sex { get; set; }
        public Sport Sport { get; set; }
        public LeagueLocation LeagueLocation { get; set; }
    }
}
