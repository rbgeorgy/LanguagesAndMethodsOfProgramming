using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Equation
    {

        private double[] _coefArray;//a0,a1,a2,a3,a4,a5,a6

        public Equation(double[] array)
        {
            int n = array.Length;
            _coefArray = new double[n];
            for (int i = 0; i < n; i++)
            {
                _coefArray[i] = array[i];
            }
        }


        private double[] solveOne(double a, double b) {
            
            double[] ans = new double[1];
            ans[0] = -b / a;
            return ans;
        }

        private double[] solveTwo(double a, double b, double c)
        {

            double[] ans2 = new double[3];

            double discriminant = b * b - 4 * a * c;
            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                ans2[0] = x1;
                ans2[1] = x2;
                ans2[2] = 0;
                return ans2;
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                ans2[0] = ans2[1] = x;
                ans2[2] = 0;
                return ans2;
            }
            else
            {
                //x1=Real+i*Im; x2=Real-i*Im
                double Real = (-b) / (2 * a);
                double Im = Math.Sqrt(-discriminant) / (2 * a);
                ans2[0] = Real;
                ans2[1] = Im;
                ans2[2] = 1;
                return ans2;
            }
        }

        private static double CubeRoot(double x)
        {
            if (x < 0)
                return -Math.Pow(-x, 1d / 3d);
            else
                return Math.Pow(x, 1d / 3d);
        }

        public static double[] solve3DeltaLessThanZeroTwoComplex(double a, double b, double c, double d)//<=
        {

            double delta = -4 * b * b * b * d + b * b * c * c - 4 * a * c * c * c + 18 * a * b * c * d - 27 * a * a * d * d;
            Console.WriteLine("delta = " + delta);
            double p = -(b * b) / (3.0 * a * a) + c / a;
            double q = (2 * b * b * b) / (27.0 * a * a * a) - (b * c) / (3.0 * a * a) + d / a;
            double Q = p * p * p / 27.0 + q * q / 4.0;
            Console.WriteLine("Q = " + Q);

            double alphaCube = -q / 2.0 + Math.Sqrt(Q);
            double alpha = CubeRoot(alphaCube);
            Console.WriteLine("alpha = " + alpha);
            double betaCube = -q / 2.0 - Math.Sqrt(Q);
            double beta = CubeRoot(betaCube);
            Console.WriteLine("beta = " + beta);

            double y1 = alpha + beta;
            Console.WriteLine("y1 = " + y1);
            //to ret
            double x1 = y1 - b / (3.0 * a);
            Console.WriteLine("x1 = " + x1);

            double realPart = -(alpha + beta) / 2.0;
            Console.WriteLine("realPart = " + realPart);

            double imagePart = Math.Sqrt(3) * (alpha - beta) / 2.0;
            Console.WriteLine("imagePart = " + imagePart);

            double[] arr = new double[3];
            arr[0] = x1;
            arr[1] = realPart - b / (3.0 * a);
            arr[2] = imagePart;
            
            return arr;

        }

        public static double[] solve3real(double a, double b, double c, double d) //>0
        {

            if (a != (double)1)
            {
                b = b / a;
                c = c / a;
                d = d / a;
                a = 1;
            }

            double A = b;
            double B = c;
            double C = d;

            double Q = (3 * B - A * A) / 9;
            Console.WriteLine("Q = " + Q);
            double R = (9 * A * B - 27 * C - 2 * A * A * A) / 54;
            Console.WriteLine("R = " + R);
            double D = Q * Q * Q + R * R;
            Console.WriteLine("D = " + D);
            double[] arr = new double[3];
            if (D < 0)
            {
                double cos = R / Math.Sqrt(-Q * Q * Q);
                double arccos = Math.Acos(cos);
                double x1 = 2 * Math.Sqrt(-Q) * Math.Cos(arccos / 3.0) - A / 3.0;
                double x2 = 2 * Math.Sqrt(-Q) * Math.Cos(arccos / 3.0 + 2 * Math.PI / 3.0) - A / 3.0;
                double x3 = 2 * Math.Sqrt(-Q) * Math.Cos(arccos / 3.0 + 4 * Math.PI / 3.0) - A / 3.0;

                Console.WriteLine(cos);
                Console.WriteLine(arccos);
                Console.WriteLine(x1);
                Console.WriteLine(x2);
                Console.WriteLine(x3);

                arr[0] = x1;
                arr[1] = x2;
                arr[2] = x3;
            }
            return arr;
        }

        private double[] solveThree(double a, double b, double c, double d)
        {
    
            double[] ans3 = new double[6];//[3] is which case

            
            double p = (c / a) - (b * b) / (3.0 * a * a);
            double q = (2.0 * b * b * b) / (27.0 * a * a * a) - (b * c) / (3.0 * a * a) + (d / a);
            double Q = ((p * p * p) / 27.0) + ((q * q) / 4.0);


            if (Q < 0) 
            {
                double[]tmp = solve3real(a, b, c, d);
                ans3[3] = 2;
                ans3[0] = tmp[0];
                ans3[1] = tmp[1];
                ans3[2] = tmp[2];
            }
            
            else
            {

                double[] tmp = solve3DeltaLessThanZeroTwoComplex(a, b, c, d);

                ans3[0] = tmp[0];
                ans3[1] = tmp[1];
                ans3[2] = tmp[2];
                ans3[3] = 0;
            }

            return ans3;
        }

        public double[] Evaluate(int n)
        {
            switch (n)
            {
                case 1:
                    return solveOne(_coefArray[1], _coefArray[0]);
                case 2:
                    return solveTwo(_coefArray[2], _coefArray[1], _coefArray[0]);
                case 3:
                    return solveThree(_coefArray[3], _coefArray[2], _coefArray[1], _coefArray[0]);
                default:
                    double[] ansdef = new double[1];
                    return ansdef;
            }
        }

    }

    static class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
