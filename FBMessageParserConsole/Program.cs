using Newtonsoft.Json;
using System;
using System.IO;

namespace FBMessageParserConsole
{
    class Program
    {



        static void Main(string[] args)
        {
            string file = "C:\\Users\\WeebMachine\\source\\repos\\FBMessageParserConsole\\FBMessageParserConsole\\message_1.json";
            RootObject firstPerson = new RootObject();
            Console.WriteLine("Hello World!");
            firstPerson = RootObject.Deserializer(file);
            Console.WriteLine("Hello World!");

        }
    }
}
