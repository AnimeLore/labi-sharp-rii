using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        // Записываем новый текст в файл
        AppendTextToFile("file1.txt");

        // Выводим строки, начинающиеся и заканчивающиеся на один и тот же символ
        PrintSpecialLines("file1.txt");

        // Добавляем порядковый номер к каждой строке и сохраняем в новый файл
        AddLineNumberToFile("file1.txt", "file2.txt");

        // Записываем выборочные байты в новый файл
        CopySelectedBytes("file1.txt", "file3.txt");

        // Записываем матрицу, умноженную на число, в файл
        WriteMatrixToFile();
    }

    static void AppendTextToFile(string filePath)
    {
        Console.WriteLine("Введите текст для добавления в файл:");
        string text = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(text);
        }
    }

    static void PrintSpecialLines(string filePath)
    {
        bool found = false;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length > 0 && line[0] == line[line.Length - 1])
                {
                    Console.WriteLine(line);
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Нет строк, начинающихся и заканчивающихся на один и тот же символ.");
        }
    }

    static void AddLineNumberToFile(string sourcePath, string destinationPath)
    {
        using (StreamReader reader = new StreamReader(sourcePath))
        using (StreamWriter writer = new StreamWriter(destinationPath))
        {
            string line;
            int lineNumber = 1;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine($"{lineNumber}: {line}");
                lineNumber++;
            }
        }
    }

    static void CopySelectedBytes(string sourcePath, string destinationPath)
    {
        using (FileStream fsSource = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
        using (FileStream fsDest = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
        {
            byte[] bytes = new byte[31]; // Максимум, что нам потребуется

            if (fsSource.Length >= 30)
            {
                // Чтение первых 5 байт
                fsSource.Read(bytes, 0, 5);
                fsDest.Write(bytes, 0, 5);

                // Перемещение на 15-й байт
                fsSource.Position = 15;
                fsSource.Read(bytes, 15, 16); // Читаем с 15 по 30 байт
                fsDest.Write(bytes, 15, 16);
            }
        }
    }

    static void WriteMatrixToFile()
    {
        Console.WriteLine("Введите размер матрицы MxN (M N):");
        string[] sizes = Console.ReadLine().Split(' ');
        int m = int.Parse(sizes[0]);
        int n = int.Parse(sizes[1]);
        int[,] matrix = new int[m, n];

        Console.WriteLine("Введите элементы матрицы построчно:");
        for (int i = 0; i < m; i++)
        {
            string[] elements = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(elements[j]);
            }
        }

        Console.WriteLine("Введите число для умножения:");
        int multiplier = int.Parse(Console.ReadLine());

        using (StreamWriter writer = new StreamWriter("matrixResult.txt"))
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    writer.Write(matrix[i, j] * multiplier + " ");
                }
                writer.WriteLine();
            }
        }
    }
}
