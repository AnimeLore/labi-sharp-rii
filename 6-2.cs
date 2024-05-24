using System;

public class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    // Конструктор
    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // Индексатор
    public double this[int index]
    {
        get
        {
            if (index == 0) return Real;
            if (index == 1) return Imaginary;
            throw new IndexOutOfRangeException("Invalid index for complex number.");
        }
    }

    // Перегрузка унарного минуса
    public static ComplexNumber operator -(ComplexNumber c)
    {
        return new ComplexNumber(c.Real, -c.Imaginary);
    }

    // Перегрузка операции сложения
    public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    // Перегрузка операции вычитания
    public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
    }

    // Перегрузка операции умножения
    public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(
            c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
            c1.Real * c2.Imaginary + c1.Imaginary * c2.Real
        );
    }

    // Перегрузка операции деления
    public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
    {
        double denominator = c2.Real * c2.Real + c2.Imaginary * c2.Imaginary;
        return new ComplexNumber(
            (c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / denominator,
            (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / denominator
        );
    }

    // Перегрузка операций с вещественными числами
    public static ComplexNumber operator +(ComplexNumber c, double d) => new ComplexNumber(c.Real + d, c.Imaginary);
    public static ComplexNumber operator -(ComplexNumber c, double d) => new ComplexNumber(c.Real - d, c.Imaginary);
    public static ComplexNumber operator *(ComplexNumber c, double d) => new ComplexNumber(c.Real * d, c.Imaginary * d);
    public static ComplexNumber operator /(ComplexNumber c, double d) => new ComplexNumber(c.Real / d, c.Imaginary / d);

    // Свойство для вычисления модуля комплексного числа
    public double Magnitude => Math.Sqrt(Real * Real + Imaginary * Imaginary);

    // Метод для отображения комплексного числа
    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        ComplexNumber c1 = new ComplexNumber(3, 4);
        ComplexNumber c2 = new ComplexNumber(1, -2);

        Console.WriteLine($"c1: {c1}");
        Console.WriteLine($"c2: {c2}");

        ComplexNumber sum = c1 + c2;
        ComplexNumber difference = c1 - c2;
        ComplexNumber product = c1 * c2;
        ComplexNumber quotient = c1 / c2;

        Console.WriteLine($"c1 + c2: {sum}");
        Console.WriteLine($"c1 - c2: {difference}");
        Console.WriteLine($"c1 * c2: {product}");
        Console.WriteLine($"c1 / c2: {quotient}");

        ComplexNumber conjugate = -c1;
        Console.WriteLine($"Conjugate of c1: {conjugate}");

        Console.WriteLine($"Magnitude of c1: {c1.Magnitude}");

        Console.WriteLine($"Real part of c1: {c1[0]}");
        Console.WriteLine($"Imaginary part of c1: {c1[1]}");
    }
}
