using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HTTPClientTest
{
    class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            HttpGetTest();
            HttpTodoItemTest();
            HttpPostTodoItem(null);
        }

        static void HttpPostTodoItem(TodoItem item)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:50822/api/todo";

            item = new TodoItem();
            item.Id = 7;
            item.Name = "oh shit";
            item.IsComplete = false;

            string stringItem = JsonConvert.SerializeObject(item);

            var content = new StringContent(stringItem, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                
            }
        }

        static void HttpTodoItemTest()
        {
            string url = "http://localhost:50822/api/todo";

            HttpClient client = new HttpClient();

            // HTTP GET request
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                // read the content of the response
                // by calling .Result you are synchronously reading the result
                string responseString = responseContent.ReadAsStringAsync().Result;

                // deserialize json
                List<TodoItem> items = JsonConvert.DeserializeObject<List<TodoItem>>(responseString);

                foreach (TodoItem item in items)
                {
                    Console.WriteLine(item.Id + " " + item.IsComplete + " " + item.Name);
                }
            }
        }

        static void HttpGetTest()
        {
            string url = "http://localhost:50822/api/todo";

            HttpClient client = new HttpClient();

            // HTTP GET request
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                // read the content of the response
                // by calling .Result you are synchronously reading the result
                string responseString = responseContent.ReadAsStringAsync().Result;

                Console.WriteLine(responseString);
            }

        }
    }
}
