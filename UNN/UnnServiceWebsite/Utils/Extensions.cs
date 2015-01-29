using System;

namespace Utils
{
    public static class Extensions
    {
        public static string AsString(this TimeSpan time)
        {
            return String.Format("{0}:{1}", time.Hours.ToString("D2"), time.Minutes.ToString("D2"));
        }

        public static TimeSpan AsTimeSpan(this string str)
        {
            string[] ss = str.Split(':');

            return new TimeSpan(int.Parse(ss[0]), int.Parse(ss[1]), 0);
        }
    }
}
