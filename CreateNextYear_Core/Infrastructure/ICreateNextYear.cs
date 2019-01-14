using CreateNextYear_Core.Enities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateNextYear_Core.Infrastructure
{
    
    public interface ICreateNextYear
    {
       // void logDelegate(string message);
        List<UA_Account> getAccounts();
        List<UA_Account_sub> getAccount_Subs();
        //List<Account> GetAccountsAndSub();
        bool CreateNewYear(UA_Account acc);
        Dictionary<string,int> GetLastFlagAll(string accountCode, string checkYear);
        List<string> GetLastFlagAll(List<string> accountCodes, string checkYear);
        int GetLastFlag_GL(string accountCode, string checkYear);
        int GetLastFlag_WA(string accountCode, string checkYear);
        int GetLastFlag_FA(string accountCode, string checkYear);
        bool CarryForwardGL(string accountCode);
        bool CarryForwardWA(string accountCode);
        bool CarryForwardFA(string accountCode);
        bool CarryForwardAll(string accountCode);
        List<string> CarryForwardAll(List<string> accountCodes);
        bool IsSubSysUsed(string accountCode, string subSysName);

    }
}
