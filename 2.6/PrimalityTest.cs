using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    internal abstract class PrimalityTest : IPrimalityTest
    {
        public abstract IPrimalityTest.PrimarityTestResult Check(double value, double minimalPrimalityPropability);

        public int counter = 0;

        protected virtual void Cycle()
        {
            //...
            counter++;

        }

    }
}
