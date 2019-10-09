using System;
using System.Collections.Generic;
using System.Text;

namespace TondeuzAgazon
{
    public enum Orientation
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }

    public static class OrientationExtension
    {
        private static int ValueCount = Enum.GetNames(typeof(Orientation)).Length;

        public static Orientation PreviousValue(this Orientation orientation)
        {
            return (Orientation)((((int)orientation - 1) + ValueCount) % ValueCount);
        }

        public static Orientation NextValue(this Orientation orientation)
        {
            return (Orientation)(((int)orientation + 1) % ValueCount);
        }
    }
}
