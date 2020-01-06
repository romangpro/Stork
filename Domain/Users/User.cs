using Domain.Media;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Users
{
    public class User : Entity<UserId>, IAggregateRoot
    {
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        //wrap in Lazy???
        public IReadOnlyDictionary<Id, VideoPermission> DownloadPermissions => _downloadPermissions;
        private Dictionary<Id, VideoPermission> _downloadPermissions = new Dictionary<Id, VideoPermission>();

        //public IReadOnlyDictionary<Type, IReadOnlyCollection<VideoPermission>> UploadPermissions
        //   => _uploadPermissions.GroupBy(x => x.Id.GetType()).ToDictionary(x => x.Key, x => (IReadOnlyCollection<VideoPermission>)x.ToList());
        //private List<VideoPermission> _uploadPermissions = new List<VideoPermission>();

        public IReadOnlyCollection<IJob> UploadJobs => _uploadJobs;
        private HashSet<IJob> _uploadJobs = new HashSet<IJob>();

        public IReadOnlyCollection<IJob> DownloadJobs => _downloadJobs;
        private HashSet<IJob> _downloadJobs = new HashSet<IJob>();


        public User(uint id, string userName, string email, string firstName, string lastName)
        {
            Id = new UserId(id);  UserName = userName; Email = email; FirstName = firstName; LastName = lastName;
        }

        public string AddDownloadPermission(VideoPermission permission)
        {
            if (permission == null)
                return $"Cannot add null DownloadPermission";
            _downloadPermissions[permission.Id] = permission; //overwrite existing
            return null;
        }

        public VideoPermission HasDownloadPermission(GameContent gc)
        {
            var ids = new Id[] { gc.Id, gc.Game.Id, gc.Game.SeasonId, gc.Game.LeagueId }.Concat(gc.Game.TeamIds);
            var z = ids.ToList();
            var permissions = ids.Select(x => { _downloadPermissions.TryGetValue(x, out VideoPermission p); return p; });
            var allow = permissions.Select(x => x?.Allow).Aggregate(new VideoAccess(), (a, b) => b is null ? a : a.Or(b));
            var restrict = permissions.Select(x => x?.Restrict).Aggregate(new VideoAccess(), (a, b) => b is null ? a : a.Or(b));
            return new VideoPermission(gc.Id, allow, restrict);
        }

        public string AddUploadPermission(VideoPermission permission)
        {
            return null;
        }
    }


    public class UserId : Id
    {
        public UserId(uint id) : base(id) { }
    }
}
