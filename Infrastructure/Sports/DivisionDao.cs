using AutoMapper;
using Domain.Sports;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Sports
{
    [Table("Division")]
    public class DivisionDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint DivisionId { get; set; }
        public LeagueDao League { get; set; }
        [ForeignKey("League")]
        public uint LeagueId { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }

        public DivisionDao() { }
    }

    public class DivisionDaoProfile : Profile
    {
        public DivisionDaoProfile()
        {
            CreateMap<DivisionDao, Division>();
        }
    }
}
