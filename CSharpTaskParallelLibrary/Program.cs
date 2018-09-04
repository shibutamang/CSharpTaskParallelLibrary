using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpTaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //using Task Parallel library
            //Task 1
            var t1 = new Task(() => DoTask(1, 1000));
            t1.Start();

            //Task 2
            var t2 = new Task(() => DoTask(2, 1000));
            t2.Start();

            //using long running task which utilize all the processor core
            Parallel.For(0, 100, x => LongRunningTask());

            Console.ReadKey();
        }

        public static void DoTask(int id, int sleep)
        {
            Console.WriteLine("Task {0} is begining...", id);
            Thread.Sleep(sleep);
            Console.WriteLine("Task {0} is completed", id);
        }

        public static void LongRunningTask()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Iteration Count: {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
