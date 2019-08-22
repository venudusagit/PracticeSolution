using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsPractice
{
    class BackgroundAndParameteredThread
    {
        /*Thread without Parameters*/
        private static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }

        public void ExecuteThread()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            //t.IsBackground = true;
            t.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread: Do something");
                Thread.Sleep(1000);
            }

            t.Join();
        }


        /*Thread with Parameters*/
        private static void ParameterizedThreadMethod(object a)
        {
            for (int i = 0; i < (int)a; i++)
            {
                Console.WriteLine("ParameterizedThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }

        public void ExecuteParameterizedThread(object p)
        {
            Thread t = new Thread(new ParameterizedThreadStart(ParameterizedThreadMethod));
            //t.IsBackground = true;
            t.Start(p);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread: Do something");
                Thread.Sleep(1000);
            }

            t.Join();
        }
    }
}
