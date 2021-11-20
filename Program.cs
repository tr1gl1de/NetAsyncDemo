using System;
using System.Threading;
using System.Threading.Tasks;

namespace asyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // int x1 = await SomeClass.FactorialAsync(-1);
            // Console.WriteLine($"x1! = {x1}");

            SomeClass.PrintFactorialAsyncParralel(-3, 2, -20);

            Console.Read();
        }
    }
}
