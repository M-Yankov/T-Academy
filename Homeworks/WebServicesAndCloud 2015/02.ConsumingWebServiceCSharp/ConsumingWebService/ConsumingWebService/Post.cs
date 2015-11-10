namespace ConsumingWebService
{
    using Newtonsoft;
    using Newtonsoft.Json;

    [JsonObject]
    public class Post
    {
        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Uri { get; set; }

        [JsonProperty]
        public string Body { get; set; }

        public override string ToString()
        {
            return string.Format("Title :{0}\nUri: {1}\nContent: {2}\n", this.Title, this.Uri, this.Body);
        }
    }
}
