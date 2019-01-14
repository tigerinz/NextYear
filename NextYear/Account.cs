using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextYear
{
    class Account
    {
        public string AccountId{ get; set; }
        public string Year { get; set; }
        public List<string> Subs { get; set; }

        public string GetAccountDB()
        {
            return "UFDATA_" + AccountId + "_" + Year;
        }
    }
}
