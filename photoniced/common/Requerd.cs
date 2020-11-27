using System;
using System.Collections.Generic;
using System.Text;

namespace photoniced.common
{
    public static class Requerd
    {
        public static T NotNull<T>(T value, string name) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(name);

            return value;
        }
    }
}
