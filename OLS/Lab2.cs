using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLS
{
    public class Lab2
    {
        public double InterpolateLagrangePolynomial(double x, List<double> xValues, List<double> yValues, int size)
        {
            double lagrangePol = 0;

            for (int i = 0; i < size; i++)
            {
                double basicsPol = 1;
                for (int j = 0; j < size; j++)
                {
                    if (j != i)
                    {
                        basicsPol *= (x - xValues[j]) / (xValues[i] - xValues[j]);
                    }
                }
                lagrangePol += basicsPol * yValues[i];
            }

            return lagrangePol;
        }

        public double GetYPL(double x, List<double> xValues, List<double> yValues)
        {
            if (x == xValues[0]) return yValues[0];
            if (x == xValues[xValues.Count-1]) return yValues[xValues.Count-1];
            double ai = 0, bi = 0;
            double x1 = 0, x2 = 0, y1 = 0, y2 = 0;

            for(int i = xValues.Count-1; i>= 0; i--)
            {
                if(x > xValues[i])
                {
                    x1 = xValues[i];
                    x2 = xValues[i+1];
                    y1 = yValues[i];
                    y2 = yValues[i+1];
                    break;
                }
            }

            ai = (y2 - y1) / (x2 - x1);
            bi = y1 - ai * x1;


            return (ai * x + bi);
        }


    }
}
