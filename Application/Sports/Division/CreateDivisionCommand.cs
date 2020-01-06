using Domain.Sports;

namespace Application.Sports
{
    public class CreateDivisionCommand : NameAbbrCommand
    {
        public LeagueId LeagueId { get; set; }

        public CreateDivisionCommand() { }
    }
}
