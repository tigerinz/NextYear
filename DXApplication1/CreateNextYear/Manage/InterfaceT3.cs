using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateNextYear.Manage
{
   public interface InterfaceT3
    {
        List<UA_Account> getAccounts();
        List<UA_Account_sub> getAccount_Subs();
        List<Account> GetAccountsAndSub();

        bool CreateNewYear(Account acc, string newYear, string oldYear);
        List<int> GetLastFlagAll(string accNo,string checkYear);
        int GetLastFlag_GL(string accNo, string checkYear);
        int GetLastFlag_WA(string accNo, string checkYear);
        int GetLastFlag_FA(string accNo, string checkYear);
        bool CarryForwardGL(Account acc, string oldYear,string newYear);
        bool CarryForwardWA(Account acc, string oldYear, string newYear);
        bool CarryForwardFA(Account acc, string oldYear, string newYear);
        bool CarryForwardAll(Account acc, string oldYear,string newYear);
        bool IsSubSysUsed(Account acc, string oldYear, string subSysName);

    }
}
