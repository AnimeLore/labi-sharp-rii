using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        // Создаем и заполняем двоичный файл случайными числами
        string binaryFilePath = "randomNumbers.bin";
        CreateAndDisplayBinaryFile(binaryFilePath);

        // Вычисляем среднее арифметическое чисел в файле
        CalculateAverage(binaryFilePath);

        // Работаем с файлом, содержащим сведения о деталях
        string detailsFilePath = "details.bin";
        CreateDetailsFile(detailsFilePath);
        DisplayDetail(detailsFilePath);
    }

    static void CreateAndDisplayBinaryFile(string filePath)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int number = rand.Next(100);
                writer.Write(number);
            }
        }

        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            Console.WriteLine("Содержимое файла:");
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                Console.WriteLine(reader.ReadInt32());
            }
        }
    }

    static void CalculateAverage(string filePath)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            int sum = 0;
            int count = 0;
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                sum += reader.ReadInt32();
                count++;
            }

            double average = (double)sum / count;
            Console.WriteLine($"Среднее арифметическое: {average}");
        }
    }

    static void CreateDetailsFile(string filePath)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create), Encoding.UTF8))
        {
            writer.Write(1); // Код детали
            writer.Write("Деталь номер один".PadRight(15)); // Наименование
            writer.Write(30); // Количество

            writer.Write(2);
            writer.Write("Вторая деталь".PadRight(15));
            writer.Write(20);
        }
    }

    static void DisplayDetail(string filePath)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open), Encoding.UTF8))
        {
            Console.WriteLine("Введите порядковый номер детали для вывода:");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            long position = index * (4 + 15 + 4); // Рассчитываем позицию

            if (position >= reader.BaseStream.Length)
            {
                Console.WriteLine("Деталь с таким номером не найдена");
            }
            else
            {
                reader.BaseStream.Seek(position, SeekOrigin.Begin);
                int code = reader.ReadInt32();
                string name = reader.ReadString();
                int quantity = reader.ReadInt32();

                Console.WriteLine($"Код: {code}, Наименование: {name.Trim()}, Количество: {quantity}");
            }
        }
    }
}
