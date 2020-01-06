using AutoMapper;
using Domain.Sports;

namespace Application.Sports
{
    public class CreateLeagueCommand : NameAbbrCommand
    {
        public Sex Sex { get; set; }
        public Sport Sport { get; set; }
        public LeagueLocation LeagueLocation { get; set; }

        public CreateLeagueCommand() { }
    }

    public class CreateLeagueProfile : Profile
    {
        public CreateLeagueProfile()
        {
            CreateMap<CreateLeagueCommand, League>();
        }
    }
}