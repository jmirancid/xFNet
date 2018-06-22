using System;

namespace xFNet.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static T As<T>(this object source)
        {
            return (T)source;
        }

        public static bool Is<T>(this Type type)
        {
            return type == typeof(T);
        }

        public static T To<T>(this object source)
        {
            try
            {
                return (T)Convert.ChangeType(source, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public static void With<T>(this T source, Action<T> action)
        {
            action(source);
        }

    }
}
