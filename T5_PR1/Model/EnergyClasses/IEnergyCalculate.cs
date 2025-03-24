using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T5._PR1.EnergyClasses
{
    interface  IEnergyCalculate
    {
        double CalculateEnergy();
        double CalculateTotalCost();
        double CalculateTotalPrice();
    }
}
