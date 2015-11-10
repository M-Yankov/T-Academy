namespace ConsumingWebService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using Newtonsoft.Json;

    /// <summary>
    /// Write a console application, which searches for news articles by given a query stringand a count of articles to retrieve.
    ///     ○ The application should ask the user for input and print the Titles and URLs of the articles.
    ///     ○ For news articles search, use the Feedzilla API and use one of WebClient, HttpWebRequest or HttpClient.
    /// </summary>
    public class StartUp
    {
        private const string SearchWord = "lorem";
        private const int CountOfPosts = 5;
        private const string UrlLink = "http://jsonplaceholder.typicode.com/posts";

        public static void Main()
        {
            IEnumerable<Post> posts = GetData(SearchWord, CountOfPosts);
            string result = Formatresult(posts);
            Console.Write(result);
        }

        private static string Formatresult(IEnumerable<Post> posts)
        {
            StringBuilder result = new StringBuilder();
            foreach (Post post in posts)
            {
                post.Uri = UrlLink;
                result.AppendLine(post.ToString());
            }

            return result.ToString();
        }

        private static string PrintStudents(HttpClient httpClient)
        {
            var response = httpClient.GetAsync(string.Empty).Result;
            string answer = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                answer = response.Content.ReadAsStringAsync().Result;
            }

            return answer;
        }

        private static IEnumerable<Post> GetData(string searchWord, int count)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlLink);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Post> response =
                JsonConvert
                .DeserializeObject<List<Post>>(PrintStudents(client))
                .Where(x => x.Body.Contains(searchWord) || x.Title.Contains(searchWord))
                .Take(count);

            return response;
        }
    }
}
