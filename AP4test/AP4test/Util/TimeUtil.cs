using System;
using AP4test.Models;

namespace AP4test.Util
{
    public class TimeUtil
    {
        public double DayInSec = 86400;

        public double HourInSec = 3600;

        public double MinInSec = 60;

        public static double TimeLeftPercent(Enchere enchereSelected)
        {
            //
            double percent = (double) (enchereSelected.DateFin.Ticks - DateTime.Now.Ticks) /
                             (enchereSelected.DateFin.Ticks - enchereSelected.DateDebut.Ticks);
            if (percent < 1)
                return percent;
            return 1;
        }

        public static TimeSpan TimeLeft(Enchere enchereSelected)
        {
            return enchereSelected.DateFin - DateTime.Now;
        }
    }
}