using CreateNextYear_Core.Enities;
using CreateNextYear_Core.Infrastructure;
using CreateNextYear_Core.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreateNextYear_Core_Console
{
    class Program
    {
        static void Main(string[] args)
        {
          Setting setting=  GetSetting();
            T31082 createNextYear = new T31082(setting.connectionString,setting.oldYear,setting.newYear);
            createNextYear.logDelegate = ConsoleOut;
            do
            {
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "checkAll":
                        Console.WriteLine("--CheckAll is begin");
                       // List<string> result= 
                            createNextYear.GetLastFlagAll(setting.account, setting.oldYear);
                        break;
                    case "createNewYear":
                        Console.WriteLine("--CreateNewYear is begin");
                       List<UA_Account> accounts=  createNextYear.getAccounts().Where(a => setting.account.Contains(a.cAcc_Id)).ToList();
                        createNextYear.CreateNewYear(accounts);
                        break;
                    case "carryYear":
                        Console.WriteLine("this is carryYear");
                        createNextYear.CarryForwardAll(setting.account);
                        break;
                    case "help":
                        PrintHelp();
                        break;
                    default:
                        break;
                }
            } while (true);
            
            
        }
        private static Setting GetSetting()
        {
            string file = File.ReadAllText("setting.js");
            return JavaScriptConvert.DeserializeObject<Setting>(file);
            //Console.WriteLine(setting.connectionString);
            //Console.WriteLine(setting.version);
            //Console.WriteLine(setting.oldYear);
            //Console.WriteLine(setting.newYear);
            //Console.WriteLine(setting.account);
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Help:");
            Console.WriteLine("...");
        }

        private static  void ConsoleOut(string message)
        {
            Console.WriteLine(message);
        }
    }
}

