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
            T31082 createNextYear = new T31082(setting.connectionString,setting.oldYear,setting.newYear);
            createNextYear.logDelegate = ConsoleOut;
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
                            createNextYear.GetLastFlagAll(setting.account, setting.oldYear);
                            break;
                        case "createNewYear":
                            Console.WriteLine("--CreateNewYear is begin");
                            List<UA_Account> accounts = createNextYear.getAccounts().Where(a => setting.account.Contains(a.cAcc_Id)).ToList();
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
            //Console.WriteLine(file.connectionString);
            //Console.WriteLine(file.version);
            //Console.WriteLine(file.oldYear);
            //Console.WriteLine(file.newYear);
            //Console.WriteLine(file.account);
            return JsonConvert.DeserializeObject<Setting>(file);
          //  return JavaScriptConvert.DeserializeObject<Setting>(file);
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Help:");
            Console.WriteLine("checkAll");
            Console.WriteLine("createNewYear"); 
            Console.WriteLine("carryYear"); 
        }

        private static  void ConsoleOut(string message)
        {
            Console.WriteLine(message);
        }
    }
}

