using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть текст:");
        string text = Console.ReadLine();

        string pattern = @"[\(\[]\d+[\)\]]";
        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Знайдені числа в дужках:");

        foreach (Match match in matches)
        {
            string value = match.Value;
            value = value.Replace("(", "");
            value = value.Replace(")", "");
            value = value.Replace("[", "");
            value = value.Replace("]", "");
            Console.WriteLine(value);
        }

        Console.ReadLine();
    }
}
