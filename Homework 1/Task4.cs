namespace ConsoleApp2;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

class Task4
{
    public void Run(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Write("File path: ");
            string path = Console.ReadLine();

            Console.Write("Word to search: ");
            string word = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var info = new ProcessStartInfo
            {
                FileName = Process.GetCurrentProcess().MainModule.FileName,
                Arguments = $"\"{path}\" {word}",
                UseShellExecute = false
            };

            Process.Start(info);
        }
        else
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Need 2 args: file_path and word.");
                return;
            }

            string path = args[0];
            string word = args[1];

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string text = File.ReadAllText(path);
            int found = Regex.Matches(text, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase).Count;

            Console.WriteLine($"Word \"{word}\" found {found} times.");
        }
    }
}
