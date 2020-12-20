using System;

namespace SCC.FantasyFootball.Common.Extensions
{
    public static class StringExtensions
    {
        public static string MappedFromEnum<T>(this string val) where T : struct, Enum
        {
            if (Enum.TryParse<T>(val, out T res))
                return res.ToString();
            return val;
        }

    }
}
