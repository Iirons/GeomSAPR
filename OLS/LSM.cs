using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Math;


namespace OLS
{
    public class LSM
    {
        public double C0, C1, C2;

        public void FillTheMatrix3(List<PointD> points)
        {
            double s1 = 0, s2 = 0, s3 = 0, s4 = 0, s5 = 0, s6 = 0, s7 = 0;
            foreach(var p in points)
            {
                s1 += p.X;
                s2 += p.X * p.X;
                s3 += p.X * p.X * p.X;
                s4 += p.X * p.X * p.X * p.X;
                s5 += p.Y;
                s6 += p.Y * p.X;
                s7 += p.X * p.X * p.Y;
            }

            double[,] A =
            {
                {points.Count, s1, s2 },
                {s1,s2,s3 },
                {s2,s3,s4 }
            };

            double[,] B =
            {
                {s5},
                {s6},
                {s7}
            };

            double[,] X = Matrix.Solve(A,B, leastSquares: true);

            C0 = X[0, 0];
            C1 = X[1, 0];
            C2 = X[2, 0];

            string strInv = X.ToCSharp();

            //MessageBox.Show(strInv);

        }

        public void FillTheMatrix2(List<PointD> points)
        {
            double s1 = 0, s2 = 0, s3 = 0, s4 = 0;
            foreach (var p in points)
            {
                s1 += p.X;
                s2 += p.X * p.X;
                s3 += p.Y;
                s4 += p.Y * p.X;
            }

            double[,] A =
            {
                {points.Count, s1 },
                {s1,s2 }
            };

            double[,] B =
            {
                {s3},
                {s4}
            };

            double[,] X = Matrix.Solve(A, B, leastSquares: true);

            C0 = X[0, 0];
            C1 = X[1, 0];

            string strInv = X.ToCSharp();

            //MessageBox.Show(strInv);

        }
    }



    //public class Matrix
    //{
    //    public Matrix(int N, int M)
    //    {
    //        m = M;
    //        n = N;
    //        mass = new double[N, M];
    //    }
    //    public Matrix(Matrix source)
    //    {
    //        this.m = source.M;
    //        this.n = source.N;
    //        this.mass = new double[source.N, source.M];
    //        this.mass = (double[,])source.mass.Clone();
    //    }
    //    ~Matrix()
    //    {
    //        m = 0;
    //        n = 0;
    //        mass = null;
    //    }
    //    private double[,] mass;
    //    private int m, n;
    //    public int N
    //    {
    //        get
    //        {
    //            if (n > 0)
    //                return n;
    //            else
    //                return -1;
    //        }
    //    }
    //    public int M
    //    {
    //        get
    //        {
    //            if (m > 0)
    //                return m;
    //            else
    //                return -1;
    //        }
    //    }
    //    public double this[int i, int j]
    //    {
    //        get
    //        {
    //            if (n > 0 && m > 0)
    //                if (i > -1 && j > -1)
    //                    return mass[i, j];
    //                else
    //                    Console.WriteLine("Неверный индексы");
    //            else
    //                Console.WriteLine("Не задана матрица");
    //            return -1;
    //        }
    //        set
    //        {
    //            if (n > 0 && m > 0)
    //                if (i > -1 && j > -1)
    //                    mass[i, j] = value;
    //                else
    //                    Console.WriteLine("Неверный индексы");
    //            else
    //                Console.WriteLine("Не задана матрица");
    //        }
    //    }
    //    public static Matrix operator *(Matrix A, Matrix B)
    //    {
    //        if (A.m != B.n) //Нужно только одно соответствие
    //            throw new System.ArgumentException("Не совпадают размерности матриц");
    //        Matrix C = new Matrix(A.n, B.m); //Столько же строк, сколько в А; столько столбцов, сколько в B 
    //        for (int i = 0; i < A.n; ++i)
    //        {
    //            for (int j = 0; j < B.m; ++j)
    //            {
    //                C[i, j] = 0;
    //                for (int k = 0; k < A.m; ++k)
    //                { //ТРЕТИЙ цикл, до A.m=B.n
    //                    C[i, j] += A[i, k] * B[k, j]; //Собираем сумму произведений
    //                }
    //            }
    //        }
    //        return C;
    //    }
    //    public Matrix Copy()
    //    {
    //        return new Matrix(this);
    //    }
    //}
}
