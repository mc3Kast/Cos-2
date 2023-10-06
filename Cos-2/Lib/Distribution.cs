using System.Drawing;

namespace Cos_2.Lib
{
    public abstract class Distribution
    {
        protected readonly float a;
        protected readonly float f;
        protected readonly float fi0;
        protected readonly int n;
        protected float? d;

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
