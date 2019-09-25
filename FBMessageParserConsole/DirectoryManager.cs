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
            DirectoryInfo di = new DirectoryInfo(@"E:\Users\Kankariko\Documents\GitHub\fb-console-parser\FBMessageParserConsole\inbox");
            return di;
        }
    }
}
