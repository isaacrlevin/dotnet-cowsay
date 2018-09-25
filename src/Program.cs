using System;
using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Kurukuru;
using System.Threading.Tasks;

namespace dotnetcowsay
{
    [Command(Description = "Cowsay a Blog Post.")]
    class Program
    {
        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        private async Task<int> OnExecute()
        {
            await GetLink();

            return 0;
        }

        private async Task GetLink()
        {
            await SpinnerEx.StartAsync("Looking for an awesome article..", async spinner =>
            {
                try
                {
                    Blog blog = new Blog();

                    HttpClient client = new HttpClient();
                    string url = "https://discoverdot.net/data/blogs.json";
                    string content = await client.GetStringAsync(url);

                    var blogList = JsonConvert.DeserializeObject<List<Blog>>(content);
                    Random rnd = new Random();
                    blog = blogList[rnd.Next(0, blogList.Count - 1)];

                    var cow = Cow.GetCow();
                    var bubbleText = blog.title + Environment.NewLine + blog.newestFeedItem.title + Environment.NewLine + blog.newestFeedItem.link;
                    string SpeechBubbleReturned = SpeechBubble.ReturnSpeechBubble(bubbleText, new SayBubbleChars(), blog.newestFeedItem.link.Length);
                    Console.WriteLine(Environment.NewLine + SpeechBubbleReturned + Environment.NewLine + cow);
                }
                catch
                {
                    spinner.Fail("Something went wrong, please try again");
                }
            });
        }
    }
}
