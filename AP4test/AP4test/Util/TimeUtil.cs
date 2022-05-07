using System;
using AP4test.Models;

namespace AP4test.Util
{
    public class TimeUtil
    {
        public double DayInSec = 86400;

        public double HourInSec = 3600;

        public double MinInSec = 60;
        
        /// <summary>
        /// Récupère le temps restant en pourcentage pour la barre de progression de la fin de l'enchère
        /// </summary>
        /// <param name="enchereSelected"></param>
        /// <returns>Retourne le pourcentage avant la fin de l'enchère</returns>
        public static double TimeLeftPercent(Enchere enchereSelected)
        {
            //
            double percent = (double) (enchereSelected.DateFin.Ticks - DateTime.Now.Ticks) /
                             (enchereSelected.DateFin.Ticks - enchereSelected.DateDebut.Ticks);
            if (percent < 1)
                return percent;
            return 1;
        }
        /// <summary>
        /// Récupère le nombre de tick restant avant la fin de l'enchère
        /// </summary>
        /// <param name="enchereSelected"></param>
        /// <returns>Retourne nombre de tick restant avant la fin de l'enchère</returns>
        public static TimeSpan TimeLeft(Enchere enchereSelected)
        {
            return enchereSelected.DateFin - DateTime.Now;
        }
    }
}