using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LabWork
{
    class IpAddressFinder
    {
        private string text;
        private List<string> ipAddresses;

        public IpAddressFinder(string text)
        {
            this.text = text;
            ipAddresses = new List<string>();
        }

        public void FindIpAddresses()
        {
            string pattern = @"\b\d{1,3}(\.\d{1,3}){3}\b";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                ipAddresses.Add(match.Value);
            }
        }

        public void PrintIpAddresses()
        {
            if (ipAddresses.Count == 0)
            {
                Console.WriteLine("IP-адреси не знайдені.");
                return;
            }

            Console.WriteLine("Знайдені IP-адреси:");
            for (int i = 0; i < ipAddresses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ipAddresses[i]}");
            }
        }

        public int GetCount()
        {
            return ipAddresses.Count;
        }

        public void Clear()
        {
            ipAddresses.Clear();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введіть текст для пошуку IP-адрес:");
            string inputText = Console.ReadLine();

            IpAddressFinder finder = new IpAddressFinder(inputText);

            finder.FindIpAddresses();
            finder.PrintIpAddresses();

            Console.WriteLine();
            Console.WriteLine("Загальна кількість знайдених IP-адрес: " + finder.GetCount());

            Console.WriteLine();
            Console.WriteLine("Повторний пошук у стандартному тексті:");

            string defaultText =
                "Сервери мають такі адреси: 192.168.1.1, 10.0.0.1. " +
                "DNS Google: 8.8.8.8 та 8.8.4.4. " +
                "Некоректна адреса: 999.999.999.999.";

            finder.Clear();
            finder = new IpAddressFinder(defaultText);

            finder.FindIpAddresses();
            finder.PrintIpAddresses();

            Console.WriteLine();
            Console.WriteLine("Кількість IP-адрес у стандартному тексті: " + finder.GetCount());
        }
    }
}
