using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Helpers.WeightCalculator
{
    public class WeightCalculator
    {
        private const double oneProductWeight = 0.3;

        private double containerWeight = 6;

        public WeightCalculator() { }

        //public WeightCalculator(double containerWeight)
        //{
        //    this.containerWeight = containerWeight;
        //}

        public double CalculateWeight(int productCount)
        {
            var productsWeight = productCount * oneProductWeight;

            var totalWeight = productsWeight + containerWeight;

            return Math.Round(totalWeight, 2); // Round to 2 decimal places
        }
    }
}
