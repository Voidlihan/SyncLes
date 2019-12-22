using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Threading;
using System.Runtime.CompilerServices;

namespace SyncLesson
{
    public class Account : ContextBoundObject
    {
        private object obj = new object();
        public string Name { get; set; }
        public int Sum { get; set; } = 1000;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ProcessMoney(object sum)
        {
            lock (obj)
            {
                Random rand = new Random();
                rand.Next(0, Sum);
                Sum += (int)sum;
                if (Sum == 0)
                {
                    Console.WriteLine("Счет достиг 0");
                }
                else
                {
                    Console.WriteLine($"На {Name} было пополнено или снято {(int)sum > 0} {sum}, счет: {Sum}");
                }
            }
        }
    }
}
