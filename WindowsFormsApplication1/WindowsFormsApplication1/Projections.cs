using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Projections
    {
        int xo, yo, zo;
        Matrix matrix = new Matrix();

        public Projections(int xo, int yo, int zo)
        {
            this.xo = xo;
            this.yo = yo;
            this.zo = zo;
        }

        public void AksProjection(double psi, double fi, Pentagon pentagon, Cylinder cylinder, int N)
        {            
            double[,] T;

            T = new double[4, 4] { 
                { Math.Cos(psi), Math.Sin(fi) * Math.Sin(psi), 0, 0 }, 
                { 0, Math.Cos(fi), 0, 0 }, 
                { Math.Sin(psi), -Math.Sin(fi) * Math.Cos(psi), 0, 0 }, 
                { 0, 0, 0, 1 } };
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

        public void CosProjection(double alpha, double l, Pentagon pentagon, Cylinder cylinder, int N)
        {
            double[,] T;

            T = new double[4, 4] { 
                { 1,0,0,0 }, 
                { 0, 1, 0, 0 }, 
                { l*Math.Cos(alpha), l*Math.Sin(alpha), 0, 0 }, 
                { 0, 0, 0, 1 } };
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

        public void PersProjection(double d, double ro, double tetta, double fi, Pentagon pentagon, Cylinder cylinder, int N)
        {
            double[,] T;

            T = new double[4, 4] { 
                {-Math.Sin(tetta), -Math.Cos(fi)*Math.Cos(tetta), -Math.Sin(fi)*Math.Cos(tetta),0 }, 
                { Math.Cos(tetta), -Math.Cos(fi) * Math.Sin(tetta), -Math.Sin(fi) * Math.Cos(tetta), 0 }, 
                { 0, Math.Sin(fi), -Math.Cos(fi), 0 }, 
                { 0, 0, ro, 1 } };
            double[,] result = new double[1, 4] { { 0, 0, 0, 0 } };

            for (int i = 0; i < 6; i++)
            {
                double[,] s = new double[1, 4] { { pentagon[i].X - xo, pentagon[i].Y - zo, pentagon[i].Z - yo, 1 } };
                result = matrix.multiplyMatrixs(s, T);
                if (result[0, 2] == 0)
                {
                    result[0, 2] = 0.1;
                }
                pentagon[i].X = result[0, 0] * d / result[0, 2] + xo;
                pentagon[i].Y = result[0, 1] * d / result[0, 2] + yo;
                pentagon[i].Z = result[0, 2] * d / result[0, 2] + zo;
            }

            result = new double[1, 4] { { 0, 0, 0, 0 } };
            for (int i = 0; i < 2 * N; i++)
            {
                double[,] s = new double[1, 4] { { cylinder[i].X - xo, cylinder[i].Y - zo, cylinder[i].Z - yo, 1 } };
                result = matrix.multiplyMatrixs(s, T);
                if (result[0, 2] == 0)
                {
                    result[0, 2] = 0.1;
                }
                cylinder[i].X = result[0, 0] * d / result[0, 2] + xo;
                cylinder[i].Y = result[0, 1] * d / result[0, 2] + yo;
                cylinder[i].Z = result[0, 2] * d / result[0, 2] + zo;
            }
        }
    }
}
