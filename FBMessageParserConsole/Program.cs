using Newtonsoft.Json;
using System;
using System.IO;

namespace FBMessageParserConsole
{
    class Program
    {



        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter the inbox folder file path.");
            //string pathInput = Console.ReadLine();
            DirectoryInfo directory = DirectoryManager.DirectoryInitialize();
            string file = "C:\\Users\\WeebMachine\\source\\repos\\FBMessageParserConsole\\FBMessageParserConsole\\message_1.json"; //USED FOR TESTING
            DirectoryInfo[] dirs = directory.GetDirectories();
            string[] directoryList = new string[dirs.Length];
            for (int i = 0; i < dirs.Length; i++)
            {
                directoryList[i] = dirs[i].Name;
            }
            Messenger firstPerson = new Messenger();
            //Console.WriteLine("{0}", );
            firstPerson = Messenger.Deserializer(file);
            

        }
    }
}
