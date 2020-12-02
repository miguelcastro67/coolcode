using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace CoolCode.CodeInjection
{
    public class NewRestProxy
    {
        public T GetData<T>(string url, Func<string, T> decodeSnippet)
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
                    
                    T data = decodeSnippet(jsonData);

                    // pretend there's a boat load of stuff happening with "data" here
                    // no, really, I mean a $#!$#@%$ load

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
