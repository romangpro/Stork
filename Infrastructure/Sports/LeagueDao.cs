using AutoMapper;
using Domain.Sports;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Sports
{
    [Table("League")]
    public class LeagueDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint LeagueId { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        [NotMapped]
        public byte Sex { get; set; }
        [NotMapped]
        public byte Sport { get; set; }
        [NotMapped]
        public byte LeagueLocation { get; set; }
        public IList<ConferenceDao> Conferences { get; set; }
        public IList<DivisionDao> Divisions { get; set; }
        public IList<TeamDao> Teams { get; set; }
        public IList<SeasonDao> Seasons { get; set; }

        public LeagueDao() { }
    }

    public class LeagueDaoProfile : Profile
    {
        public LeagueDaoProfile()
        {
            CreateMap<LeagueDao, League>();
        }
    }
}
