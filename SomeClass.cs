using System;
using System.Threading;
using System.Threading.Tasks;

namespace asyncDemo
{
    public class SomeClass
    {
        static void PrintFactorial(int num)
        {
            int result = Factorial(num);
            Console.WriteLine($"Factorial of {num} = {result}");
        }
        static int Factorial(int num)
        {
            if (num < 1)
            {
                throw new Exception($"{num} : Число не должно быть меньше 1");
            }
            int result = 1;
            for (int i = 1; i < num; i++)
            {
                result *= i;
            }
            return result;
        }
        public static async void PrintFactorialAsync(int num)
        {
            Task task = null;
            try
            {
                task = Task.Run(() => PrintFactorial(num));
                await task;
            }
            catch (Exception error)
            {
                Console.WriteLine(task.Exception.InnerException.Message);
                Console.WriteLine($"IsFaulted: {task.IsFaulted}");
            }

        }
        public static async Task<int> FactorialAsync(int num)
        {
            try
            {
                // Thread.Sleep(5000);  // добавил задержку для дебага
                return await Task.Run(() => Factorial(num));
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public static async void PrintFactorialAsyncLine()
        {
            await Task.Run(() => PrintFactorial(3));
            await Task.Run(() => PrintFactorial(4));
            await Task.Run(() => PrintFactorial(5));
        }
        public static async void PrintFactorialAsyncParralel()
        {
            Task t1 = Task.Run(() => PrintFactorial(3));
            Task t2 = Task.Run(() => PrintFactorial(4));
            Task t3 = Task.Run(() => PrintFactorial(5));
            await Task.WhenAll(new[] { t1, t2, t3 });
        }
        public static async void PrintFactorialAsyncParralel(int n1, int n2, int n3)
        {
            Task allTasks = null;
            try
            {
                Task t1 = Task.Run(() => PrintFactorial(n1));
                Task t2 = Task.Run(() => PrintFactorial(n2));
                Task t3 = Task.Run(() => PrintFactorial(n3));

                allTasks = Task.WhenAll( t1, t2, t3 );
                await allTasks;
            }
            catch (Exception error)
            {
                Console.WriteLine("Exception: "+ error.Message);
                Console.WriteLine("IsFaulted: "+ allTasks.IsFaulted);
                foreach(var inx in allTasks.Exception.InnerExceptions)
                {
                    Console.WriteLine("Inside exception: "+inx.Message);
                }
            }
        }
    }
}