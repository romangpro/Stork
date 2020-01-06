using Domain.Sports;

namespace Domain.Media
{
    /// <summary>
    /// user uploads some unknown file. maybe video
    /// - for game video...
    /// - rather than user selecting angle and/or quality, this needs to be done by ops
    /// 
    /// - for nongame video, we dont care about angle or quality. they can also modify the permission so other user or team can access it
    /// </summary>
    public class GameContent : Content 
        //TODO: remove inheritence
        //this is BAD
    {
        public Game Game { get; protected set; } //parent
        public MediaTypeEnum Content { get; protected set; }
        public QualityEnum Quality { get; protected set; }
        public AngleEnum Angle { get; protected set; }

        public GameContent(Game game, uint id, MediaTypeEnum content, QualityEnum quality, AngleEnum angle)
        {
            Id = new ContentId(id);
            Game = game;
            Content = content;
            Quality = quality;
            Angle = angle;
        }
        //UploadJob
        //Files
    }
}
