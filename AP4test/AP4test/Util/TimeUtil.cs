using System;
using System.Collections.Generic;
using System.Text;

namespace AP4test.Util
{
    public class TimeUtil
    {
        public double DayInSec = 86400;

        public double HourInSec = 3600;

        public double MinInSec = 60;

        private static int MillisecondInSecond(double milli)
        {

            return (int)(milli / 1000);

        }

        public static string TimeInMilliFormat(double milli)
        {
            int second = MillisecondInSecond(milli);

            return "1s";

        }
    }
}
