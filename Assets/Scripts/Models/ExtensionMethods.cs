using System.Collections.Generic;

namespace Models
{
    public static class ExtensionMethods
    {
        public static T Front<T>(this IList<T> collection)
        {
            return collection[0];
        }

        public static T Back<T>(this IList<T> collection)
        {
            return collection[^1];
        }

        public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            return collection == null || collection.Count < 1;
        }
    }
}
