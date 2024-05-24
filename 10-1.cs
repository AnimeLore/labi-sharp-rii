using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class StringTasks
{
    public static int CountSpecificCharacters(string input, char[] characters)
    {
        int count = 0;
        foreach (char c in input)
        {
            if (Array.Exists(characters, element => element == c))
            {
                count++;
            }
        }
        return count;
    }

    public static string GetEvenPositionCharacters(string input)
    {
        string result = "";
        for (int i = 1; i < input.Length; i += 2)
        {
            result += input[i];
        }
        return result;
    }

    public static bool StartsAndEndsWithSameLetter(string first, string second)
    {
        if (first.Length == 0 || second.Length == 0)
            return false;
        return char.ToLower(first[0]) == char.ToLower(second[second.Length - 1]);
    }

    public static bool IsPalindrome(string word)
    {
        int length = word.Length;
        for (int i = 0; i < length / 2; i++)
        {
            if (char.ToLower(word[i]) != char.ToLower(word[length - i - 1]))
                return false;
        }
        return true;
    }

    public static List<string> GetPermutations(string word)
    {
        if (word.Length != 3)
            throw new ArgumentException("Слово должно состоять из трех букв.");
        
        List<string> permutations = new List<string>();
        char[] arr = word.ToCharArray();
        permutations.Add(new string(arr));
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i != j)
                {
                    Swap(ref arr[i], ref arr[j]);
                    permutations.Add(new string(arr));
                    Swap(ref arr[i], ref arr[j]);
                }
            }
        }
        
        return permutations;
    }

    private static void Swap(ref char a, ref char b)
    {
        char temp = a;
        a = b;
        b = temp;
    }

    public static string RemoveWordsEndingWith(string input, string ending)
    {
        string pattern = @"\b\w*" + Regex.Escape(ending) + @"\b";
        return Regex.Replace(input, pattern, "").Trim();
    }

    public static string RemoveWordsEndingWithCOrSya(string input)
    {
        string pattern = @"\b\w*с\b|\b\w*ся\b";
        return Regex.Replace(input, pattern, "").Trim();
    }

    public static string AddDigitCountToWords(string input)
    {
        string[] words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            int digitCount = 0;
            foreach (char c in words[i])
            {
                if (char.IsDigit(c))
                {
                    digitCount++;
                }
            }
            words[i] += $"${digitCount}";
        }
        return string.Join(" ", words);
    }

    public static string RemoveDigitsAndAddDollar(string input)
    {
        string[] words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string wordWithoutDigits = "";
            foreach (char c in words[i])
            {
                if (!char.IsDigit(c))
                {
                    wordWithoutDigits += c;
                }
            }
            words[i] = wordWithoutDigits + "$";
        }
        return string.Join(" ", words);
    }

    public static string FormatFIO(string input)
    {
        string[] parts = input.Split(' ');
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].Length > 0)
            {
                parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower();
            }
        }
        return string.Join(" ", parts);
    }

    static void Main()
    {
        // Задача 1
        Console.Write("Введите строку для подсчета символов '.', '!' и '-': ");
        string input1 = Console.ReadLine();
        char[] charactersToCount = { '.', '!', '-' };
        int count = CountSpecificCharacters(input1, charactersToCount);
        Console.WriteLine($"Количество символов '.', '!' и '-': {count}");

        // Задача 2
        Console.Write("Введите строку для вывода символов на четных местах: ");
        string input2 = Console.ReadLine();
        string evenChars = GetEvenPositionCharacters(input2);
        Console.WriteLine($"Символы на четных местах: {evenChars}");

        // Задача 3
        Console.Write("Введите первое слово: ");
        string firstWord = Console.ReadLine();
        Console.Write("Введите второе слово: ");
        string secondWord = Console.ReadLine();
        bool result = StartsAndEndsWithSameLetter(firstWord, secondWord);
        Console.WriteLine($"Первое слово начинается с той же буквы, на которую заканчивается второе слово: {result}");

        // Задача 4
        Console.Write("Введите слово для проверки палиндрома: ");
        string word = Console.ReadLine();
        bool isPalindrome = IsPalindrome(word);
        Console.WriteLine($"Слово является палиндромом: {isPalindrome}");

        // Задача 5
        Console.Write("Введите слово из трех букв для перестановок: ");
        string wordForPermutations = Console.ReadLine();
        List<string> permutations = GetPermutations(wordForPermutations);
        Console.WriteLine("Все возможные перестановки букв:");
        foreach (string perm in permutations)
        {
            Console.WriteLine(perm);
        }

        // Задача 6
        Console.Write("Введите строку для удаления слов, заканчивающихся на 'сь': ");
        string input3 = Console.ReadLine();
        string result3 = RemoveWordsEndingWith(input3, "сь");
        Console.WriteLine($"Строка без слов, заканчивающихся на 'сь': {result3}");

        // Задача 7
        Console.Write("Введите строку для удаления слов, заканчивающихся на 'с' или 'ся': ");
        string input4 = Console.ReadLine();
        string result4 = RemoveWordsEndingWithCOrSya(input4);
        Console.WriteLine($"Строка без слов, заканчивающихся на 'с' или 'ся': {result4}");

        // Задача 8
        Console.Write("Введите строку для подсчета цифр в словах: ");
        string input5 = Console.ReadLine();
        string result5 = AddDigitCountToWords(input5);
        Console.WriteLine($"Строка с количеством цифр в каждом слове: {result5}");

        // Задача 9
        Console.Write("Введите строку для удаления цифр и добавления '$' к словам: ");
        string input6 = Console.ReadLine();
        string result6 = RemoveDigitsAndAddDollar(input6);
        Console.WriteLine($"Строка после обработки: {result6}");

        // Задача 10
        Console.Write("Введите строку для преобразования ФИО: ");
        string input7 = Console.ReadLine();
        string formattedFIO = FormatFIO(input7);
        Console.WriteLine($"Преобразованное ФИО: {formattedFIO}");
    }
}
