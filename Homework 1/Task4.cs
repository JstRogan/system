namespace ConsoleApp2;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

class Task4
{
    public void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();

            Console.Write("Введите слово для поиска: ");
            string searchWord = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
            
            var startInfo = new ProcessStartInfo
            {
                FileName = Process.GetCurrentProcess().MainModule.FileName,
                Arguments = $"\"{filePath}\" {searchWord}",
                UseShellExecute = false
            };

            Process.Start(startInfo);
        }
        else
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Ожидается 2 аргумента: путь_к_файлу и слово.");
                return;
            }

            string filePath = args[0];
            string word = args[1];

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            string content = File.ReadAllText(filePath);
            int count = Regex.Matches(content, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase).Count;

            Console.WriteLine($"Слово \"{word}\" встречается {count} раз(а) в файле.");
        }
    }
}