using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cos_2.Lib
{
    public static class Noising
    {
        public static void Noise(PointF[] points)
        {
            for (int n = 0; n < points.Length; n++)
            {
                points[n].Y = (float)Math.Round(0.1 * Math.Sin(2 * Math.PI * n / points.Length), 3);
            }

        }
    }
}
