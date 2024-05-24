using System;
using System.Linq;

public class MatrixOperations
{
    // Метод для ввода квадратной матрицы
    public static int[,] InputSquareMatrix(int n)
    {
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Введите элемент [{i + 1}, {j + 1}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        return matrix;
    }

    // Метод для вычисления среднего арифметического элементов на периметре и диагоналях
    public static double CalculateAveragePerimeterAndDiagonals(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int sum = 0;
        int count = 0;

        // Периметр
        for (int i = 0; i < n; i++)
        {
            sum += matrix[0, i]; // Верхняя строка
            sum += matrix[n - 1, i]; // Нижняя строка
            sum += matrix[i, 0]; // Левая колонка
            sum += matrix[i, n - 1]; // Правая колонка
            count += 4;
        }

        // Диагонали
        for (int i = 1; i < n - 1; i++) // исключаем угловые элементы, т.к. они уже посчитаны в периметре
        {
            sum += matrix[i, i]; // Главная диагональ
            sum += matrix[i, n - i - 1]; // Побочная диагональ
            count += 2;
        }

        return (double)sum / count;
    }

    // Метод для вывода матрицы
    public static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите размерность квадратной матрицы n: ");
        int n = int.Parse(Console.ReadLine());

        int[,] squareMatrix = MatrixOperations.InputSquareMatrix(n);

        Console.WriteLine("Введенная квадратная матрица:");
        MatrixOperations.PrintMatrix(squareMatrix);

        double average = MatrixOperations.CalculateAveragePerimeterAndDiagonals(squareMatrix);
        Console.WriteLine($"Среднее арифметическое элементов на периметре и диагоналях: {average}");
    }
}
