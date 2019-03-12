using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{


    class FunctionsContainer
    {
        private Dictionary<String, Func<double, double>> functions;

        public FunctionsContainer()
        {
            functions = new Dictionary<string, Func<double, double>>();
        }

        public Func<double, double> this[string key]
        {
            get
            {
                if (!functions.ContainsKey(key))   // if it dosent contains the key consider as function does nothing
                {
                    functions[key] = val => val;
                }
                return functions[key];
            }
            set
            {
                functions[key] = value;
            }

        }
        public string[] getAllMissions()
        {
            string[] names = new string[functions.Count];
            int i = 0;
            foreach (var entry in functions)
            {
                names[i++] = entry.Key;
            }
            return names;
        }
    }



    }
