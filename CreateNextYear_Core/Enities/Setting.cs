﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateNextYear_Core.Enities
{
    public class Setting
    {
        public string version { get; set; }
        public string connectionString { get; set; }
        public string oldYear { get; set; }
        public string newYear { get; set; }
        public List<string> account { get; set; }
    }
}