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
        /// <summary>
        /// Transforme un nombre avec son diminutif en nombre exemple : 500 et k = 500000
        /// </summary>
        /// <param name="numberparsed">Le nombre sans son diminutif</param>
        /// <param name="diminutif">le diminutif (B m ou k)</param>
        /// <returns>Le nombre convertis</returns>
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
        /// <summary>
        /// Formate in nombre en utilisant un diminutif correspondant a la taille du nombre
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string FormatOutput(float number)
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