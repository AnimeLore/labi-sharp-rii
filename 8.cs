using System;

public class SortAlgorithms
{
    // Метод сортировки пузырьком
    public static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    // Метод сортировки вставками
    public static void InsertionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }

    // Метод сортировки выбором
    public static void SelectionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }

    // Метод для ввода целочисленного массива
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
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите метод сортировки:");
            Console.WriteLine("1. Сортировка пузырьком");
            Console.WriteLine("2. Сортировка вставками");
            Console.WriteLine("3. Сортировка выбором");
            Console.WriteLine("4. Выход");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 4)
            {
                break;
            }

            Console.Write("Введите количество элементов в массиве: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = SortAlgorithms.InputArray(n);

            Console.WriteLine("Исходный массив:");
            SortAlgorithms.PrintArray(array);

            switch (choice)
            {
                case 1:
                    SortAlgorithms.BubbleSort(array);
                    Console.WriteLine("Отсортированный массив (пузырьком):");
                    break;
                case 2:
                    SortAlgorithms.InsertionSort(array);
                    Console.WriteLine("Отсортированный массив (вставками):");
                    break;
                case 3:
                    SortAlgorithms.SelectionSort(array);
                    Console.WriteLine("Отсортированный массив (выбором):");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    continue;
            }

            SortAlgorithms.PrintArray(array);
        }
    }
}
