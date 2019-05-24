using System;

namespace BoundaryTask
{
    public static class Algorithms
    {
        //Method0
        public static Node[] ExactSolution(int numberPoints)
        {
            var h = 1.0 / numberPoints;
            var result = new Node[numberPoints + 1];
            Func<double, double> solution = x =>Math.Pow(Math.E,x) + Math.Pow(Math.E, -x) + 2.1*x*x -2.1*x -2;
            for (var i = 0; i < numberPoints + 1; i++) result[i] = new Node(i * h, solution(i * h));

            return result;
        }

        //Method1
        public static Node[] DifferentialSweepMethod(int numberPoints)
        {
            var h = 1.0 / numberPoints;
            var result = new Node[numberPoints + 1];
            Func<double, double> f = (x) => h*h*(2.1*x - 2.1*x*x + 6.2);
            var arrAi = new double[numberPoints +1];
            var arrBi = new double[numberPoints +1];
            var arrCi = new double[numberPoints +1];
            var arrDi = new double[numberPoints +1];
            for (var i = 1; i < numberPoints; i++)
            {
                arrAi[i] = 1;
                arrBi[i] = -(2 + h * h);
                arrCi[i] = 1;
                arrDi[i] = f(h * i);
            }
            arrBi[0] = 1;
            arrAi[numberPoints] = 2;
            arrBi[numberPoints] = -(2 * h + 2 + h * h);
            arrDi[numberPoints] = h * h * 6.2 - 2*h*(2*Math.E+0.1);
            var arrLi = new double[numberPoints + 2];
            var arrMi = new double[numberPoints + 2];

            for (var i = 0; i < numberPoints+1; i++)
            {
                var numerator = arrAi[i] * arrLi[i] + arrBi[i];
                arrLi[i + 1] = -arrCi[i] / numerator;
                arrMi[i + 1] = (arrDi[i] - arrMi[i] * arrAi[i]) / numerator;
            }

            var yn = arrMi[numberPoints+1];
            result[numberPoints] = new Node(1,yn);
            for (var i = numberPoints-1; i>-1; i--)
            {
                yn = arrLi[i+1] * yn + arrMi[i+1];
                result[i] = new Node(i * h, yn);
            }

            return result;
        }

        //Method2
        public static Node[] ShootingMethod(int numberPoints)
        {
            Func<double, double> f = (x) =>
            {
                var resEuler = RecountedEulerMethod(numberPoints, x);
                return resEuler.arrZ[numberPoints].Y + resEuler.arrY[numberPoints].Y - 2*Math.E -0.1;
            };
            var boundaries = SearchForBoundaries(f);
            var mu = Dichotomy(f, boundaries.a, boundaries.b, 0.5E-4);

            return RecountedEulerMethod(numberPoints, mu).arrY;
        }

        private static (double a, double b) SearchForBoundaries(Func<double, double> f)
        {
            var a = -1;
            var b = 1;
            for (int i = 0; i < 20; i++)
            {
                if (f(a) * f(b) < 0)
                    break;
                a--;
                b++;
            }

            return (a, b);
        }
        private static (Node[] arrY, Node[] arrZ) RecountedEulerMethod(int numberPoints, double mu)
        {
            var h = 1.0 / numberPoints;
            var arrY = new Node[numberPoints + 1];
            var arrZ = new Node[numberPoints + 1];
            var yi = 0.0;
            var zi = mu;
            arrY[0] = new Node(0, yi);
            arrZ[0] = new Node(0, zi);
            Func<double, double, double, double> f1 = (x, y,z) => z;
            Func<double, double, double, double> f2 = (x, y,z) => y + 2.1*x -2.1*x*x + 6.2;
            for (var i = 1; i < numberPoints + 1; i++)
            {
                var xi = (i-1) * h;
                var f1xi = f1(xi, yi, zi);
                var f2xi = f2(xi, yi, zi);
                yi = yi + (h / 2) * (f1xi + f1(xi + h, yi + h * f1xi, zi));
                zi = zi + (h / 2) * (f2xi + f2(xi + h, yi, zi + h* f2xi));
                arrY[i] = new Node(h*i,yi);
                arrZ[i] = new Node(h * i, zi);
            }
            return (arrY, arrZ);

        }


        private static double Dichotomy(Func<double, double> func, double a, double b, double eps)
        {
            var c = (a + b) / 2;
            while (Math.Abs(b - a) > eps)
            {
                if (func(a) * func( c) < 0)
                    b = c;
                else if (func( c) * func( b) < 0)
                    a = c;
                c = (b + a) / 2;
            }
            return c;
        }

    }
}