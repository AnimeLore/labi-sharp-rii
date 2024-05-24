using System;

public class ArrayOperations
{
    // Метод для ввода целочисленного одномерного массива
    public static int[] InputArray(int n)
    {
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            array[i] = int.Parse(Console.ReadLine());
        }
        return array;
    }

    // Метод для вывода массива
    public static void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Метод для вычисления количества элементов между минимальным и максимальным элементами
    public static int CountElementsBetweenMinMax(int[] array)
    {
        int minIndex = 0, maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[minIndex])
                minIndex = i;
            if (array[i] > array[maxIndex])
                maxIndex = i;
        }

        if (minIndex > maxIndex)
        {
            int temp = minIndex;
            minIndex = maxIndex;
            maxIndex = temp;
        }

        return (maxIndex - minIndex - 1);
    }

    // Метод для удаления всех отрицательных элементов и сдвига остальных элементов влево
    public static void RemoveNegativeElements(int[] array)
    {
        int count = 0; // Счетчик для хранения количества ненулевых элементов
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] >= 0)
            {
                array[count++] = array[i];
            }
        }

        // Заполнение оставшихся элементов нулями
        for (int i = count; i < array.Length; i++)
        {
            array[i] = 0;
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Введите количество элементов в массиве: ");
        int n = int.Parse(Console.ReadLine());

        int[] array = InputArray(n);

        Console.WriteLine("Введенный массив:");
        PrintArray(array);

        int countBetweenMinMax = CountElementsBetweenMinMax(array);
        Console.WriteLine($"Количество элементов между минимальным и максимальным элементами: {countBetweenMinMax}");

        RemoveNegativeElements(array);
        Console.WriteLine("Массив после удаления отрицательных элементов:");
        PrintArray(array);
    }
}
