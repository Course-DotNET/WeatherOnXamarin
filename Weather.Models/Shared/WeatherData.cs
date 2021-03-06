﻿namespace Weather.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public abstract class WeatherData
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime CalculationTime { get; set; }
        
        [JsonProperty("weather")]
        public List<Weather> WeatherList { get; set; }

    }
}