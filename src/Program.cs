using System;
using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace dotnetcowsay
{
    [Command(Description = "My global command line tool.")]
    class Program
    {
        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        private int OnExecute()
        {
            var cow = Cow.GetCow();
            HttpClient client = new HttpClient();
            string url = "https://discoverdot.net/data/blogs.json";
            HttpResponseMessage response = client.GetAsync(url).Result;
            string content = response.Content.ReadAsStringAsync().Result;

            var blogList = JsonConvert.DeserializeObject<List<Blog>>(content);


            Random rnd = new Random();
            var blog = blogList[rnd.Next(0, blogList.Count - 1)];


            var bubbleText = blog.title + Environment.NewLine + blog.newestFeedItem.title + Environment.NewLine + blog.newestFeedItem.link;
            string SpeechBubbleReturned = SpeechBubble.ReturnSpeechBubble(bubbleText, new SayBubbleChars(), blog.newestFeedItem.link.Length);
            Console.WriteLine(SpeechBubbleReturned + Environment.NewLine + cow);

            return 0;
        }
    }
}
