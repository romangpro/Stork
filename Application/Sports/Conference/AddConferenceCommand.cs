using Domain.Sports;

namespace Application.Sports
{
    public class AddConferenceCommand : NameAbbrCommand
    {
        public LeagueId LeagueId { get; set; }

        public AddConferenceCommand() { }
    }
}
