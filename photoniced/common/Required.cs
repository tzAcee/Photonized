using System;

namespace photoniced.common
{
    public static class Required
    {
        public static T NotNull<T>(T value, string name) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(name);

            return value;
        }

        public static string NotNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(name);
            return value;
        }
        
    }
}
