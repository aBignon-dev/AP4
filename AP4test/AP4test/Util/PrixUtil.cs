using System;
using System.Collections.Generic;
using System.Text;

namespace AP4test.Util
{
    public class PrixUtil
    {
        public static int
            hundred = 100,
            thousand = 1000,
            million = 1000000,
            billion = 1000000000;

        public static int FormatInPut(int numberparsed, char diminutif)
        {
            if (diminutif.Equals('k'))
                return numberparsed * thousand;

            if (diminutif.Equals('m'))
                return numberparsed * million;

            if (diminutif.Equals('B'))
                return numberparsed * billion;

            return -1;
        }

        public static string FormatOuput(float number)
        {
            String format = "";
            if (number >= billion)
            {
                number /= billion;
                format = "B";
            }
            else if (number >= million)
            {
                number /= million;
                format = "m";
            }
            else if (number >= thousand)
            {
                number /= thousand;
                format = "k";
            }

            number = (long) (number * hundred) / hundred;
            if (number % 1 == 0)
                return (long) number + format;
            return number + format;
        }
    }
}