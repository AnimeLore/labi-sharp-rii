using System;

class Program
{
    static void Main(string[] args)
    {
        int dayNumber = GetDayNumber();
        string dayName = GetDayName();
        PrintDayInfo(dayNumber, dayName);
    }

    static int GetDayNumber()
    {
        Console.WriteLine("Введите номер дня недели (1 - понедельник, 2 - вторник, ..., 7 - воскресенье):");
        return Convert.ToInt32(Console.ReadLine());
    }

    static string GetDayName()
    {
        Console.WriteLine("Введите название дня недели:");
        return Console.ReadLine().ToLower();
    }

    static void PrintDayInfo1(int dayNumber, string dayName)
    {
        switch (dayNumber)
        {
            case 1:
                switch(dayName)
                {
                    case "понедельник":
                        Console.WriteLine("В этот день {0} пар(ы).", 1);
                        break;
                    case "вторник":
                        Console.WriteLine("В этот день {0} пар(ы).", 3);
                        break;
                    case "среда":
                        Console.WriteLine("В этот день {0} пар(ы).", 4);
                        break;
                    case "четверг":
                        Console.WriteLine("В этот день {0} пар(ы).", 2);
                        break;
                    case "пятница":
                        Console.WriteLine("В этот день {0} пар(ы).", 2);
                        break;
                    case "суббота":
                        Console.WriteLine("Выходной день.");
                        break;
                    case "воскресенье":
                        Console.WriteLine("Выходной день.");
                       break;
                    default:
                        Console.WriteLine("Некорректное название дня недели.");
                        break;
                }
                break;
            case 2:
                switch(dayName)
                {
                    case "понедельник":
                        Console.WriteLine("В этот день {0} пар(ы).", 1);
                        break;
                    case "вторник":
                        Console.WriteLine("В этот день {0} пар(ы).", 4);
                        break;
                    case "среда":
                        Console.WriteLine("В этот день {0} пар(ы).", 3);
                        break;
                    case "четверг":
                        Console.WriteLine("В этот день {0} пар(ы).", 0);
                        break;
                    case "пятница":
                        Console.WriteLine("В этот день {0} пар(ы).", 4);
                        break;
                    case "суббота":
                        Console.WriteLine("Выходной день.");
                        break;
                    case "воскресенье":
                        Console.WriteLine("Выходной день.");
                       break;
                    default:
                        Console.WriteLine("Некорректное название дня недели.");
                        break;
                }
                break;
        }
    }
}
