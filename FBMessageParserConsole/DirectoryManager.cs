using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FBMessageParserConsole
{
    class DirectoryManager
    {
        public static DirectoryInfo DirectoryInitialize()
        {
            DirectoryInfo di = new DirectoryInfo(@"E:\Users\Kankariko\Documents\GitHub\inbox"); //initialize this to the inbox folder for now
            return di;
        }
    }
}
