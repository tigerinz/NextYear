using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateNextYear_Core_Console
{
    public delegate void LogOutDelegate(string message);
   public  class Log
    {
        public LogOutDelegate logOutDelegate;
        public void Logout(string message)
        {
            logOutDelegate(message);
        }

        public void ConsoleLogOut(string message)
        {
            Console.WriteLine(message);
        }
        public void ConsoleLogOut2(string message)
        {
            Console.WriteLine("==============================");
            Console.WriteLine(message);
        }
    }
}
