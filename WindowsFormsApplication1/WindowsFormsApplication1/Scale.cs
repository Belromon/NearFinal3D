using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Scale
    {
        int xo, yo, zo;
        Matrix matrix = new Matrix();

        public Scale(int xo, int yo, int zo)
        {
            this.xo = xo;
            this.yo = yo;
            this.zo = zo;
        }

        public void ScaleFigure(Pentagon pentagon, Cylinder cylinder, int N, double dx, double dy, double dz)
        {
            double[,] S = new double[4, 4] { { dx, 0, 0, 0 }, { 0, dy, 0, 0 }, { 0, 0, dz, 0 }, { 0, 0, 0, 1 } };

            double[,] result = new double[1, 4] { { 0, 0, 0, 0 } };

            for (int i = 0; i < 6; i++)
            {
                double[,] s = new double[1, 4] { { pentagon[i].X, pentagon[i].Y, pentagon[i].Z, 1 } };
                result = matrix.multiplyMatrixs(s, S);
                pentagon[i].X = result[0, 0] - (dx - 1) * xo;
                pentagon[i].Y = result[0, 1] - (dy - 1) * yo;
                pentagon[i].Z = result[0, 2] - (dz - 1) * zo;
            }
            result = new double[1, 4] { { 0, 0, 0, 0 } };
            for (int i = 0; i < 2 * N; i++)
            {
                double[,] s = new double[1, 4] { { cylinder[i].X, cylinder[i].Y, cylinder[i].Z, 1 } };
                result = matrix.multiplyMatrixs(s, S);
                cylinder[i].X = result[0, 0] - (dx - 1) * xo;
                cylinder[i].Y = result[0, 1] - (dy - 1) * yo;
                cylinder[i].Z = result[0, 2] - (dz - 1) * zo;
            }
        }
    }
}
