﻿using CreateNextYear_Core.Enities;
using CreateNextYear_Core.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace CreateNextYear_Core_Console
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
          Setting setting=  GetSetting();
            T31082 t31082 = new T31082(setting);
            
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
                        case "createSingleNewYear":
                            Console.WriteLine("input acccode,oldYear,newYear:001");
                            string createAccoutInfo = Console.ReadLine();
                            Console.WriteLine("--CreateNewYear is begin");
                            UA_Account createAccout = t31082.GetAccounts().FirstOrDefault(a => a.cAcc_Id == createAccoutInfo);
                            t31082.CreateSingleAccountNewYear(createAccout);
                            Console.WriteLine("createNewYear over");
                            break;
                        case "createNewYear":
                            Console.WriteLine("--CreateNewYear is begin");
                            List<UA_Account> accounts = t31082.GetAccounts().Where(a => setting.account.Contains(a.cAcc_Id)).ToList();
                            t31082.CreateManyAccountsNewYear(accounts);
                            Console.WriteLine("createNewYear over");
                            break;
                        case "carryForwardSingle":
                            Console.WriteLine("input acccode,oldYear,newYear:001");
                            string carryForwardAccountInfo = Console.ReadLine();
                            Console.WriteLine("input module GL,FA,WA");
                            string[] modules = Console.ReadLine().Split(',');
                            Console.WriteLine("--carryYear is begin");
                            UA_Account carryForwardAccount = t31082.GetAccounts().FirstOrDefault(a => a.cAcc_Id == carryForwardAccountInfo);
                            t31082.CarryForwardSingleAccountManyModules(carryForwardAccount, modules);
                            Console.WriteLine("carryYear over");
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
            Console.WriteLine("createSingleNewYear");
            Console.WriteLine("createNewYear");
            Console.WriteLine("carryForwardSingle");
            Console.WriteLine("carryForwardAll");
            Console.WriteLine("");
        }

    }
}

