using System;
using System.Threading;

class Program
{
    static AutoResetEvent autoEventA = new AutoResetEvent(true);
    static AutoResetEvent autoEventB = new AutoResetEvent(false);
    static AutoResetEvent autoEventC = new AutoResetEvent(false);

    static void Main()
    {
        Thread threadA = new Thread(PrintA);
        Thread threadB = new Thread(PrintB);
        Thread threadC = new Thread(PrintC);

        threadA.Start();
        threadB.Start();
        threadC.Start();

        threadA.Join();
        threadB.Join();
        threadC.Join();
    }

    static void PrintA()
    {
        for (int i = 0; i < 10; i++)
        {
            autoEventA.WaitOne();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A");
            Console.ResetColor();
            autoEventB.Set();
        }
    }

    static void PrintB()
    {
        for (int i = 0; i < 10; i++)
        {
            autoEventB.WaitOne();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("B");
            Console.ResetColor();
            autoEventC.Set();
        }
    }

    static void PrintC()
    {
        for (int i = 0; i < 10; i++)
        {
            autoEventC.WaitOne();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("C");
            Console.ResetColor();
            autoEventA.Set();
        }
    }
}
