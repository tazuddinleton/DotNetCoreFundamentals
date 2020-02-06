using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.Console
{
    public class MultiThreading
    {   
        public static void Run() 
        {
            Thread t1 = new Thread(() =>
            {
                Thread.Sleep(3000);
                System.Console.WriteLine("First Thread");
            });
            t1.Start();


            
            Task.Run(() => {
                Thread.Sleep(100);
                System.Console.WriteLine("Second Thread");
            });
            

        }
    }
}
