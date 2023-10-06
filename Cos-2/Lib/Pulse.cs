using System;
using System.Drawing;

namespace Cos_2.Lib
{
    public class Pulse : Distribution
    {
        public DistributionType Type = DistributionType.Pulse;
        public Pulse(float a, float f, float fi0, int n, float? d = 0.5f) : base(a, f, fi0, n)
        {
            this.d = d;
            Points = GetPoints(a, f, fi0, n, d);
        }

        public override PointF[] Points { get; set; }

        public override PointF[] GetPoints(float a, float f, float fi0, int N, float? d = 0.5f)
        {
            Points = new PointF[N];
            for (int n = 0; n < N; n++)
            {
                Points[n].X = n / (float)N;
                Points[n].Y = (2 * Math.PI * f * n / N + fi0) % (2 * Math.PI) / (2 * Math.PI) <= d ? a : -a;
            }

            return Points;
        }
    }
}
