using AutoMapper;
using Domain;
using Domain.Sports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Sports
{
    [Table("Season")]
    public class SeasonDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint SeasonId { get; set; }
        public LeagueDao League { get; set; }
        [ForeignKey("League")]
        public uint LeagueId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public IList<TeamMapDao> TeamMaps { get; set; }

        public SeasonDao() { }

        internal static SeasonDao Create(Range<DateTime> range)
        {
            return new SeasonDao()
            {
                From = range.From,
                To = range.To,
            };
        }
    }

    public class SeasonDaoProfile : Profile
    {
        public SeasonDaoProfile()
        {
            CreateMap<SeasonDao, Season>();
        }
    }
}
