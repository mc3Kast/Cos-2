using System.Drawing;

namespace Cos_2.Lib
{
    public abstract class Distribution
    {
        public readonly float a;
        public readonly float f;
        public readonly float fi0;
        public readonly int n;
        public float? d;

        public abstract PointF[] Points { get; set; }

        public Distribution(float a, float f, float fi0, int n)
        {
            this.a = a;
            this.f = f;
            this.fi0 = fi0;
            this.n = n;
        }

        public abstract PointF[] GetPoints(float a, float f, float fi0, int n, float? d = null);
    }
}
