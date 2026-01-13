using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть текст:");
        string text = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Нічого не введено.");
            return;
        }

        
        string pattern = @"(?<=\()\d+(?=\))|(?<=\[)\d+(?=\])";
        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Знайдені числа в дужках:");

        if (matches.Count == 0)
        {
            Console.WriteLine("Немає збігів.");
        }
        else
        {
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value); 
            }
        }

        Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}
