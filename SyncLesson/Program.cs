using System;
using System.Collections.Generic;
using System.Threading;

namespace SyncLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new List<Account> {
            new Account
            {
                Name = "Алихан"
            },
            new Account
            {
                Name = "Тамерлан"
            },
            new Account
            {
                Name = "Бекзат"
            },
            };
            Random changeRand = new Random();
            Random ixRand = new Random();
            int changes = changeRand.Next(0, 2);
            int ix = ixRand.Next(0, 3);
            for(int i = 0; i < 1000; i++)
            {
                if (changes == 0)
                {
                    ThreadPool.QueueUserWorkItem(account[ix].ProcessMoney, 100);
                }
                else if(changes == 1)
                {
                    ThreadPool.QueueUserWorkItem(account[ix].ProcessMoney, -100);                    
                }
            }
            Console.ReadLine();
        }
    }
}
