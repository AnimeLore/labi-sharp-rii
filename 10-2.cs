using System;
using System.Collections.Generic;
using System.Linq;

class DictionaryTasks
{
    public static void Main()
    {
        Console.WriteLine("Выберите задачу:");
        Console.WriteLine("1. Прирост населения");
        Console.WriteLine("2. Студенты-должники");
        Console.WriteLine("3. Абоненты");

        switch (Console.ReadLine())
        {
            case "1":
                var populationGrowth = InputPopulationGrowth();
                PrintAverageGrowth(populationGrowth);
                break;
            case "2":
                var students = InputStudents();
                PrintStudents(students);
                break;
            case "3":
                var subscribers = InputSubscribers();
                PrintSubscribers(subscribers);

                Console.Write("Введите телефонный номер для поиска абонента: ");
                string phoneNumber = Console.ReadLine();
                FindSubscriberByPhoneNumber(subscribers, phoneNumber);

                Console.Write("Введите фамилию для поиска абонента: ");
                string lastName = Console.ReadLine();
                FindSubscriberByLastName(subscribers, lastName);
                break;
            default:
                Console.WriteLine("Неверный ввод. Запустите программу заново.");
                break;
        }
    }

    public static Dictionary<string, List<double>> InputPopulationGrowth()
    {
        Dictionary<string, List<double>> populationGrowth = new Dictionary<string, List<double>>();
        Console.Write("Введите количество городов: ");
        int citiesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < citiesCount; i++)
        {
            Console.Write($"Введите название города {i + 1}: ");
            string city = Console.ReadLine();
            List<double> growth = new List<double>();

            for (int year = 2012; year <= 2016; year++)
            {
                Console.Write($"Введите прирост населения для {city} в {year} году: ");
                growth.Add(double.Parse(Console.ReadLine()));
            }

            populationGrowth[city] = growth;
        }

        return populationGrowth;
    }

    public static void PrintAverageGrowth(Dictionary<string, List<double>> populationGrowth)
    {
        foreach (var entry in populationGrowth)
        {
            double average = entry.Value.Average();
            Console.WriteLine($"Средний прирост населения в {entry.Key}: {average}");
        }
    }

    public static Dictionary<string, List<string>> InputStudents()
    {
        Dictionary<string, List<string>> students = new Dictionary<string, List<string>>();
        Console.Write("Введите количество студентов: ");
        int studentCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < studentCount; i++)
        {
            Console.Write("Введите ФИО студента: ");
            string name = Console.ReadLine();
            List<string> subjects = new List<string>();

            Console.Write("Введите количество задолженностей: ");
            int subjectCount = int.Parse(Console.ReadLine());

            for (int j = 0; j < subjectCount; j++)
            {
                Console.Write($"Введите название дисциплины {j + 1}: ");
                subjects.Add(Console.ReadLine());
            }

            students[name] = subjects;
        }

        return students;
    }

    public static void PrintStudents(Dictionary<string, List<string>> students)
    {
        foreach (var entry in students)
        {
            Console.WriteLine($"Студент: {entry.Key}");
            Console.WriteLine("Задолженности: " + string.Join(", ", entry.Value));
        }
    }

    public static Dictionary<string, List<string>> InputSubscribers()
    {
        Dictionary<string, List<string>> subscribers = new Dictionary<string, List<string>>();
        Console.Write("Введите количество абонентов: ");
        int subscriberCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < subscriberCount; i++)
        {
            Console.Write("Введите ФИО абонента: ");
            string name = Console.ReadLine();
            List<string> phoneNumbers = new List<string>();

            Console.Write("Введите количество номеров телефона: ");
            int phoneNumberCount = int.Parse(Console.ReadLine());

            for (int j = 0; j < phoneNumberCount; j++)
            {
                Console.Write($"Введите номер телефона {j + 1}: ");
                phoneNumbers.Add(Console.ReadLine());
            }

            subscribers[name] = phoneNumbers;
        }

        return subscribers;
    }

    public static void PrintSubscribers(Dictionary<string, List<string>> subscribers)
    {
        foreach (var entry in subscribers)
        {
            Console.WriteLine($"Абонент: {entry.Key}");
            Console.WriteLine("Номера телефонов: " + string.Join(", ", entry.Value));
        }
    }

    public static void FindSubscriberByPhoneNumber(Dictionary<string, List<string>> subscribers, string phoneNumber)
    {
        foreach (var entry in subscribers)
        {
            if (entry.Value.Contains(phoneNumber))
            {
                Console.WriteLine($"Телефонный номер принадлежит абоненту: {entry.Key}");
                return;
            }
        }
        Console.WriteLine("Абонент с таким номером не найден.");
    }

    public static void FindSubscriberByLastName(Dictionary<string, List<string>> subscribers, string lastName)
    {
        foreach (var entry in subscribers)
        {
            if (entry.Key.Split(' ')[0] == lastName)
            {
                Console.WriteLine($"Абонент: {entry.Key}");
                Console.WriteLine("Номера телефонов: " + string.Join(", ", entry.Value));
            }
        }
    }
}
