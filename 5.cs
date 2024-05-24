using System;

class Program
{
    static void Main()
    {
        // Входные данные
        double x = 0.5; // Пример значения x
        double eps = 1e-6; // Заданная точность eps

        // Вычисление значения функции по ряду
        double term = x / 3;
        double sum = term;
        int i = 1;

        while (Math.Abs(term) > eps)
        {
            term *= (1.0 * (3 * i - 2) / (3 * i)) * x;
            sum += ((i % 2 == 0) ? -1 : 1) * term;
            i++;
        }

        double y_approx = sum;

        // Вычисление значения функции с использованием контрольной формулы
        double y_exact = 1 - 1 / Math.Pow(1 + x, 1.0 / 3.0);

        // Вывод результатов
        Console.WriteLine($"Приближенное значение функции: {y_approx}");
        Console.WriteLine($"Точное значение функции: {y_exact}");
        Console.WriteLine($"Разница: {Math.Abs(y_approx - y_exact)}");
    }
}
