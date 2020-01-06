using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Sports
{
    [Table("TeamMap")]
    public class TeamMapDao
    {
        public SeasonDao Season { get; set; } //parent
        [Key]
        public uint SeasonId { get; set; }

        public ConferenceDao Conference { get; set; }
        public uint ConferenceId { get; set; }

        public DivisionDao Division { get; set; }
        public uint DivisionId { get; set; }

        public TeamDao Team { get; set; }
        [Key]
        public uint TeamId { get; set; }

        public TeamMapDao() { }
    }

    //public class TeamMapDaoProfile : Profile
    //{
    //    public TeamMapDaoProfile()
    //    {
    //        CreateMap<TeamMapDao, Team>();
    //    }
    //}
}
