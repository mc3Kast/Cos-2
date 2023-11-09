using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cos_2.Smoothy
{
    public abstract class Smoothy
    {
        public double GetZeroOrElementWithIndex(double[] values, int index)
        {
            return (index >= 0 && index < values.Length) ? values[index] : 0;
        }

    }
}
