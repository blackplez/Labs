using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    internal interface IPrimalityTest
    {
        enum PrimarityTestResult
        {
            Prime,
            Composite,
            NotPrimeNotComposite
        }

        PrimarityTestResult Check(double value, double minimalPrimalityPropability);
    }
}
