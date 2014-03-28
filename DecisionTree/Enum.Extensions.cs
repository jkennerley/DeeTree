using System;
using System.Linq;

namespace DeeTree
{
    public static class Enum<T>
    {
        public static string EnumsStringSummary()
        {
            // Return
            return Enum.GetValues(typeof(T))
                .Cast<int>()
                .Aggregate(string.Empty,
                    (current, val) => current + String.Format("{1}-{0}, ", val, Enum.GetName(typeof(T), val)));
        }

        //public static T Parse(string value)
        //{
        //    return Enum<T>.Parse(value, true);
        //}
        //
        //public static T Parse(string value, bool ignoreCase)
        //{
        //    return (T)Enum.Parse(typeof(T), value, ignoreCase);
        //}
        //
        //public static bool TryParse(string value, out T returnedValue)
        //{
        //    return Enum<T>.TryParse(value, true, out returnedValue);
        //}
        //
        //public static bool TryParse(string value, bool ignoreCase, out T returnedValue)
        //{
        //    try
        //    {
        //        returnedValue = (T)Enum.Parse(typeof(T), value, ignoreCase);
        //        return true;
        //    }
        //    catch
        //    {
        //        returnedValue = default(T);
        //        return false;
        //    }
        //}
    }
}