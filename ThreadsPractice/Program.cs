using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            //BackgroundAndParameteredThread BAPThread = new BackgroundAndParameteredThread();
            //BAPThread.ExecuteThread();
            //BAPThread.ExecuteParameterizedThread(5);

            //Task 2
            //ThreadsUsingStaticAttributesAndThreadLocalClass tsa = new ThreadsUsingStaticAttributesAndThreadLocalClass();
            //tsa.ExecuteThreadsUsingStaticAttributes();
            //tsa.ExecuteThreadsUsingThreadLocal();

            //Task 3
            //TaskExample te = new TaskExample();
            //te.RunTask();
            //te.RunTaskWithResult("VENUGOPAL");

            SQLToExcel ste = new SQLToExcel();
            ste.ReadExistingExcel();
        }
    }
}
