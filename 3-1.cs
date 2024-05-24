using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите три числа:");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());

        SortAndPrintNumbers(a, b, c);
    }

    static void SortAndPrintNumbers(int a, int b, int c)
    {
        int min, mid, max;
        SortThreeNumbers(a, b, c, out min, out mid, out max);
        Console.WriteLine("Числа в порядке неубывания: {0} <= {1} <= {2}", min, mid, max);
    }

    static void SortThreeNumbers(int a, int b, int c, out int min, out int mid, out int max)
    {
        switch (a <= b)
        {
            case true:
                min = a;
                max = b;
                break;
            case false:
                min = b;
                max = a;
                break;
        }

        switch (c <= min)
        {
            case true:
                mid = min;
                min = c;
                break;
            case false:
                switch (c <= max)
                {
                    case true:
                        mid = c;
                        break;
                    case false:
                        mid = max;
                        max = c;
                        break;
                }
                break;
        }
    }
}
