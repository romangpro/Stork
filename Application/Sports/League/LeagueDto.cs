using AutoMapper;
using Domain.Sports;
using System.Collections.Generic;
using System.Text;

namespace Application.Sports
{
    public class LeagueDto
    {
        public string Name { get; set; }
        public string Abbr { get; set; }

        public IList<ConferenceDto> Conferences { get; set; }
        public IList<DivisionDto> Divisions { get; set; }
        public IList<TeamDto> Teams { get; set; }
        public IList<SeasonDto> Seasons { get; set; }
    }

    public class LeagueDtoProfile : Profile
    {
        public LeagueDtoProfile()
        {
            CreateMap<League, LeagueDto>();

            //TODO: lots of lots of stuff
        }
    }
}
