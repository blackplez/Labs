using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
 
namespace Ex6
{
    internal class DeterminedPrimalityTest:PrimalityTest
    {
        public override IPrimalityTest.PrimarityTestResult Check(double value, double minimalPrimalityPropability)
        {
            if (value <= 0) new ArgumentException("Value cant be lower or equal to 0", nameof(value));
            if (value == 1) return IPrimalityTest.PrimarityTestResult.NotPrimeNotComposite;
            if (value == 2) return IPrimalityTest.PrimarityTestResult.Prime;

            for(int i = 3; i<=Math.Sqrt(value); i+=2)
            {
                if (value % i == 0)
                    return IPrimalityTest.PrimarityTestResult.Composite;
            }


            return IPrimalityTest.PrimarityTestResult.NotPrimeNotComposite;
        }
        override protected void Cycle()
        {
            counter++;

        }
    }
}
