﻿namespace Weather.Models
{
    using System;
    using Newtonsoft.Json;

    public class SystemData
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonProperty("sunset")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime Sunset { get; set; }
    }
}