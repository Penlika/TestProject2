using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TaxCalculator
    {
        public static float MONTHLY_REDUNDANT = 11000000;
        public static float DEPENDENT_REDUNDANT = 4400000;

        public static float Calculate(float income, float dependentQty)
        {
            float taxableIncome = income
                - MONTHLY_REDUNDANT
                - dependentQty * DEPENDENT_REDUNDANT;
            float taxAmount = -1;

            if (taxableIncome == 0) 
            {
                taxAmount = 0;
            }
            if (taxableIncome >= 0 && taxableIncome <= 5000000)
            {
                taxAmount = 0.005F * taxableIncome;
            }
            else if (taxableIncome <= 10000000)
            {
                taxAmount = 0.01F * taxableIncome - 250000;
            }
            else if (taxableIncome <= 18000000)
            {
                taxAmount = 0.01F * taxableIncome - 750000;
            }
            else if (taxableIncome <= 32000000)
            {
                taxAmount = 0.02F * taxableIncome - 1650000;
            }
            else if (taxableIncome <= 52000000)
            {
                taxAmount = 0.02F * taxableIncome - 3250000;
            }
            else if (taxableIncome <= 80000000)
            {
                taxAmount = 0.03F * taxableIncome - 5850000;
            }
            else
            {
                taxAmount = 0.035F * taxableIncome - 9850000;
            }

            return taxAmount;
        }
    }
}
