using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = new Task<int>(() => {
                Thread.Sleep(1000);
                Console.WriteLine("Hello from Task world!");
                return 5;
            }, TaskCreationOptions.LongRunning);
            //t.Start();
            //t.Wait();
            t.RunSynchronously(); // same as Start + Wait
            Console.WriteLine($"result is {t.Result}");

            Task t1 = new Task(() => {
                Thread.Sleep(new Random().Next(2000));
                Console.WriteLine($"Hello from Task world! from task {Thread.CurrentThread.ManagedThreadId }");
            }, TaskCreationOptions.LongRunning);
            Task t2 = new Task(() => {
                Thread.Sleep(new Random().Next(1000));
                Console.WriteLine($"Hello from Task world! from task {Thread.CurrentThread.ManagedThreadId }");
            }, TaskCreationOptions.LongRunning);
            
            t1.Start();
            t2.Start();

            //Task.WaitAll(new [] {  t1,  t2 } );
            Task.WaitAny(new [] {  t1 , t2 } );

            Console.WriteLine("After");
        }
    }
}
