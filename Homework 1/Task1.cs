using System.Diagnostics;

namespace ConsoleApp2;

public class Task_1
{
    public void Run()
    {
        try
        {
            string exeName = "notepad.exe";
            
            Process process = new Process();
            process.StartInfo.FileName = exeName;

            process.Start();
            Console.WriteLine($"Процесс {exeName} запущен. Ожидание завершения...");

            process.WaitForExit();

            bool exitCode = process.HasExited;
            
            if (exitCode)
            {
                Console.WriteLine("Процесс завершен");
            }
            
            else
            {
                Console.WriteLine("Процесс продолжает работать...");
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при запуске процесса: {ex.Message}");
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}