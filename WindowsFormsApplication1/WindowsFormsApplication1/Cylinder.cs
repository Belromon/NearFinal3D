using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Cylinder
    {
        List<Point> cylinder = new List<Point>();
        int r, h, N, xo, yo, zo;

        public Cylinder(int r, int h, int N, int xo, int yo, int zo)
        {
            this.r = r;
            this.h = h;
            this.N = N;
            this.xo = xo;
            this.yo = yo;
            this.zo = zo;
        }

        public int Appr => N;

        public void Coordinates()
        {
            cylinder.Clear();
            double corner = 90 * Math.PI / 180;
            for (int i = 0; i < N; i++)
            {
                cylinder.Add(new Point(r * Math.Cos(corner) + xo, yo+h/2, r * Math.Sin(corner) + zo));
                corner += 2 * Math.PI / N;
            }
            corner = 90 * Math.PI / 180;
            for (int i = N; i < 2 * N; i++)
            {
                cylinder.Add(new Point(r * Math.Cos(corner) + xo, yo - h/2, r * Math.Sin(corner) + zo));
                corner += 2 * Math.PI / N;
            }
        }

        public Point this[int i]
        {
            set { cylinder[i] = value; }
            get { return cylinder[i]; }
        }

        public Cylinder DeepCopy()
        {
            Cylinder other = (Cylinder)this.MemberwiseClone();
            List<Point> cyl = new List<Point>();
            for (int i = 0; i < 2 * N; i++)
                cyl.Add(this.cylinder[i].DeepCopy());
            other.cylinder = new List<Point>(cyl);
            return other;
        }
    }
}
