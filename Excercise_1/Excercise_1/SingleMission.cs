using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    class SingleMission : IMission
    {
        public event EventHandler<double> OnCalculate;
        private Calculation calc;

        public SingleMission(Func<double, double> func, string name)
        {
            Name = name;
            Type = "Single";
            calc = new Calculation(func);
        }
        public String Name { get; }
        public String Type { get; }
        public double Calculate(double value)
        {
            value = calc(value);
            OnCalculate?.Invoke(this, value);
            return value;
        }
    }
}
