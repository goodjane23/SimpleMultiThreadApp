
internal class Program
{
    static CancellationTokenSource _cts = new();
    private static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("Press any key to start processing!");

            Console.ReadKey();
            Console.WriteLine("Processing");
            Task.Factory.StartNew(ProcessIntData);
            Console.WriteLine("Enter Q for exit");
            var answer = Console.ReadLine();

            if (answer.Equals("q",StringComparison.OrdinalIgnoreCase))
            {
                _cts.Cancel();
                break;
            }
        }
        while (true);

        Console.ReadLine();
    }

    private static void ProcessIntData()
    {
        int[] source = Enumerable.Range(1,1000000000).ToArray();
        int[] modThreeIsZero = null;
        try
        {
            modThreeIsZero = (
            from num in source.AsParallel()
            .WithCancellation(_cts.Token)
            where num % 4 == 0
            orderby num descending
            select num).ToArray();
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Console.WriteLine($"Found {modThreeIsZero.Count()} numbers that match query!");
    }
}