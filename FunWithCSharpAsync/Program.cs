
internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Fun with Async");
        MethodWithProblems(10,45);
        Console.ReadLine();
    }

    private static async Task<string> DoWorkAsync()
    {
        return await Task.Run(() =>
        {
            Thread.Sleep(5000);
            return "Done with work!";
        });
    }

    static async Task MultipleAwaits()
    {
        var task1 = Task.Run(() =>
        {
            Thread.Sleep(3000);
            Console.WriteLine("task 1 complete");
        });
        var task2 = Task.Run(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("task 2 complete");
        });
        var task3 = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("task 3 complete");
        });
        await Task.WhenAny(task1, task2, task3);
    }

    static async Task MethodWithProblems(int firstParam, int secondParam)
    {
        Console.WriteLine("Enter");
        if (secondParam < 0)
        {
            Console.WriteLine("baddata");
            return;
        }
        await actualImplementation();
        async Task actualImplementation()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(4000);
                Console.WriteLine("first complete");
                Console.WriteLine("Smt bad happend");
            });
        }
    }
}