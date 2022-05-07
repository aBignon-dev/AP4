using System;
using System.Collections.Generic;
using System.Text;

namespace AP4test.Util
{
    public class ValidateUtil
    {
        /// <summary>
        /// Valide le format du nombre écrit par l'utilisateur
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Retourne -1 si le nombre est incorrect ou le nombre multiplier par son diminutif </returns>
        public static int PriceFormatValidate(string number)
        {
            List<char> charlist = new List<char>();
            charlist.Add('k');
            charlist.Add('m');
            charlist.Add('B');
            string[] numbersplit = {""};
            foreach (char c in charlist)
            {
                if (numbersplit.Length == 1)
                    numbersplit = number.Split(c);
                if (numbersplit.Length == 2 && numbersplit[1].Equals(""))
                {
                    numbersplit[1] = c.ToString();
                    break;
                }
            }

            int numberparsed;
            if (!int.TryParse(numbersplit[0], out numberparsed))
                return -1;
            if (numbersplit.Length == 1)
                return numberparsed;
            if (numbersplit[1].Equals("k") ||
                numbersplit[1].Equals("m") ||
                numbersplit[1].Equals("B") &&
                numberparsed > 0)
                return PrixUtil.FormatInPut(numberparsed, Char.Parse(numbersplit[1]));
            return -1;
        }
    }
}