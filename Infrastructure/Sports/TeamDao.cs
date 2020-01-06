using AutoMapper;
using Domain.Sports;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Sports
{
    [Table("Team")]
    public class TeamDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint TeamId { get; set; }
        public LeagueDao League { get; set; }
        [ForeignKey("League")]
        public uint LeagueId { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }

        public TeamDao() { }
    }

    public class TeamDaoProfile : Profile
    {
        public TeamDaoProfile()
        {
            CreateMap<TeamDao, Team>();
        }
    }
}
