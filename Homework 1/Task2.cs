using System.Diagnostics;

namespace ConsoleApp2;

public class Task2
{
    public void Run()
    {
        string fileName = "notepad.exe";

        try
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.Start();

            Console.WriteLine($"Started {fileName}, PID: {proc.Id}");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Wait for process to exit");
            Console.WriteLine("2 - Force kill the process");
            Console.Write("Your choice: ");

            int input = int.Parse(Console.ReadLine()!);

            if (input == 1)
            {
                Console.WriteLine("Waiting for process to finish...");
                proc.WaitForExit();
                Console.WriteLine($"Process exited with code: {proc.ExitCode}");
            }
            else if (input == 2)
            {
                Console.WriteLine("Will force stop the process in 2 seconds...");
                Thread.Sleep(2000);

                if (!proc.HasExited)
                {
                    proc.Kill();
                    Console.WriteLine("Process was forcefully stopped.");
                }
                else
                {
                    Console.WriteLine("Process already finished by itself.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
