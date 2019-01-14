using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateNextYear
{
    public static class MyAppContext
    {
        /// <summary>
        /// backgroundWoker reportProgress
        /// opertDetail result value
        /// </summary>
        public enum operateResult
        {
            等待 = 0,
            运行中 = 1,
            成功 = 2,
            错误 = 3

        }
        /// <summary>
        /// type of operate do and show
        /// </summary>
        public enum opertateType
        {
              CreateNewYear,
              CheckAll,
              CheckGL,
              CheckWA,
              CheckFA,
              CarryForwardGL,
              CarryForwardWA,
              CarryForwardFA,
              CarryForwardAll
        }
        public static List<string> accNo;
        public static string newYear;
        public static string[] excludeAccount;
        public static string[] includeAccount;
    }
}
