using System;

namespace _1_лаба
{
    class Program
    {
        static void Main(string[] args)
        {
            double functiya(double x) => 4 * x - 8 * Math.Sin(x) + 1;

            double proizvodnaya(double x) => 4 - 8 * Math.Cos(x);

            double dihotomy(double a, double b)
            {
                int c = 0;
                double epsilon, x;
                x = 0;
                epsilon = Math.Pow(10, -5);
                while (b - a > epsilon)
                {
                    c++;
                    x = (a + b) / 2;
                    if (functiya(x) * functiya(b) >= 0)
                        b = x;
                    else
                        a = x;
                }
                Console.WriteLine(c);
                return (x);
            }


            double prostayaIteracia(double x0)
            {

                double xn = x0 - functiya(x0) / proizvodnaya(x0);
                int c = 1;
                double epsilon = Math.Pow(10, -5);
                while (Math.Abs(xn - x0) > epsilon)
                {
                    c++;
                    x0 = xn;
                    xn = x0 - functiya(x0) / proizvodnaya(x0);
                }
                Console.WriteLine(c);
                return (xn);
            }

            Console.WriteLine("Метод Дихотомии");
            Console.WriteLine(dihotomy(-3, -2));
            Console.WriteLine(dihotomy(0, 1));
            Console.WriteLine("Метод простой итерации");
            //Console.WriteLine(prostayaIteracia(-3, -2));
            Console.WriteLine(prostayaIteracia(-3));
            Console.WriteLine(prostayaIteracia(0));
        }
    }
}
