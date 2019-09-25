using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

/// <summary>
/// The following class structure is designed to contain the JSON fields that are used in Facebook messages; if there
/// are more elegant ways to store the list, please update the code and let me know.
/// </summary>
namespace FBMessageParserConsole    
{
    public class Participant
    {
        public string name { get; set; }
    }

    public class Message
    {
        public string sender_name { get; set; }
        public object timestamp_ms { get; set; }
        public string content { get; set; }
        public string type { get; set; }
    }

    public class Messenger
    {
        public List<Participant> participants { get; set; }
        public List<Message> messages { get; set; }
        public string title { get; set; }
        public bool is_still_participant { get; set; }
        public string thread_type { get; set; }
        public string thread_path { get; set; }

        public static Messenger Deserializer(string file)
        {
            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                Console.WriteLine("Reading JSON File....");
                Messenger convertedMessage = JsonConvert.DeserializeObject<Messenger>(json);
                return convertedMessage;
            }
        }
    }

}

