using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using json = System.Text.Json;

namespace CoolCode.CodeInjection
{
    public class OldRestProxy3
    {
        public T GetData<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                Console.WriteLine("Calling {0} service.", url);

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string jsonData = ((StreamContent)response.Content).ReadAsStringAsync().Result;

                    T data = json.JsonSerializer.Deserialize<T>(jsonData);

                    stopwatch.Stop();

                    Console.WriteLine("Time service call took: {0}", stopwatch.Elapsed);

                    return data;
                }
                else
                    return default(T);
            }
        }
    }
}
