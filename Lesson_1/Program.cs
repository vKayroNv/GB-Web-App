using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson_1
{
    internal class Program
    {
        private const string url = "https://jsonplaceholder.typicode.com/posts/";
        private const int startIndex = 4;
        private const int endIndex = 13;
        private const string fileName = "result.txt";

        private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        private static Task<Post>[] _posts;
        private static HttpClient _client;

        private static void Main(string[] args)
        {
            _posts = new Task<Post>[endIndex - startIndex + 1];
            _client = new HttpClient();

            for (int i = startIndex; i <= endIndex; i++)
            {
                _posts[i - startIndex] = GetPostAsync(i);
            }

            Task.WaitAll(_posts);

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach(Task<Post> post in _posts)
                {
                    sw.WriteLine(post.Result + "\n");
                }
            }

            Process.Start("notepad.exe", fileName);
        }

        private static async Task<Post> GetPostAsync(int index)
        {
            string responseBody = "";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(url + index);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Post>(responseBody, options);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message :{0} ", e.Message);

                return null;
            }
        }
    }

    internal class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return 
                UserId+"\n"+
                Id+"\n"+
                Title+"\n"+
                Body;
        }
    }
}
