using System;
using System.Drawing;

namespace Cos_2.Lib
{
    public class Cos : Distribution
    {
        public Cos(float a, float f, float fi0, int n) : base(a, f, fi0, n)
        {
            Points = GetPoints(a, f, fi0, n);
        }

        public override PointF[] Points { get; set; }

        public override PointF[] GetPoints(float a, float f, float fi0, int N, float? d = null)
        {
            Points = new PointF[N];
            for (int n = 0; n < N; n++)
            {
                Points[n].X = n / (float)N;
                Points[n].Y = (float)Math.Round(a * Math.Cos(2 * Math.PI * f * n / N + fi0), 3);
            }

            return Points;
        }
    }
}
