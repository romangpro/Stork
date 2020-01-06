using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Users
{
    public class PermissionService
    {
        private readonly ILogger<PermissionService> _logger;
        private readonly IUserRepository _userRepo;
        private readonly ILeagueRepository _leagueRepo;
        private readonly IGameRepository _gameRepo;

        public PermissionService(ILogger<PermissionService> logger, IUserRepository userRepo, ILeagueRepository leagueRepo, IGameRepository gameRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
            _leagueRepo = leagueRepo;
            _gameRepo = gameRepo;
        }

        //public async Task<VideoAccess> HasVideoDownloadPermission(GameContent gc, IEnumerable<VideoPermission> permissions)
        //{
        //    var lp = permissions.IsIdType<LeagueId>();
        //    var cp = permissions.IsIdType<ConferenceId>();
            
        //    //var gp = permissions.OfType<GameVideoPermission>();
        //    //var g = gp.SingleOrDefault(x => x.Key == gc.Game.Id);

        //    //var tp = permissions.OfType<TeamVideoPermission>();
        //    //var t = tp.Where(x => gc.Game.Teams.Contains(x.Key)).ToList();
        //    //var t1 = t.Single();
        //    ////aggregate for team permissions
        //    ////t.Aggregate(x=>x.Access.)


        //    //var sp = permissions.OfType<SeasonVideoPermission>();
        //    //var s = sp.SingleOrDefault(x => x.Key == gc.Game.SeasonId);

        //    //var lp = permissions.OfType<LeagueVideoPermission>();
        //    //var cp = permissions.OfType<ConferenceVideoPermission>();
        //    //var dp = permissions.OfType<DivisionVideoPermission>();
        //    //can check if any of the permissions is for Division/Conference/League, and only then get them from LeagueRepo

        //    //var x = g.Access.Or(t1.Access).Or(s.Access);
        //    return x;

        //}


        //public PermissionService()
        //{
        //    //how to get division, conference.. need to use the Season CDT
        //    //public bool CanDownload(GameContent content, Season season, Team team1, Team team2)
        //    //{
        //    //    if (content is GameContent gc)
        //    //    {
        //    //        gc.Game.S
        //    //    }
        //    //    return false;
        //    //}
        //}
    }
}
