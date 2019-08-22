using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsPractice
{
    class ThreadsUsingStaticAttributesAndThreadLocalClass
    {
        //By using this attribute, a new instance of the variable is created for each thread
        //Commenting this will cause all the threads to use same variable
        [ThreadStatic] 
        private static int _threadStaticField;
        public void ExecuteThreadsUsingStaticAttributes()
        {
            Thread threadA = new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _threadStaticField++;
                    Console.WriteLine("Thread A: {0}", _threadStaticField);
                    Thread.Sleep(1000);
                }
            });

            Thread threadB = new Thread(() =>
            {
                for (int y = 0; y < 10; y++)
                {
                    _threadStaticField++;
                    Console.WriteLine("Thread B: {0}", _threadStaticField);
                    Thread.Sleep(1000);
                }
            });

            threadA.Start();
            threadB.Start();
            Console.ReadKey();
        }


        private static ThreadLocal<int> _threadLocalField =
            new ThreadLocal<int>(() =>
        {
            return Thread.CurrentThread.ManagedThreadId;
        });


        public void ExecuteThreadsUsingThreadLocal()
        {
            Thread threadA = new Thread(() =>
            {
                for (int x = 0; x < _threadLocalField.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                    Thread.Sleep(1000);
                }
            });

            Thread threadB = new Thread(() =>
            {
                for (int y = 0; y < _threadLocalField.Value; y++)
                {
                    Console.WriteLine("Thread B: {0}", y);
                    Thread.Sleep(1000);
                }
            });

            threadA.Start();
            threadB.Start();
            Console.ReadKey();
        }
    }
}
