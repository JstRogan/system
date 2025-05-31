namespace ConsoleApp2;
using System;
using System.Diagnostics;

class Task3
{
    public void Run(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Write("First number: ");
            string input1 = Console.ReadLine();

            Console.Write("Second number: ");
            string input2 = Console.ReadLine();

            Console.Write("Operation (+, -, *, /): ");
            string op = Console.ReadLine();

            var info = new ProcessStartInfo
            {
                FileName = Process.GetCurrentProcess().MainModule.FileName,
                Arguments = $"{input1} {input2} {op}",
                UseShellExecute = false
            };

            Process.Start(info);
        }
        else
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Expected 3 arguments: num1 num2 operation");
                return;
            }

            if (!int.TryParse(args[0], out int x) || !int.TryParse(args[1], out int y))
            {
                Console.WriteLine("Error: arguments must be numbers.");
                return;
            }

            string op = args[2];
            int res = 0;
            bool ok = true;

            switch (op)
            {
                case "+": res = x + y; break;
                case "-": res = x - y; break;
                case "*": res = x * y; break;
                case "/":
                    if (y == 0)
                    {
                        Console.WriteLine("Error: division by zero.");
                        ok = false;
                    }
                    else
                    {
                        res = x / y;
                    }
                    break;
                default:
                    Console.WriteLine("Unknown operation.");
                    ok = false;
                    break;
            }

            if (ok)
            {
                Console.WriteLine($"{x} {op} {y} = {res}");
            }
        }
    }
}
