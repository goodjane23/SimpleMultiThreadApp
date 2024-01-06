using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedPrinting;
public class Printer
{
    private object _lock = new object();
    public void PrintNumbers()
    {
        lock (_lock)
        {
            Console.WriteLine($"-> {Thread.CurrentThread.Name}");
            Console.WriteLine("Your nums:");
            for (int i = 0; i < 10; i++)
            {
                Random r = new();
                Thread.Sleep(1000 * r.Next(5));
                Console.Write($"{i} ,");

            }
            Console.WriteLine();
        }
    }
}
