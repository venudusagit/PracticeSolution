using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsPractice
{
    class TaskExample
    {
        public void RunTask()
        {
            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine(i + " * " + i + " = " + i*i);
                }
            });

            t.Wait();
            //Console.ReadKey();
        }

        public void RunTaskWithResult(string name)
        {
            Task<string> t = Task.Run(() =>
            {
                return "Hello " + name;
            });

            Console.WriteLine(t.Result);
        }
    }
}
