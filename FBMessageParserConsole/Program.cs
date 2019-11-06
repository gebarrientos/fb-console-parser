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
            //string file = "C:\\Users\\WeebMachine\\source\\repos\\FBMessageParserConsole\\FBMessageParserConsole\\message_1.json"; //USED FOR TESTING
            DirectoryInfo[] dirs = directory.GetDirectories();
            string[] directoryList = new string[dirs.Length];
            for (int i = 0; i < dirs.Length; i++)
            {
                directoryList[i] = dirs[i].Name;
            }
            int inboxCount = 0;
            //string currentName = ""; Maybe use for a less memory-intensive implementation that doesn't make a directoryList
            foreach (string name in directoryList)
            {
                Console.WriteLine("{0} - {1}", inboxCount, name.Substring(0, name.IndexOf('_')));
                inboxCount++;
            }
            Console.WriteLine("Enter the number of the message list you would like to view.");
            string nameInput = Console.ReadLine();
            string file = dirs[Convert.ToInt32(nameInput)].FullName + "\\message_1.json";
            Messenger firstPerson = new Messenger();
            //Console.WriteLine("{0}", );
            firstPerson = Messenger.Deserializer(file);
            Console.WriteLine("Message 1:" + firstPerson.messages[2].content);
            

        }
    }
}
