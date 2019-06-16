using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1606_
{
    class Program
    {

        //static ManualResetEvent gate = new ManualResetEvent(false);
        static AutoResetEvent gate = new AutoResetEvent(false);

        private static void DrawAdv()
        {
            gate.WaitOne();
            Console.WriteLine("Drawing ad.......");
        }

        private static void ShowAllFlights()
        {
            gate.WaitOne(1000);
            Console.WriteLine("Showing all flights.......");
        }

        private static void DrawClocks()
        {
            gate.WaitOne();
            Console.WriteLine("Drawing clock.......");
        }

        private static void ShowCredentials()
        {
            gate.WaitOne();
            Console.WriteLine("Please enter user-name password:");
        }

        /// <summary>
        /// This must occur before all other methods
        /// </summary>
        private static void LoadPage()
        {
            Thread.Sleep(new Random().Next(15000 + 5000));
            Console.WriteLine("Page finished loading............");

            gate.Set(); // make the gate go up -- allow entrance

        }

        static void Main(string[] args)
        {
            new Thread(ShowAllFlights).Start();
            //Thread.Sleep(new Random().Next(10));
            new Thread(ShowCredentials).Start();
            //Thread.Sleep(new Random().Next(30));
            new Thread(LoadPage).Start();
            //Thread.Sleep(new Random().Next(20));
            new Thread(DrawClocks).Start();
            //Thread.Sleep(new Random().Next(10));
            new Thread(DrawAdv).Start();
        }
    }
}
