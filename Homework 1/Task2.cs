using System.Diagnostics;

namespace ConsoleApp2;

public class Task_2
{
    public void Run()
    {
        string exeName = "notepad.exe";

        try 
        { 
            Process process = new Process(); 
            process.StartInfo.FileName = exeName;
            
            process.Start(); 
            Console.WriteLine($"Процесс {exeName} запущен с ID: {process.Id}");
            
            Console.WriteLine("Выберите действие:"); 
            Console.WriteLine("1 - Ожидать завершения процесса"); 
            Console.WriteLine("2 - Принудительно завершить процесс"); 
            Console.Write("Ваш выбор: ");
            
            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 1) 
            { 
                Console.WriteLine("Ожидание завершения процесса..."); 
                process.WaitForExit(); 
                Console.WriteLine($"Процесс завершен. Код выхода: {process.ExitCode}");
            }
            
            else if (choice == 2) 
            { 
                Console.WriteLine("Процесс будет завершён принудительно через 2 секунды..."); 
                Thread.Sleep(2000);
                if (!process.HasExited) 
                { 
                    process.Kill();
                    Console.WriteLine("Процесс принудительно завершён.");
                }
                else 
                { 
                    Console.WriteLine("Процесс уже завершён самостоятельно.");
                }
            }
            else 
            { 
                Console.WriteLine("Неверный выбор.");
            }
        }
        catch (Exception ex) 
        { 
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        
        Console.WriteLine("Нажмите любую клавишу для выхода..."); 
        Console.ReadKey();
    }
}