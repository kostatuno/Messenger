namespace PracticeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Foo();
            Thread.Sleep(3000);
            Console.WriteLine("Hello");
            Thread.Sleep(3000);
        }

        async static void Foo()
        {
            Console.WriteLine("Start");
            await Task.Run(() =>
            {
                Print();
            });
            Console.WriteLine("End");
        }

        static void Print()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(i);
            }
        }
    }
}