namespace ConsoleApp2;
using System;
using System.Diagnostics;

class Task3
{
    public void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Write("Введите первое число: ");
            string num1 = Console.ReadLine();

            Console.Write("Введите второе число: ");
            string num2 = Console.ReadLine();

            Console.Write("Введите операцию (+, -, *, /): ");
            string operation = Console.ReadLine();

            var startInfo = new ProcessStartInfo
            {
                FileName = Process.GetCurrentProcess().MainModule.FileName,
                Arguments = $"{num1} {num2} {operation}",
                UseShellExecute = false
            };

            Process.Start(startInfo);
        }
        else
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Ожидается 3 аргумента: число1 число2 операция");
                return;
            }

            if (!int.TryParse(args[0], out int a) || !int.TryParse(args[1], out int b))
            {
                Console.WriteLine("Ошибка: аргументы должны быть числами.");
                return;
            }

            string op = args[2];
            int result = 0;
            bool valid = true;

            switch (op)
            {
                case "+": result = a + b; break;
                case "-": result = a - b; break;
                case "*": result = a * b; break;
                case "/":
                    if (b == 0)
                    {
                        Console.WriteLine("Ошибка: деление на ноль.");
                        valid = false;
                    }
                    else
                    {
                        result = a / b;
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестная операция.");
                    valid = false;
                    break;
            }

            if (valid)
            {
                Console.WriteLine($"Аргументы: {a} {op} {b}");
                Console.WriteLine($"Результат: {result}");
            }
        }
    }
}
