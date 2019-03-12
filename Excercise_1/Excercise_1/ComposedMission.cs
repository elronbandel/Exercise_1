using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    delegate double Calculation(double var);

    class NestedCalculation
    {
        private NestedCalculation next;
        private Calculation calc;
        protected NestedCalculation()
        {
            calc = var => var;
            next = null;
        }
        private NestedCalculation(Func<double, double> newCalc)
        {
            calc = new Calculation(newCalc);
            next = null;
        }
        protected void push(Func<double, double> newCalc)
        {
            if (next == null)
            {
                next = new NestedCalculation(newCalc);
            }
            else
            {
                next.push(newCalc);
            }
        }
        public virtual double Calculate(double var)
        {
            var = calc(var);
            if (next != null)
            {
                var = next.Calculate(var);
            }
            return var;
        }
    }

    class ComposedMission : NestedCalculation, IMission
    {
        public event EventHandler<double> OnCalculate;
        public ComposedMission(string name)
        {
            Name = name;
            Type = "Composed";
        }
        public String Name { get; }
        public String Type { get; }
        public ComposedMission Add(Func<double, double> func) //this method is prcaticly the building method of the NestedCalculation
        {
            push(func);
            return this;
        }
        public override double Calculate(double value)
        {
            value = base.Calculate(value);
            
            OnCalculate?.Invoke(this, value);
            return value;
        }
    }
}
