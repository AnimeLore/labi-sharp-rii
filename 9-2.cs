using System;

public class MatrixOperations
{
    // Метод для ввода прямоугольной матрицы
    public static int[,] InputMatrix(int m, int n)
    {
        int[,] matrix = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Введите элемент [{i + 1}, {j + 1}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        return matrix;
    }

    // Метод для упорядочивания элементов между минимальным и максимальным элементами в каждой строке
    public static void SortElementsBetweenMinMax(int[,] matrix)
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);

        for (int i = 0; i < m; i++)
        {
            int minIndex = 0;
            int maxIndex = 0;

            // Нахождение индексов минимального и максимального элементов
            for (int j = 1; j < n; j++)
            {
                if (matrix[i, j] < matrix[i, minIndex])
                    minIndex = j;
                if (matrix[i, j] > matrix[i, maxIndex])
                    maxIndex = j;
            }

            // Упорядочивание элементов между minIndex и maxIndex
            if (minIndex > maxIndex)
            {
                int temp = minIndex;
                minIndex = maxIndex;
                maxIndex = temp;
            }

            Array.Sort(matrix, i, minIndex + 1, maxIndex - minIndex - 1);
        }
    }

    // Метод для сортировки части строки массива
    private static void Array.Sort(int[,] matrix, int row, int start, int length)
    {
        int[] temp = new int[length];
        for (int i = 0; i < length; i++)
        {
            temp[i] = matrix[row, start + i];
        }
        Array.Sort(temp);
        for (int i = 0; i < length; i++)
        {
            matrix[row, start + i] = temp[i];
        }
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
        // Задача 1
        Console.Write("Введите размерность квадратной матрицы n: ");
        int n = int.Parse(Console.ReadLine());

        int[,] squareMatrix = MatrixOperations.InputSquareMatrix(n);

        Console.WriteLine("Введенная квадратная матрица:");
        MatrixOperations.PrintMatrix(squareMatrix);

        double average = MatrixOperations.CalculateAveragePerimeterAndDiagonals(squareMatrix);
        Console.WriteLine($"Среднее арифметическое элементов на периметре и диагоналях: {average}");

        // Задача 2
        Console.Write("Введите количество строк m: ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов n: ");
        n = int.Parse(Console.ReadLine());

        int[,] matrix = MatrixOperations.InputMatrix(m, n);

        Console.WriteLine("Введенная матрица:");
        MatrixOperations.PrintMatrix(matrix);

        MatrixOperations.SortElementsBetweenMinMax(matrix);

        Console.WriteLine("Матрица после сортировки элементов между минимальным и максимальным элементами в каждой строке:");
        MatrixOperations.PrintMatrix(matrix);
    }
}
