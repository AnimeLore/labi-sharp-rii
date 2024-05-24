using System;
using System.IO;

class Program
{
    static void Main()
    {
        string basePath = "temp";
        string primPath = Path.Combine(basePath, "prim");
        string secondPath = Path.Combine(basePath, "second");
        string totalPath = Path.Combine(secondPath, "total");

        // Создание структуры каталогов
        Directory.CreateDirectory(primPath);
        Directory.CreateDirectory(totalPath);

        // Создание текстовых файлов
        Console.WriteLine("Введите количество файлов для создания в директории temp:");
        int fileCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < fileCount; i++)
        {
            string filePath = Path.Combine(basePath, $"file{i + 1}.txt");
            using (FileStream fs = File.Create(filePath))
            {
                Console.WriteLine($"Введите текст для файла {i + 1}:");
                string text = Console.ReadLine();
                byte[] info = new System.Text.UTF8Encoding(true).GetBytes(text);
                fs.Write(info, 0, info.Length);
            }
        }

        // Вывод содержимого каталога temp
        Console.WriteLine("Содержимое каталога temp:");
        foreach (var entry in Directory.EnumerateFileSystemEntries(basePath, "*", SearchOption.AllDirectories))
        {
            Console.WriteLine(entry);
        }

        // Изменение дат на файлах и каталогах
        File.SetLastWriteTime(Path.Combine(basePath, "file1.txt"), DateTime.Now.AddDays(-1));
        Directory.SetLastAccessTime(primPath, DateTime.Now.AddDays(-2));

        // Создание документа с результатами
        string resultFilePath = Path.Combine(basePath, "results.txt");
        using (StreamWriter sw = new StreamWriter(resultFilePath))
        {
            foreach (var entry in Directory.EnumerateFileSystemEntries(basePath, "*", SearchOption.AllDirectories))
            {
                var attr = File.GetAttributes(entry);
                sw.WriteLine(attr.HasFlag(FileAttributes.Directory) ? "Каталог" : "Файл");
                sw.WriteLine($"Имя: {Path.GetFileName(entry)}");
                sw.WriteLine($"Полное имя: {entry}");
                sw.WriteLine($"Дата создания: {File.GetCreationTime(entry)}");
                sw.WriteLine($"Дата последнего изменения: {File.GetLastWriteTime(entry)}");
                sw.WriteLine($"День: {File.GetLastWriteTime(entry).Day}");
                sw.WriteLine($"Месяц: {File.GetLastWriteTime(entry).Month}");
                sw.WriteLine($"Год: {File.GetLastWriteTime(entry).Year}");
                sw.WriteLine($"Время: {File.GetLastWriteTime(entry).TimeOfDay}");

                if (!attr.HasFlag(FileAttributes.Directory))
                {
                    sw.WriteLine($"Содержимое:");
                    using (StreamReader sr = new StreamReader(entry))
                    {
                        sw.WriteLine(sr.ReadToEnd());
                    }
                }
                else
                {
                    sw.WriteLine("Содержимого нет.");
                }
                sw.WriteLine();
            }
        }

        Console.WriteLine("Задачи выполнены. Результаты записаны в файл results.txt.");
    }
}
