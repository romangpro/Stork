//using Domain.Model.Media;
//using Domain.Model.Sports;
//using System.Collections.Generic;

//namespace Domain.Model.Users
//{
//    public interface IPermission<TEntity, TId> 
//        where TEntity: Entity<TId>
//        where TId : Id
//    {

//    }

//    //want to make simple OOO way of evaluating the permission based on the class.
//    public class GameContentPermission : IPermission<Content, ContentId>
//    {
//        public IReadOnlyCollection<LeagueId> LeagueIds { get; } = new HashSet<LeagueId>();
//        public IReadOnlyCollection<ConferenceId> ConferenceIds { get; } = new HashSet<ConferenceId>();
//        public IReadOnlyCollection<DivisionId> DivisionIds { get; } = new HashSet<DivisionId>();
//        public IReadOnlyCollection<SeasonId> SeasonIds { get; } = new HashSet<SeasonId>();
//        public IReadOnlyCollection<TeamId> TeamIds { get; } = new HashSet<TeamId>();
//        public IReadOnlyCollection<GameId> GameIds { get; } = new HashSet<GameId>();

//        public bool HasPermission(Game game)
//        {
//            // from the GameContent //Game, need to get the GameId.. TeamIds, SeasonId etc.
//            //if Game

//            return true;
//        }

//    }
//}
