using System;
using System.Threading;

namespace OutVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            //This creates a thread and runs the 'Starting' method
            Thread threadOne = new Thread(() =>
            {
                Starting();
            });
            threadOne.Start();
        }
        ///<summary>
        ///This method will create a thread and run the 'PassOutParameter' method on different thread.
        ///</summary>
        public static void Starting()
        {
            int value = 12;
            Console.WriteLine("Before Passing Variable : " + value);
            Thread threadSecond = new Thread(() =>
            {
                PassOutParameter(out value);
            });
            threadSecond.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Before function completes execution : " + value);
        }
        ///<summary>
        ///This method has a parameter declared as 'out' and we change that value of that parameter and pause the thread
        ///for 1.5sec.
        ///</summary>
        public static void PassOutParameter(out int argument)
        {
            argument = 89;
            Thread.Sleep(1500);
            Console.WriteLine("Function execution completed");
        }
    }
}