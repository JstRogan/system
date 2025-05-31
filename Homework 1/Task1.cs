using System.Diagnostics;

namespace ConsoleApp2;

public class Task1
{
    public void Run()
    {
        try
        {
            string fileName = "notepad.exe";
            Process p = new Process();
            p.StartInfo.FileName = fileName;

            p.Start();
            Console.WriteLine($"Started process: {fileName}");

            p.WaitForExit();

            if (p.HasExited)
            {
                Console.WriteLine("Process finished.");
            }
            else
            {
                Console.WriteLine("Process is still running.");
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
