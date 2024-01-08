using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMultiThreadApp;
public class Printer
{
    public void PrintNumbers()
    {
        Console.WriteLine($"-> {Thread.CurrentThread.Name}");
        Console.WriteLine("Your nums:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i},");
            Thread.Sleep(2000);
        }
        Console.WriteLine();
    }
}
