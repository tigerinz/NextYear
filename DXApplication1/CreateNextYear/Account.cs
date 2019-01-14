using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateNextYear
{
    public class Account : UA_Account
    {
        public int GL { get; set; }
        public int FA { get; set; }
        public int WA { get; set; }
        public int IA { get; set; }
        public int GX { get; set; }
        public System.Drawing.Image image { get; set; }
        public string result { get; set; }
    }
}