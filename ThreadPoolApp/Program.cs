using SimpleMultiThreadApp;
/// <summary>
/// Nums will be printed in queue in this case
/// </summary>
public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("*** ***");
        Console.WriteLine($"main thread started. ThreadID is {Thread.CurrentThread.ManagedThreadId}");

        Printer printer = new();
        WaitCallback waitCallback = new WaitCallback(PrintTheNumbers);
        for (int i = 0; i < 10; i++)
        {
            ThreadPool.QueueUserWorkItem(waitCallback, printer);
        }

        Console.WriteLine("All task queued");
        Console.ReadLine();
    }
    static void PrintTheNumbers(object state)
    {
        Printer task = (Printer) state; 
        task.PrintNumbers();
    }
}