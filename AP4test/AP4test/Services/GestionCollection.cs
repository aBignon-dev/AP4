using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace AP4test.Services
{
    public static class GestionCollection
    {
        public static ObservableCollection<T> GetLists<T>(List<T> paramList)
        {
            var result = new ObservableCollection<T>();

            foreach (T leParam in paramList)
            {
                result.Add(leParam);
            }

            return result;
        }

        public static T GetObjet<T>(List<T> param, int param2)

        {
            var result = default(T);
            foreach (T unparam in param)
            {
                PropertyInfo x = (unparam.GetType().GetProperty("id"));
                var nbi = Convert.ToInt32(x.GetValue(unparam));
                if (nbi != Convert.ToInt32(param2)) continue;
                result = unparam;
                break;
            }

            return result;
        }
    }
}