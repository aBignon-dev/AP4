using System;
using System.Collections.Generic;
using System.Text;
using AP4test.Models;

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

        public static double TimeLeftPercent(Enchere enchereSelected)
        { 
            //
            double percent = (double)(enchereSelected.DateFin.Ticks -DateTime.Now.Ticks) / (enchereSelected.DateFin.Ticks-enchereSelected.DateDebut.Ticks);
           if (percent < 1)
               return percent;
           return 1;
        }
    }
}
