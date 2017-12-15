using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Matrix
    {
        public double[,] multiplyMatrixs(double[,] mass, double[,] matrix)
        {
            int rowsA = 1,
                //colsA = 4,
                rowsB = 4,
                colsB = 4;
            double[,] newMatrix = new double[rowsA, colsB];
            for (int k = 0; k < colsB; k++)
            {
                for (int i = 0; i < rowsA; i++)
                {
                    double t = 0;
                    for (int j = 0; j < rowsB; j++)
                        t += mass[i, j] * matrix[j, k];
                    newMatrix[i, k] = t;
                }
            }
            return newMatrix;
        }
    }
}
