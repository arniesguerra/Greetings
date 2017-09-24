using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;

namespace GreetingsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient cons = new HttpClient();
            cons.BaseAddress = new Uri("http://localhost:52137/");
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            MyAPIGetAsync(cons).Wait();


        }

        private static async Task<object> MyAPIGetAsync(HttpClient cons)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("http://localhost:52137/api/Greetings/0");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    Greeting greeting = await res.Content.ReadAsAsync<Greeting>();
                    Console.WriteLine("\n");
                    Console.WriteLine("{0}", greeting.Message);
                    Console.ReadLine();
                }
            }
            return 1;
        }
    }

    public class Greeting
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
