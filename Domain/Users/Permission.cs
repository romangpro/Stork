using Domain.Media;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Users
{
    /// <summary>
    /// Permission, has a Target
    /// </summary>
    //public abstract class Permission : ValueObject //<TKey, TTarget>
    //                                               //where TKey : Id
    //                                               // where TTarget : Id
    //{
    //    public Id Key { get; } //ie LeagueId, ConferenceId, DivisionId, TeamId, GameId
    //    //public Id Target { get; } //ie ContentId

    //    public bool HasPermission(Id k, Id t)
    //    {
    //        return true;// if k == Key && t
    //    }

    //    public override IEnumerable<object> Properties => throw new System.NotImplementedException();
    //}

    public interface IPermission
    {

    }

    //still some code smell - TOO COMPLICATED
    public class VideoPermission : ValueObject, IPermission
        //where TId : LeagueId, ConferenceId, DivisionId, TeamId, GameId
    {
        public Id Id { get; }
        public VideoAccess Allow { get; }
        public VideoAccess Restrict { get; }
        public VideoPermission(Id id, VideoAccess allow, VideoAccess restrict)
        {
            Id = id; Allow = allow; Restrict = restrict;
        }
        public override IEnumerable<object> Properties => Enumerable.Empty<object>().Append(Id).Append(Allow).Append(Restrict);
    }

    public interface ICombine<T> where T : ICombine<T>
    {
        T And(T other);
        T Or(T other);
    }

    //TODO: fix .. its too hacky
    public class VideoAccess : ValueObject, ICombine<VideoAccess>
    {
        public QualityEnum Quality { get; }
        public AngleEnum Angle { get; }
        public Range<uint> BitRate { get; }

        public VideoAccess() { }
        public VideoAccess(QualityEnum quality, AngleEnum angle, Range<uint> bitRate)
        {
            Quality = quality; Angle = angle; BitRate = bitRate;
        }

        public VideoAccess And(VideoAccess other)
        {
            return new VideoAccess(other.Quality & Quality, other.Angle & Angle, BitRate.Intersect(other.BitRate));
        }

        public VideoAccess Or(VideoAccess other)
        {
            var qq = other.Quality | Quality;
            return new VideoAccess(other.Quality | Quality, other.Angle | Angle, BitRate.Intersect(other.BitRate));
        }

        public override IEnumerable<object> Properties => Enumerable.Empty<object>().Append(Quality).Append(Angle);
    }

    //public class GameVideoPermission : Permission<GameId, VideoAccess>
    //{
    //    public GameId Key { get; }
    //    public VideoAccess Access { get; }

    //    public GameVideoPermission(GameId key, VideoAccess access)
    //    {
    //        Key = key;
    //        Access = access;
    //    }
    //}

    //public class TeamVideoPermission : IPermission<TeamId, VideoAccess>
    //{
    //    public TeamId Key { get; }
    //    public VideoAccess Access { get; }

    //    public TeamVideoPermission(TeamId key, VideoAccess access)
    //    {
    //        Key = key;
    //        Access = access;
    //    }
    //}

    //public class SeasonVideoPermission : IPermission<SeasonId, VideoAccess>
    //{
    //    public SeasonId Key { get; }
    //    public VideoAccess Access { get; }

    //    public SeasonVideoPermission(SeasonId key, VideoAccess access)
    //    {
    //        Key = key;
    //        Access = access;
    //    }
    //}

    //public class DivisionVideoPermission : IPermission<DivisionId, VideoAccess>
    //{
    //    public DivisionId Key { get; }
    //    public VideoAccess Access { get; }
    //}

    //public class ConferenceVideoPermission : IPermission<ConferenceId, VideoAccess>
    //{
    //    public ConferenceId Key { get; }
    //    public VideoAccess Access { get; }
    //}

    //public class LeagueVideoPermission : IPermission<LeagueId, VideoAccess>
    //{
    //    public LeagueId Key { get; }
    //    public VideoAccess Access { get; }
    //}
}
