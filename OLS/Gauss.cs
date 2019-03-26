using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLS
{
    public class Gauss
    {
        public int size = 0;
        public double[] x_values_enter;
        public double[] y_values_enter;
        public double[] t;
        public double[] t_sum;
        public double[,] a;
        public double[] _x;
        public double[] _y;
        public double[] X;
        public double[] G;
        public double[] X_param;
        public double[] G_param;
        public double[] X_sum;
        public double[] G_sum;

        public void Count()
        {
            //size = value_dataGrid.Rows.Count - 1;//into form
            //a = new double[size, size];
            
            t = new double[size];
            t_sum = new double[size];
            //_x = new double[size];
            //_y = new double[size];

            #region Getting_Values
            //for (int i = 0; i < size; i++) //into form
            //{
            //    x_values_enter[i] = Double.Parse(value_dataGrid.Rows[i].Cells[0].Value.ToString());
            //    y_values_enter[i] = Double.Parse(value_dataGrid.Rows[i].Cells[1].Value.ToString());
            //}

            t[0] = 0;
            t_sum[0] = 0;
            for (int i = 1; i < size; i++)
            {
                t[i] = i;
                t_sum[i] = t_sum[i - 1] + Math.Sqrt(Math.Pow((x_values_enter[i] - x_values_enter[i - 1]), 2) + Math.Pow((y_values_enter[i] - y_values_enter[i - 1]), 2));
                //t_sum[i] = Math.Sqrt(Math.Pow((x_values_enter[i] - x_values_enter[0]), 2) + Math.Pow((y_values_enter[i] - y_values_enter[0]), 2));
            }
            #endregion

            #region Gauss
            {

                //double[] tmp_x = (double[])x_values_enter.Clone();
                //double[] tmp_y = (double[])y_values_enter.Clone();
                //G = MethodGauss(tmp_x, tmp_y, size, out X);

                G = MethodGauss(x_values_enter, y_values_enter, size, out X);
            }
            #endregion
            #region Param_Gauss
            {
                ////double[] Xr; double[] x; double[] y;

                ////x = MethodGaussParam(t, x_values_enter, y_values_enter, size, out Xr);
                ////double[] tmp_x = (double[])_x.Clone();
                ////double[] tmp_y = (double[])_y.Clone();
                ////double[] tmp_y = Count__Values(t, y_values_enter, size);
                //////y = MethodGauss(t, y_values_enter, size, out Xr);

                Count__Values(t, x_values_enter, y_values_enter, size);
                G_param = MethodGaussParam(t, _x, _y, size, out X_param);
            }
            #endregion
            #region Sum_Gauss
            {
                //double[] x; double[] y; double[] Xr;

                //x = MethodGaussParam(t_sum, x_values_enter, y_values_enter, size, out Xr);
                //double[] tmp_x = (double[])_x.Clone();
                //double[] tmp_y = (double[])_y.Clone();
                Count__Values(t_sum, x_values_enter, y_values_enter, size);
                //////y = MethodGaussParam(t_sum, tmp_y, size, out Xr);
                G_sum = MethodGaussParam(t_sum, _x, _y, size, out X_sum);
            }
            #endregion
            //Draw();
        }

        private void Count__Values(double[] t, double[] x, double[] y, int n)
        {
            a = new double[n, n];
            double[] x_values = (double[])x.Clone();
            double[] y_values = (double[])y.Clone();
            _x = new double[n];
            _y = new double[n];
            double max_min = Extremum(n, t);
            double K = Math.Pow(max_min, 2); // K
            double alpha = Math.PI * (n - 1) / K;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = Math.Exp(-alpha * Math.Pow(t[i] - t[j], 2));
                }
            }

            double[,] tmp_a = (double[,])a.Clone();
            _x = GaussMatr(a, x_values, n);
            _y = GaussMatr(tmp_a, y_values, n);
        }
        private double[] MethodGaussParam(double[] t_values, double[] x_values, double[] y_values, int n, out double[] XR)
        {
            //a = new double[n, n];
            double[] TR;
            double[] GR;

            double max_min = Extremum(n, t_values);
            double K = Math.Pow(max_min, 2); // K
            double alpha = Math.PI * (n - 1) / K;

            int amount = 10;
            int size = (n - 1) * amount;
            size++;
            double h;
            TR = new double[size];
            XR = new double[size];
            GR = new double[size];

            for (int i = 0; i < size - 1; i++)
            {
                XR[i] = 0;
                GR[i] = 0;
                h = (t_values[i / amount + 1] - t_values[i / amount]) / amount;
                TR[i] = t_values[i / amount] + i % amount * h;
                for (int j = 0; j < n; j++)
                {
                    XR[i] += _x[j] * Math.Exp(-alpha * Math.Pow(TR[i] - t_values[j], 2));
                    GR[i] += _y[j] * Math.Exp(-alpha * Math.Pow(TR[i] - t_values[j], 2));

                    //XR[i] += _x[j] * Math.Exp(-alpha * Math.Pow(TR[i] - x_values[j], 2));
                    //GR[i] += _y[j] * Math.Exp(-alpha * Math.Pow(TR[i] - y_values[j], 2));
                }
            }
            TR[size - 1] = t_values[n - 1];
            for (int j = 0; j < n; j++)
            {
                XR[size - 1] += _x[j] * Math.Exp(-alpha * Math.Pow(TR[size - 1] - t_values[j], 2));
                GR[size - 1] += _y[j] * Math.Exp(-alpha * Math.Pow(TR[size - 1] - t_values[j], 2));

                //XR[size - 1] += _x[j] * Math.Exp(-alpha * Math.Pow(TR[size - 1] - x_values[j], 2));
                //GR[size - 1] += _y[j] * Math.Exp(-alpha * Math.Pow(TR[size - 1] - y_values[j], 2));
            }
            return GR;
        }
        private double[] MethodGauss(double[] x_values, double[] y_values, int n, out double[] XR)
        {
            //double[,] a = new double[n,n];           

            double[] GR;

            a = new double[n, n];
            double max_min = Extremum(n, x_values);
            double K = Math.Pow(max_min, 2); // K
            double alpha = Math.PI * (n - 1) / K;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = Math.Exp(-alpha * Math.Pow(x_values[i] - x_values[j], 2));
                }
            }
            {
                double[,] tmp_a = (double[,])a.Clone();
                double[,] tmp_b = (double[,])a.Clone();
                double[] tmp_x_values = (double[])x_values.Clone();
                double[] tmp_y_values = (double[])y_values.Clone();
                _x = GaussMatr(tmp_a, tmp_x_values, n);
                _y = GaussMatr(tmp_b, tmp_y_values, n);
            }

            int amount = 7;
            int size = (n - 1) * amount;
            size++;
            double h;
            XR = new double[size];
            GR = new double[size];
            for (int i = 0; i < size - 1; i++)
            {
                GR[i] = 0;
                h = (x_values[i / amount + 1] - x_values[i / amount]) / amount;
                XR[i] = x_values[i / amount] + i % amount * h;
                for (int j = 0; j < n; j++)
                {
                    GR[i] += _y[j] * Math.Exp(-alpha * Math.Pow(XR[i] - x_values[j], 2));
                }
            }
            XR[size - 1] = x_values[n - 1];
            for (int j = 0; j < n; j++)
            {
                GR[size - 1] += _y[j] * Math.Exp(-alpha * Math.Pow(XR[size - 1] - x_values[j], 2));
            }
            return GR;
        }

        private double[] GaussMatr(double[,] t_a, double[] y, int n)
        {
            double[] x;
            //double[] y = new double[y_clone.Length];
            //double[] y = (double[])y_clone.Clone();
            double max;
            int k, index;
            const double eps = 0.00001;  // точность
            x = new double[n];
            k = 0;
            while (k < n)
            {
                // Поиск строки с максимальным a[i][k]
                max = Math.Abs(t_a[k, k]);
                index = k;
                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(t_a[i, k]) > max)
                    {
                        max = Math.Abs(t_a[i, k]);
                        index = i;
                    }
                }
                // Перестановка строк
                if (max < eps)
                {
                    // нет ненулевых диагональных элементов
                    //cout << "Решение получить невозможно из-за нулевого столбца ";
                    //cout << index << " матрицы A" << endl;
                    //return 0;
                    break;
                }
                for (int j = 0; j < n; j++)
                {
                    double t = t_a[k, j];
                    t_a[k, j] = t_a[index, j];
                    t_a[index, j] = t;
                }
                double temp = y[k];
                y[k] = y[index];
                y[index] = temp;
                // Нормализация уравнений
                for (int i = k; i < n; i++)
                {
                    double te = t_a[i, k];
                    if (Math.Abs(temp) < eps) continue; // для нулевого коэффициента пропустить
                    for (int j = 0; j < n; j++)
                    {
                        t_a[i, j] = t_a[i, j] / te;
                    }
                    y[i] = y[i] / te;
                    if (i == k) continue; // уравнение не вычитать само из себя
                    for (int j = 0; j < n; j++)
                    {
                        t_a[i, j] = t_a[i, j] - t_a[k, j];
                    }
                    y[i] = y[i] - y[k];
                }
                k++;
            }
            // обратная подстановка
            for (k = n - 1; k >= 0; k--)
            {
                x[k] = y[k];
                for (int i = 0; i < k; i++)
                {
                    y[i] = y[i] - t_a[i, k] * x[k];
                }
            }
            return x;
        }

        private double Extremum(int size, double[] x)
        {
            double min = x[0];
            double max = x[0];
            size = x.Length;
            //double min = Double.Parse(value_dataGrid.Rows[0].Cells[0].Value.ToString());
            //double max = Double.Parse(value_dataGrid.Rows[0].Cells[0].Value.ToString());
            for (int i = 1; i < size; i++)
            {
                double tmp = x[i];
                //double tmp = Double.Parse(value_dataGrid.Rows[i].Cells[0].Value.ToString());
                if (tmp > max)
                {
                    max = tmp;
                }
                else
                {
                    if (tmp < min)
                    {
                        min = tmp;
                    }
                }
            }
            return max - min;
        }
    }
}
