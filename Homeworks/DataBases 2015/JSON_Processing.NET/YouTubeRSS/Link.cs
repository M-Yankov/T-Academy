namespace YouTubeRSS
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class Link
    {
        private string embedCorrectUrl;
        [JsonIgnore]
        public string Rel { get; set; }

        [JsonProperty("@href")]
        public string Href 
        {
            get
            {
                return this.embedCorrectUrl;
            } 

            set 
            {
                /* because does not permit cross-origin framing in browser(FF).*/
                value = value.Replace("watch?v=", "embed/");
                this.embedCorrectUrl = value;
            } 
        }
    }
}
