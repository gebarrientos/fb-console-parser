using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;


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

    public class RootObject
    {
        public List<Participant> participants { get; set; }
        public List<Message> messages { get; set; }
        public string title { get; set; }
        public bool is_still_participant { get; set; }
        public string thread_type { get; set; }
        public string thread_path { get; set; }

        public static RootObject Deserializer(string file)
        {
            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                RootObject convertedMessage = JsonConvert.DeserializeObject<RootObject>(json);
                return convertedMessage;
            }
        }
    }

}

