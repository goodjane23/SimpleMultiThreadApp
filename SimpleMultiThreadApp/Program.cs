using SimpleMultiThreadApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("**** Amazing Thread app ****");
        Console.WriteLine("Do you wanna [1] or [2] threads?");
        string threadcount = Console.ReadLine();

        Thread primaryThread = Thread.CurrentThread;
        primaryThread.Name = "First";

        Console.WriteLine($"-> {Thread.CurrentThread.Name} is executing Main");

        Printer p = new();

        switch (threadcount)
        {
            case "2":
                var backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                backgroundThread.IsBackground = true;
                backgroundThread.Name = "Secondary";
                backgroundThread.Start();
                break;
            case "1":
                p.PrintNumbers();
                break;
            default:
                Console.WriteLine("Fuckoff");
                break;
        }
        Console.ReadLine();

    }
}