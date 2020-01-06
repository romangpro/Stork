using System;

namespace Domain.Media
{
    [Flags]
    public enum QualityEnum : short
    {
        None = 0,
        Quality0 = 1 << 0,
        Quality1 = 1 << 1,
        Quality2 = 1 << 2,
        Quality3 = 1 << 3,
        Quality4 = 1 << 4,
        All = Quality0 | Quality1 | Quality2 | Quality3 | Quality4,

        //pseudo-bitrate quality labels
        _288p = Quality0,
        _480p = Quality1,
        _540p = Quality2,
        _720p = Quality3,
        _1080p = Quality4,
    }
}
