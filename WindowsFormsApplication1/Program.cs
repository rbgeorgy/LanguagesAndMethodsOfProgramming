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

        public static String[] solveFour(double a, double b, double c, double d, double e)
        {
            
            double P = 8 * a * c - 3 * b * b;
            double R = b * b * b + 8 * d * a * a - 4 * a * b * c;

            double BigDelta = 256 * a * a * a * e * e * e - 192 * a * a * b * d * e * e - 128 * a * a * c * c * e * e + 144 * a * a * c * d * d * e - 27 * a * a * d * d * d * d + 144 * a * b * b * c * e * e - 6 * a * b * b * d * d * e - 80 * a * b * c * c * d * e + 18 * a * b * c * d * d * d + 16 * a * c * c * c * c * e - 4 * a * c * c * c * d * d - 27 * b * b * b * b * e * e + 18 * b * b * b * c * d * e - 4 * b * b * b * d * d * d - 4 * b * b * c * c * c * e + b * b * c * c * d * d;

            double Delta = c * c - 3 * b * d + 12 * a * e;
            double DeltaOne = 2 * c * c * c - 9 * b * c * d + 27 * b * b * e + 27 * a * d * d - 72 * a * c * e;
            double D = 64 * a * a * a * e - 16 * a * a * c * c + 16 * a * b * b * c - 16 * a * a * b * d -
                       3 * b * b * b * b;

            double p = (8 * a * c - 3 * b * b) / (a * a * 8.0);
            double q = (b * b * b - 4 * a * b * c + 8 * a * a * d) / (8.0 * a * a * a);

            Console.WriteLine("BigDelta = " + BigDelta);

            String[] ans4 = new String[5];//x1 x2 x3 x4 case : 
                                                             // 0 -- two complex two real
                                                            // 1 -- four real
                                                           // 2 -- OMAGAD TRASH

            if (BigDelta < 0)
            {
               return deltaLessThanZero(a, b, c, d, e, Delta, DeltaOne);
            }

            if (BigDelta > 0)
            {
                if (P < 0 && D < 0)
                {
                    double Phi = Math.Acos(DeltaOne / (2 * Math.Sqrt(Delta * Delta * Delta)));
                    double S = 0.5 * Math.Sqrt((-2 / 3.0) * p + (2 / (3.0 * a)) * Math.Sqrt(Delta) * Math.Cos(Phi / 3.0));
                    double underrootOne = -4 * S * S - 2 * p + q / S;
                    double underrootTwo = -4 * S * S - 2 * p - q / S;
                    double x1 = 0;
                    double x2 = 0;
                    double x3 = 0;
                    double x4 = 0;
                    x1 = -b / (4.0 * a) - S + 0.5 * Math.Sqrt(underrootOne);
                    x2 = -b / (4.0 * a) - S - 0.5 * Math.Sqrt(underrootOne);
                    x3 = -b / (4.0 * a) + S + 0.5 * Math.Sqrt(underrootTwo);
                    x4 = -b / (4.0 * a) + S - 0.5 * Math.Sqrt(underrootTwo);
                    Console.WriteLine("x1 = " + x1);
                    Console.WriteLine("x2 = " + x2);
                    Console.WriteLine("x3 = " + x3);
                    Console.WriteLine("x4 = " + x4);

                    ans4[0] = x1.ToString();
                    ans4[1] = x2.ToString();
                    ans4[2] = x3.ToString(); ;
                    ans4[3] = x4.ToString();
                    int whichCase = 1;
                    ans4[4] = whichCase.ToString();
                }                

                if (P > 0 || D > 0)
                {
                    Console.WriteLine("4 комплексных корня, сложные отображения");
                    double ImPartCube = getQim(Delta, DeltaOne);
                    double realPartCube = DeltaOne / 2.0;

                    String Q = "CubeRoot(" + realPartCube + " + i*" + ImPartCube + ")";
                    String QPlusFracDeltaQ = Q + Delta + "/" + Q;

                    double firstUndeRootS = (-2 / 3.0) * p;
                    double secondUndeRootS = (1 / (3.0 * a));
                    String S = 0.5 + "* SquareRoot(" + firstUndeRootS + " + " + secondUndeRootS + "*" + QPlusFracDeltaQ +
                        ")";

                    String x12 = -b / (4.0 * a) + "-S +- 0.5* SquareRoot(-4(" + S + ")^2 - " + 2 * p + " + " + q + "/" + S;
                    String x34 = -b / (4.0 * a) + "+S +- 0.5* SquareRoot(-4(" + S + ")^2 - " + 2 * p + " - " + q + "/" + S;
                    Console.WriteLine(x12);
                    Console.WriteLine(x34);

                    ans4[0] = -b / (4.0 * a) + "-S + 0.5* SquareRoot(-4(" + S + ")^2 - " + 2 * p + " + " + q + "/" + S;
                    ans4[1] = -b / (4.0 * a) + "-S - 0.5* SquareRoot(-4(" + S + ")^2 - " + 2 * p + " + " + q + "/" + S;
                    ans4[2] = -b / (4.0 * a) + "+S + 0.5* SquareRoot(-4(" + S + ")^2 - " + 2 * p + " - " + q + "/" + S;
                    ans4[3] = -b / (4.0 * a) + "+S - 0.5* SquareRoot(-4(" + S + ")^2 - " + 2 * p + " - " + q + "/" + S;
                    int whichCase = 2;
                    ans4[4] = whichCase.ToString();
                }
            }

            if (BigDelta == 0)
            {
                if (Delta == 0 && D != 0)
                {
                    double Phi = Math.Acos(DeltaOne / (2 * Math.Sqrt(Delta * Delta * Delta)));
                    double S = 0.5 * Math.Sqrt((-2 / 3.0) * p + (2 / (3.0 * a)) * Math.Sqrt(Delta) * Math.Cos(Phi / 3.0));
                    double underrootOne = -4 * S * S - 2 * p + q / S;
                    double underrootTwo = -4 * S * S - 2 * p - q / S;
                    double x1 = 0;
                    double x2 = 0;
                    double x3 = 0;
                    double x4 = 0;
                    x1 = -b / (4.0 * a) - S + 0.5 * Math.Sqrt(underrootOne);
                    x2 = -b / (4.0 * a) - S - 0.5 * Math.Sqrt(underrootOne);
                    x3 = -b / (4.0 * a) + S + 0.5 * Math.Sqrt(underrootTwo);
                    x4 = -b / (4.0 * a) + S - 0.5 * Math.Sqrt(underrootTwo);
                    Console.WriteLine("x1 = " + x1);
                    Console.WriteLine("x2 = " + x2);
                    Console.WriteLine("x3 = " + x3);
                    Console.WriteLine("x4 = " + x4);
                    ans4[0] = x1.ToString();
                    ans4[1] = x2.ToString();
                    ans4[2] = x3.ToString(); ;
                    ans4[3] = x4.ToString();
                    int whichCase = 1;
                    ans4[4] = whichCase.ToString();

                }
                else
                {
                    return deltaLessThanZero(a, b, c, d, e, Delta, DeltaOne);
                }
            }
            return ans4;
        }

        private static double getQ(double Delta, double DeltaOne)
        {
            return CubeRoot((DeltaOne + Math.Sqrt(DeltaOne * DeltaOne - 4 * Delta * Delta * Delta)) / 2.0);
        }

        private static double getQim(double Delta, double DeltaOne)
        {
            double minusUnderQ = -DeltaOne * DeltaOne + 4 * Delta * Delta * Delta;
            double ImPartCube = Math.Sqrt(minusUnderQ) / 2.0;
            //double RealPartCube = DeltaOne / 2.0;
            return ImPartCube;
        }

        private static String[] deltaLessThanZero(double a, double b, double c, double d, double e, double Delta, double DeltaOne)
        {
            double p = (8 * a * c - 3 * b * b) / (a * a * 8.0);
            double q = (b * b * b - 4 * a * b * c + 8 * a * a * d) / (8.0 * a * a * a);
            double Q = getQ(Delta, DeltaOne);
            double S = 0.5 * Math.Sqrt(-(2 / 3.0) * p + (1 / (3.0 * a)) * (Q + Delta / Q));

            double underrootOne = -4 * S * S - 2 * p + q / S;
            double underrootTwo = -4 * S * S - 2 * p - q / S;

            double x1 = 0;
            double x2 = 0;
            double realPart = 0;
            double imPart = 0;

            if (underrootOne >= 0)
            {
                x1 = -b / (4.0 * a) - S + 0.5 * Math.Sqrt(underrootOne);
                x2 = -b / (4.0 * a) - S - 0.5 * Math.Sqrt(underrootOne);
                realPart = -b / (4.0 * a) + S; // + 0.5 * i*Math.Sqrt(-underrootTwo);
                imPart = 0.5 * Math.Sqrt(-underrootTwo);// - 0.5 *i* Math.Sqrt(-underrootTwo);

            }

            else if (underrootTwo >= 0)
            {
                x1 = -b / (4.0 * a) - S + 0.5 * Math.Sqrt(underrootTwo);
                x2 = -b / (4.0 * a) - S - 0.5 * Math.Sqrt(underrootTwo);
                realPart = -b / (4.0 * a) + S; // + 0.5 * i*Math.Sqrt(-underrootTwo);
                imPart = 0.5 * Math.Sqrt(-underrootOne);// - 0.5 *i* Math.Sqrt(-underrootTwo);
            }

            String[] res = new String[5];

            res[0] = x1.ToString();
            res[1] = x2.ToString();
            res[2] = realPart + " + i*" + imPart;
            res[3] = realPart + " - i*" + imPart;
            int whichCase = 0;
            res[4] = whichCase.ToString();

            Console.WriteLine("x1 = " + x1);
            Console.WriteLine("x2 = " + x2);
            Console.WriteLine("x3 = " + realPart + " + i*" + imPart);
            Console.WriteLine("x4 = " + realPart + " - i*" + imPart);
            return res;

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

        public string[] EvaluateFour() {
            return solveFour(_coefArray[4] ,_coefArray[3], _coefArray[2], _coefArray[1], _coefArray[0]);
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
