using CreateNextYear_Core.Enities;
using CreateNextYear_Core.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace CreateNextYear_Core_Console
{
    class Program
    {
        static void Main(string[] args)
        {
          Setting setting=  GetSetting();
            T31082 t31082 = new T31082(setting);
            t31082.logDelegate = ConsoleOut;
            
            do
            {
                string cmd = Console.ReadLine();
                try
                {
                    switch (cmd)
                    {
                        case "checkAll":
                            Console.WriteLine(string.Format("--CheckAll {0} is begin", setting.oldYear));
                            Console.WriteLine("账套号 总账 固定资产 工资");
                            // List<string> result= 
                            t31082.CheckLastFlagManyAccountsManyModules(setting.account, setting.oldYear,new string[]{"GL","FA","WA" });
                            Console.WriteLine("checkAll over");

                            break;
                        case "createNewYear":
                            Console.WriteLine("--CreateNewYear is begin");
                            List<UA_Account> accounts = t31082.GetAccounts().Where(a => setting.account.Contains(a.cAcc_Id)).ToList();
                            t31082.CreateManyAccountsNewYear(accounts);
                            Console.WriteLine("createNewYear over");
                            break;
                        case "carryForwardAll":
                            Console.WriteLine("this is carryYear");
                            accounts = t31082.GetAccounts().Where(a => setting.account.Contains(a.cAcc_Id)).ToList();
                            t31082.CarryForwardManyAccountsManyModules(accounts,new string[] { "GL", "FA", "WA" });
                            Console.WriteLine("carryYear over");
                            break;
                        case "help":
                            PrintHelp();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
                
            } while (true);
            
            
        }
        private static Setting GetSetting()
        {
            string file = File.ReadAllText("setting.js");
            return JsonConvert.DeserializeObject<Setting>(file);
        }

        private static void PrintHelp()
        {
            Console.WriteLine("checkAll");
            Console.WriteLine("createNewYear");
            Console.WriteLine("carryForwardAll");
        }

        private static  void ConsoleOut(string message)
        {
            Console.WriteLine(message);
        }
    }
}

