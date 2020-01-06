using System;

namespace Domain.Media
{
    [Flags]
    public enum MediaTypeEnum : short
    {
        LiveCapture = 1 << 0,
        TV          = 1 << 1,
        Logged      = 1 << 2,
    }
}
