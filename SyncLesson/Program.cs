using System;
using System.Threading;

namespace SyncLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();
            for(int i = 0; i < 100; i++)
            {
                if(i % 2 == 0) 
                    ThreadPool.QueueUserWorkItem(account.ProcessMoney, 100);
                else
                    ThreadPool.QueueUserWorkItem(account.ProcessMoney, -100);
                Thread.Sleep(5);
            }
            Console.ReadLine();
        }
    }
}
