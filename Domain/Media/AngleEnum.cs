using System;

namespace Domain.Media
{
    [Flags]
    public enum AngleEnum : short
    {
        None = 0,
        Angle0 = 1 << 0,
        Angle1 = 1 << 1,
        Angle2 = 1 << 2,
        Angle3 = 1 << 3,
        Angle4 = 1 << 4,
        Angle5 = 1 << 5,
        Angle6 = 1 << 6,
        Angle7 = 1 << 7,
        All = Angle0 | Angle1 | Angle2 | Angle3 | Angle4 | Angle5 | Angle6 | Angle7,

        //baseball
        Homebase = Angle0,

        //basketball
        Side = Angle0
    }
}
