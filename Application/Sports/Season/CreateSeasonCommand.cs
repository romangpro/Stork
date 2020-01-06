using Domain;
using Domain.Sports;
using System;

namespace Application.Sports
{
    public class CreateSeasonCommand
    {
        public LeagueId LeagueId { get; set; }
        public Range<DateTime> Range { get; set; }
    }
}
