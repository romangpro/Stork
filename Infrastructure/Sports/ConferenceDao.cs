using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Domain.Sports;

namespace Infrastructure.Sports
{
    [Table("Conference")]
    public class ConferenceDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint ConferenceId { get; set; }
        public LeagueDao League { get; set; }
        [ForeignKey("League")]
        public uint LeagueId { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }

        public ConferenceDao() { }
    }

    public class ConferenceDaoProfile : Profile
    {
        public ConferenceDaoProfile()
        {
            CreateMap<ConferenceDao, Conference>();
        }
    }
}
