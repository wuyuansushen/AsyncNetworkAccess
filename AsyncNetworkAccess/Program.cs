using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace AsyncNetworkAccess
{
    class Program
    {
        async static Task Main()
        {
            var client = new HttpClient();
            string urlUsed = "https://cn.bing.com";
            Console.Write("Input Url for request: ");
            string urlIn = Console.ReadLine();
            var getTask = client.SendAsync(new HttpRequestMessage() { Method = HttpMethod.Get, RequestUri = new Uri((urlIn.Trim()).Length==0 ? urlUsed:urlIn) }) ;
            double i;
            for (i = 0; i < 1000; i++)
            {
                if (getTask.IsCompleted)
                {
                    Console.WriteLine($" {(await getTask).StatusCode}");
                    i /= 100;
                    Console.WriteLine($"Usage: {i}s");
                    break;
                }else
                {
                    Thread.Sleep(10);
                }
            }
        }
    }
}
