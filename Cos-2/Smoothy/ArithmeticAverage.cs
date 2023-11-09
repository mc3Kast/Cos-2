using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cos_2.Smoothy
{
    public  class ArithmeticAverage : Smoothy
    {
        private int k;

        public ArithmeticAverage(int k)
        {
            this.k = k;
        }

        public double[] Execute(double[] values)
        {
            double[] smoothedValues = new double[values.Length];
            int offset = (k - 1) / 2;

            Parallel.ForEach(values, (value, state, index) =>
            {
                double sum = 0;

                for (int j = (int)index - offset; j <= (int)index + offset; j++)
                {
                    sum += GetZeroOrElementWithIndex(values, j);
                }

                smoothedValues[index] = sum / k;
            });

            return smoothedValues;
        }
    }
}
