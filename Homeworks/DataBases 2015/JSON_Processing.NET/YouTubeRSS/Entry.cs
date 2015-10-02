namespace YouTubeRSS
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class Entry
    {
        [JsonProperty("link")]
        public Link VideoLink { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
