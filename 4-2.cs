using System;

class Program
{
    static void Main()
    {
        double k = -1;
        double n = 4;
        double dx = 0.3;
        double a = -3;

        for (double x = k; x <= n; x += dx)
        {
            double y;

            if (x < 0)
            {
                y = Math.Sin(Math.Log10(a * x) - Math.Abs(1 - 2 * x));
            }
            else if (x >= 0 && x <= 3)
            {
                y = x * x + Math.Sqrt(Math.Abs(x - a));
            }
            else
            {
                y = Math.Exp(a*x-1) / (1 + x * x * x * x);
            }

            Console.WriteLine($"x = {x:F1}, y = {y:F4}");
        }
    }
}
