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
       List<UA_Account_sub> GetAccount_Subs();
        List<UA_Account> GetAccounts();
        List<string> GetManyAccountManyModuleLastFlag(List<string> accCodes, string checkYear, string[] Modules);
        Dictionary<string, int> GetSingleAccountManyModuleLastFlag(string account, string checkYear, string[] Module);
        int GetSingleModuleLastFlag(string accountCode, string checkYear, string Module);

       bool IsSubSysUsed(string accCode, string subSysName);
        
    }
}
