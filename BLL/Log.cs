using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateNextYear
{
    class Log
    {
        string setStr(string methodName, string str)
        {
            string line = "********************* {0} *****************";

            return string.Format(line, "Begin " + methodName)
                + Environment.NewLine
                + str
                + Environment.NewLine
                + string.Format(line, "End " + methodName)
                + Environment.NewLine;
        }
        public Log setLogPart(StringBuilder sb, string methodName, string str)
        {

            sb.Append(setStr(methodName, str));
            return this;
        }
    }
}
