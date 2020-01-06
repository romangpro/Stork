using Domain.Sports;
using System;
using System.Collections.Generic;

namespace Application.Sports
{
    public class CreateGameCommand
    {
        public SeasonId SeasonId { get; set; }
        public LeagueId LeagueId { get; set; }
        public DateTime DatePlayed { get; set; }
        public GameType GameType { get; set; }
        public IEnumerable<TeamId> TeamIds { get; set; }
    }
}
