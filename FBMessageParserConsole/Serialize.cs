namespace FBMessageParserConsole
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Messenger
    {
        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("is_still_participant")]
        public bool IsStillParticipant { get; set; }

        [JsonProperty("thread_type")]
        public string ThreadType { get; set; }

        [JsonProperty("thread_path")]
        public string ThreadPath { get; set; }

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

        //TotalMessageCount: Counts total number of messages sent between all members of a message within the time period..
        public void TotalMessageCount()
        {
            Console.WriteLine("Total messages sent: {0} from {1} to {2}", Messages.Count, UnixTimeStampToDateTime(Messages[Messages.Count - 1].TimestampMs), UnixTimeStampToDateTime(Messages[0].TimestampMs));
        }

        //UnitxTimeStampToDateTime: conversion from Unix Timestamp to DateTime format
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

    }

    public partial class Message
    {
        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("timestamp_ms")]
        public long TimestampMs { get; set; }

        [JsonProperty("photos", NullValueHandling = NullValueHandling.Ignore)]
        public List<AudioFile> Photos { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("sticker", NullValueHandling = NullValueHandling.Ignore)]
        public Sticker Sticker { get; set; }

        [JsonProperty("share", NullValueHandling = NullValueHandling.Ignore)]
        public Share Share { get; set; }

        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public List<AudioFile> Files { get; set; }

        [JsonProperty("gifs", NullValueHandling = NullValueHandling.Ignore)]
        public List<Sticker> Gifs { get; set; }

        [JsonProperty("reactions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Reaction> Reactions { get; set; }

        [JsonProperty("videos", NullValueHandling = NullValueHandling.Ignore)]
        public List<Video> Videos { get; set; }

        [JsonProperty("audio_files", NullValueHandling = NullValueHandling.Ignore)]
        public List<AudioFile> AudioFiles { get; set; }

        [JsonProperty("payment_info", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentInfo PaymentInfo { get; set; }

        [JsonProperty("call_duration", NullValueHandling = NullValueHandling.Ignore)]
        public long? CallDuration { get; set; }

        [JsonProperty("missed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Missed { get; set; }
    }

    public partial class AudioFile
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("creation_timestamp")]
        public long CreationTimestamp { get; set; }
    }

    public partial class Sticker
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public partial class PaymentInfo
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("creationTime")]
        public long CreationTime { get; set; }

        [JsonProperty("completedTime")]
        public long CompletedTime { get; set; }

        [JsonProperty("senderName")]
        public string SenderName { get; set; }

        [JsonProperty("receiverName")]
        public string ReceiverName { get; set; }
    }

    public partial class Reaction
    {
        [JsonProperty("reaction")]
        public string ReactionReaction { get; set; }

        [JsonProperty("actor")]
        public string Actor { get; set; }
    }

    public partial class Share
    {
        [JsonProperty("link")]
        public Uri Link { get; set; }
    }

    public partial class Video
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("creation_timestamp")]
        public long CreationTimestamp { get; set; }

        [JsonProperty("thumbnail")]
        public Sticker Thumbnail { get; set; }
    }

    public partial class Participant
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class PurpleSerialize
    {
        public static PurpleSerialize FromJson(string json) => JsonConvert.DeserializeObject<PurpleSerialize>(json, FBMessageParserConsole.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PurpleSerialize self) => JsonConvert.SerializeObject(self, FBMessageParserConsole.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }



}
