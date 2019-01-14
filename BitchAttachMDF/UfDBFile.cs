using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitchAttachMDF
{
    class UfDBFile
    {
        public bool isChoosed { get; set; }
        public string DBFileName { get; set; }
        public string fullDBFileName { get; set; }

        public DirectoryInfo DBFileDir { get; set; }
        public string DBDirName { get; set; }

    }
}
