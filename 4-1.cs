using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { -14, -21, -35, -49, -70, -5, -7, 14, 21, 35, 49, 70, 5, 7 }; // пример массива чисел

        int product = 1;
        int count = 0;

        foreach (int number in numbers)
        {
            if (number < 0 && number % 7 == 0 && number <= -10 && number >= -99)
            {
                product *= number;
                count++;
            }
        }

        if (count > 0)
        {
            Console.WriteLine($"Произведение: {product}");
        }
        else
        {
            Console.WriteLine("Нет двузначных отрицательных чисел, кратных 7.");
        }
        Console.WriteLine($"Количество: {count}");
    }
}