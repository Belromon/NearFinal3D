using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Translate
    {
        Matrix matrix = new Matrix();
        public void TranslateFigure(Pentagon pentagon, Cylinder cylinder, int N, int dx, int dy, int dz)
        {
            double[,] T = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { dx, dy, dz, 1 } };

            double[,] result = new double[1, 4] { { 0, 0, 0, 0 } };

            for (int i = 0; i < 6; i++)
            {
                double[,] s = new double[1, 4] { { pentagon[i].X, pentagon[i].Y, pentagon[i].Z, 1 } };
                result = matrix.multiplyMatrixs(s, T);
                pentagon[i].X = result[0, 0];
                pentagon[i].Y = result[0, 1];
                pentagon[i].Z = result[0, 2];
            }
            result = new double[1, 4] { { 0, 0, 0, 0 } };
            for (int i = 0; i < 2 * N; i++)
            {
                double[,] s = new double[1, 4] { { cylinder[i].X, cylinder[i].Y, cylinder[i].Z, 1 } };
                result = matrix.multiplyMatrixs(s, T);
                cylinder[i].X = result[0, 0];
                cylinder[i].Y = result[0, 1];
                cylinder[i].Z = result[0, 2];
            }
        }
    }
}
