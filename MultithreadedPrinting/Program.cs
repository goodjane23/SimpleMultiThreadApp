using MultithreadedPrinting;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("**** Synchronizing thrad ****");
        Printer p = new();
        Thread[] threads = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            threads[i] = new Thread(new ThreadStart(p.PrintNumbers))
            {
                Name = $"work thread {i}"
            };
        }
        foreach (Thread t in threads)
        {
            t.Start();
        }
        Console.ReadLine();
    }
}