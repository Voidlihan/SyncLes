using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Threading;

namespace SyncLesson
{
    public class Account : ContextBoundObject
    {
        private object syncObject = new object();
        public int Sum { get; set; } = 1000;
        public void ProcessMoney(object sum)
        {
            lock (syncObject)
            {
                Sum += (int)sum;
                Console.WriteLine(Sum);
            }
        }
    }
}
