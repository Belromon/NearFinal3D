using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Pentagon
    {
        List<Point> pentagon = new List<Point>();

        int r, h, xo, yo, zo;

        public Pentagon(int r, int h, int xo, int yo, int zo)
        {
            this.r = r;
            this.h = h;
            this.xo = xo;
            this.yo = yo;
            this.zo = zo;
        }

        public int Count => pentagon.Count;

        public Pentagon() { }

        public Pentagon(List<Point> pentagon)
        {
            for (int i = 0; i < 6; i++)
                this.pentagon[i] = pentagon[i];
        }

        public void Coordinates()
        {
            pentagon.Clear();
            pentagon.Add(new Point(xo, yo+h/2, r+zo));
            pentagon.Add(new Point(-Math.Cos(30 * Math.PI / 180) * r + xo, yo + h / 2, -Math.Cos(60 * Math.PI / 180) * r + zo));
            pentagon.Add(new Point(Math.Cos(30 * Math.PI / 180) * r + xo, yo + h / 2, -Math.Sin(30 * Math.PI / 180) * r + zo));

            pentagon.Add(new Point(xo, yo - h/2, r+zo));
            pentagon.Add(new Point(-Math.Cos(30 * Math.PI / 180) * r + xo, yo - h/2, -Math.Cos(60 * Math.PI / 180) * r + zo));
            pentagon.Add(new Point(Math.Cos(30 * Math.PI / 180) * r + xo, yo -h/2, -Math.Sin(30 * Math.PI / 180) * r + zo));
        }

        public Point this[int i]
        {
            get { return pentagon[i]; }
            set { pentagon[i] = value; }
        }

        public Pentagon DeepCopy()
        {
            Pentagon other = (Pentagon)this.MemberwiseClone();
            other.pentagon = new List<Point>() {this.pentagon[0].DeepCopy(), this.pentagon[1].DeepCopy(),
                this.pentagon[2].DeepCopy(), this.pentagon[3].DeepCopy(), this.pentagon[4].DeepCopy(),
                this.pentagon[5].DeepCopy() };
            return other;
        }
    }
}
