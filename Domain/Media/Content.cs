using System.Collections.Generic;

namespace Domain.Media
{
    // Game has content. the game was recorded, different type if it was StreamedContent
    // But, Team also has practice videos of players. Attach Content to the User who uploaded? Tag to the Team??
    public class Content : Entity<ContentId>
    {
        public IJob UploadJob { get; protected set; }
        public IReadOnlyList<string> Files => _files.AsReadOnly();
        private List<string> _files = new List<string>();

        public Content() { }
    }

    public class ContentId : Id
    {
        public ContentId(uint id) : base(id) { }
    }
}
