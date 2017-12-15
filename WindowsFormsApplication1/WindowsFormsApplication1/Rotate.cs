using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Rotate
    {
        int xo, yo, zo;
        Matrix matrix = new Matrix();

        public Rotate(int xo, int yo, int zo)
        {
            this.xo = xo;
            this.yo = yo;
            this.zo = zo;
        }

        public void RotateX(double an, Pentagon pentagon, Cylinder cylinder, int N)
        {
            double[,] T;
            T = new double[4, 4] { { 1, 0, 0, 0 }, { 0, Math.Cos(an), Math.Sin(an), 0 }, { 0, -Math.Sin(an), Math.Cos(an), 0 }, { 0, 0, 0, 1 } };
            double[,] result = new double[1, 4] { { 0, 0, 0, 0 } };

            for (int i = 0; i < 6; i++)
            {
                double[,] s = new double[1, 4] { { pentagon[i].X - xo, pentagon[i].Y - zo, pentagon[i].Z - yo, 1 } };
                result = matrix.multiplyMatrixs(s, T);
                pentagon[i].X = result[0, 0] + xo;
                pentagon[i].Y = result[0, 1] + yo;
                pentagon[i].Z = result[0, 2] + zo;
            }
            result = new double[1, 4] { { 0, 0, 0, 0 } };
            for (int i = 0; i < 2 * N; i++)
            {
                double[,] s = new double[1, 4] { { cylinder[i].X - xo, cylinder[i].Y - zo, cylinder[i].Z - yo, 1 } };
                result = matrix.multiplyMatrixs(s, T);
                cylinder[i].X = result[0, 0] + xo;
                cylinder[i].Y = result[0, 1] + yo;
                cylinder[i].Z = result[0, 2] + zo;
            }
        }

        public void RotateY(double an, Pentagon pentagon, Cylinder cylinder, int N)
        {
            double[,] T;
            T = new double[4, 4] { { Math.Cos(an), 0, -Math.Sin(an), 0 }, { 0, 1, 0, 0 }, { Math.Sin(an), 0, Math.Cos(an), 0 }, { 0, 0, 0, 1 } };
            double[,] result = new double[1, 4] { { 0, 0, 0, 0 } };

            for (int i = 0; i < 6; i++)
            {
                double[,] s = new double[1, 4] { { pentagon[i].X - xo, pentagon[i].Y - zo, pentagon[i].Z - yo, 1 } };
                result = matrix.multiplyMatrixs(s, T);
                pentagon[i].X = result[0, 0] + xo;
                pentagon[i].Y = result[0, 1] + yo;
                pentagon[i].Z = result[0, 2] + zo;
            }
            result = new double[1, 4] { { 0, 0, 0, 0 } };
            for (int i = 0; i < 2 * N; i++)
            {
                double[,] s = new double[1, 4] { { cylinder[i].X - xo, cylinder[i].Y - zo, cylinder[i].Z - yo, 1 } };
                result = matrix.multiplyMatrixs(s, T);
                cylinder[i].X = result[0, 0] + xo;
                cylinder[i].Y = result[0, 1] + yo;
                cylinder[i].Z = result[0, 2] + zo;
            }
        }

        public void RotateZ(double an, Pentagon pentagon, Cylinder cylinder, int N)
        {
            double[,] T;
            T = new double[4, 4] { { Math.Cos(an), Math.Sin(an), 0, 0 }, { -Math.Sin(an), Math.Cos(an), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            double[,] result = new double[1, 4] { { 0, 0, 0, 0 } };

            for (int i = 0; i < 6; i++)
            {
                double[,] s = new double[1, 4] { { pentagon[i].X - xo, pentagon[i].Y - zo, pentagon[i].Z - yo, 1 } };
                result = matrix.multiplyMatrixs(s, T);
                pentagon[i].X = result[0, 0] + xo;
                pentagon[i].Y = result[0, 1] + yo;
                pentagon[i].Z = result[0, 2] + zo;
            }
            result = new double[1, 4] { { 0, 0, 0, 0 } };
            for (int i = 0; i < 2 * N; i++)
            {
                double[,] s = new double[1, 4] { { cylinder[i].X - xo, cylinder[i].Y - zo, cylinder[i].Z - yo, 1 } };
                result = matrix.multiplyMatrixs(s, T);
                cylinder[i].X = result[0, 0] + xo;
                cylinder[i].Y = result[0, 1] + yo;
                cylinder[i].Z = result[0, 2] + zo;
            }
        }

        

        public void Front(Pentagon pentagon, Cylinder cylinder, int N)
        {
            RotateX(0, pentagon, cylinder, N);
            RotateY(0, pentagon, cylinder, N);
            RotateZ(0, pentagon, cylinder, N);
        }

        public void Prof(Pentagon pentagon, Cylinder cylinder, int N)
        {
            double an = -90 * Math.PI / 180;
            RotateY(an, pentagon, cylinder, N);
        }

        public void Goriz(Pentagon pentagon, Cylinder cylinder, int N)
        {
            double an = 90 * Math.PI / 180;
            RotateX(an, pentagon, cylinder, N);
        }
    }
}
