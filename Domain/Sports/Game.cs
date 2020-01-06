using Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Sports
{
    // we are forcing it to be AggregateRoot so that we can progressively load them.. 
    public class Game : Entity<GameId>, IAggregateRoot
    {
        //parent - aggregate root is only supposed to reference other aggregate root, and not its children 
        //         thus Season should be aggregate root.
        public SeasonId SeasonId { get; protected set; }
        public LeagueId LeagueId { get; protected set; } // not necessary, but helps for the permissions 
        public DateTime DatePlayed { get; protected set; }
        public GameType GameType { get; protected set; }
        public IReadOnlyCollection<TeamId> TeamIds => _teamIds.AsReadOnly();
        private List<TeamId> _teamIds = new List<TeamId>();
        public IReadOnlyCollection<Content> Contents => _contents.AsReadOnly();
        private List<Content> _contents = new List<Content>();

        private Game() { }
        public static Game New(uint sid, uint id, uint lid, DateTime datePlayed, GameType gameType, IList<TeamId> teams)
        {
            return new Game()
            {
                SeasonId = new SeasonId(sid),
                Id = new GameId(id),
                LeagueId = new LeagueId(lid),
                DatePlayed = datePlayed,
                GameType = gameType,
                _teamIds = teams.ToList(),
            };
        }

        //can be game video upload, or arbitrary content associated with this game
        public string AddGameContent(Content content)
        {
            if (content is GameContent gc && gc.Game != this)
            {
                return $"Wrong game on the content";
            }
            _contents.Add(content);

            return null;
        }
    }

    public class GameId : Id
    {
        public GameId(uint id) : base(id) { }
    }
}
