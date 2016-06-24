using System;
using System.Globalization;

namespace Nightscout.Utilities
{
    /// <summary>
    /// Extension methods to convert dates and times to various representations
    /// </summary>
    public static class DateParserExtensions
    {
        private static readonly string[] DateFormats = new[] { "yyyy-M-dd", "yyyy-MM-dd", "yyyy-MM-ddThh:mm", "yyyy-MM-ddThh:mm:ss", "o" };
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Parses the date to js.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static long ToJavaScriptDate(this string value)
        {
            DateTime parseDate;
            if (DateTime.TryParseExact(value, DateFormats, CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out parseDate))
            {
                var utcValue = parseDate.ToUniversalTime();
                return (long)(utcValue - Epoch).TotalMilliseconds;
            }

            throw new FormatException($"Could not convert '{value}' to a known date format");
        }
    }
}