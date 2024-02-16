using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    internal class FermatPrimalityTest : PrimalityTest
    {
        public override IPrimalityTest.PrimarityTestResult Check(double value, double minimalPrimalityPropability)
        {
            return IPrimalityTest.PrimarityTestResult.NotPrimeNotComposite;
        }
        override protected void Cycle()
        {
            //...
            counter++;

        }
    }
}
