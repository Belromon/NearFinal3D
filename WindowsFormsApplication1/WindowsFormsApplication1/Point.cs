using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Point
    {
        private PointF p;
        //private double x;
        //private double y;
        private double z;

        public Point()
        {

        }

        public double X
        {
            get { return p.X; }
            set { p.X = (float)value; }
        }

        public double Y
        {
            get { return p.Y; }
            set { p.Y = (float)value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }
        public Point(double x, double y, double z)
        {
            p.X = (float)x;
            p.Y = (float)y;
            //this.x = x;
            // this.y = y;
            this.z = z;
        }

        public Point DeepCopy()
        {
            Point other = (Point)this.MemberwiseClone();
            other.X = p.X;
            other.Y = p.Y;
            other.Z = this.z;
            return other;
        }
    }
}
