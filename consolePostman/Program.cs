using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace consolePostman
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task t1 = PostMan.PostAsync<Student>(15, "IsAs");
            Task t2 = PostMan.GetAsync<Student>(null);
            Console.ReadLine();
        }
    }

    class PostMan
    {
        public static async Task GetAsync<T>(string id)
        {
            string type = typeof(T).Name;
            string url = MakeString(type, id);

            HttpClient client = new HttpClient();
            HttpResponseMessage result = await client.GetAsync(url);

            string resultString = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultString);
        }
        public static async Task PostAsync<T>(int id, string name)
        {
            string type = typeof(T).Name;
            string json = "{\"" + type + "Id\":" + id + ", \"" + type + "Name\": \"" + name + "\"}";
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            string url = "http://ggku2ser2/api/values/Add" + type;

            HttpClient client = new HttpClient();
            var task = await client.PostAsync(url, httpContent);
            if (task.IsSuccessStatusCode)
            {
                Console.WriteLine("Your Details are Uploaded !!!");
            }
        }

        private static string MakeString(string type, string id)
        {
            string url = "http://ggku2ser2/api/values/get";
            if (id == null)
            {
                return url += type + "s";
            }
            else
            {
                return url += type + "byid/" + id;
            }
        }
    }
    class Student
    {

    }
    class Group
    {

    }
}
