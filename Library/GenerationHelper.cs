using System;
using System.Globalization;

namespace Library
{
    public class GenerationHelper
    {
        public static string GetMessageDetailOfException(Exception ex)
        {
            Exception tmpException = ex;

            while (tmpException.InnerException != null)
            {
                tmpException = tmpException.InnerException;
            }

            return tmpException.Message;
        }

        public static string ToStringByFormatter(DateTime? dateTime, string formatter)
        {
            if (dateTime == null)
            {
                return null;
            }
            return dateTime.Value.ToString(formatter);
        }

        public static DateTime? ToDateByFormatterAndCulture(string dateTime, string formatter)
        {
            if (string.IsNullOrEmpty(dateTime))
            {
                return null;
            }

            if (!DateTime.TryParseExact(dateTime, formatter, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return null;
            }

            return result;
        }
    }
}
