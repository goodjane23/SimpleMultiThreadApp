using AddWithThreadsParam;
/// <summary>
/// Nums will be printed in queue in this case
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        AutoResetEvent _waitHandle = new AutoResetEvent(false);

        Console.WriteLine($"Id of current thread in add: " +
                $"{Thread.CurrentThread.ManagedThreadId}");
        AddParams ap = new(10, 10);
        Thread t = new Thread(new ParameterizedThreadStart(Add));
        t.Start(ap);

        _waitHandle.WaitOne();

        Console.ReadLine();  
    }

    static void Add(object data)
    {
        if (data is AddParams ap)
        {
            Console.WriteLine($"Id of current thread in add: " +
                $"{Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"{ap.a} + {ap.b} = {ap.a + ap.b}");

        }
    }
}