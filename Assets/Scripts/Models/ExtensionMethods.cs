using System.Collections.Generic;

namespace Models
{
    public static class ExtensionMethods
    {
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            return collection.Count < 1;
        }
    }
}
