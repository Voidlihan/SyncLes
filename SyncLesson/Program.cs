using System;
using System.Collections.Generic;
using System.Threading;

namespace SyncLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> account = new List<Account> {
            new Account
            {
                Name = "Алихан"
            },
            new Account
            {
                Name = "Бекзат"
            },
            new Account
            {
                Name = "Наиль"
            },
            new Account
            {
                Name = "Борис"
            }
            };
            Random rnd = new Random();
            int vybor = rnd.Next(0, 2);
            int index = rnd.Next(0, 4);
            for(int i = 0; i < 1000; i++)
            {
                if (vybor == 0)
                {
                    lock (account)
                    {
                        ThreadPool.QueueUserWorkItem(account[index], 100);
                    }
                }
                else if(vybor == 1)
                {
                    lock (account)
                    {
                        ThreadPool.QueueUserWorkItem(account[index], -100);
                    }
                }
                Thread.Sleep(5);
            }

            Console.ReadLine();
        }
    }
}
