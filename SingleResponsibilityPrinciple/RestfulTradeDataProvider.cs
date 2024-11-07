using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class RestfulTradeDataProvider : ITradeDataProvider
    {
        string url;
        ILogger logger;
        HttpClient client;

        public RestfulTradeDataProvider(string url, ILogger logger)
        {
            this.url = url;
            this.logger = logger;
            this.client = new HttpClient();
        }

        public async IAsyncEnumerable<string> GetStringsAsync()
        {
            logger.LogInfo("Connecting to the Restful server using HTTP");
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // Read the content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the content into a List<string>
                var tradesString = JsonSerializer.Deserialize<List<string>>(content);
                logger.LogInfo("Received trade strings of length = " + tradesString.Count);

                // Yield each trade string
                foreach (var trade in tradesString)
                {
                    yield return trade;
                }
            }
            else
            {
                logger.LogWarning($"Failed to retrieve data. Status code: {response.StatusCode}");
                throw new Exception($"Error retrieving data from URL: {url}");
            }
        }

        //async Task<List<string>> GetTradeAsync()
        //{
        //    logger.LogInfo("Connecting to the Restful server using HTTP");
        //    List<string> tradesString = null;
        //
        //    HttpResponseMessage response = await client.GetAsync(url);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Read the content as a string and deserialize it into a List<string>
        //        string content = await response.Content.ReadAsStringAsync();
        //        tradesString = JsonSerializer.Deserialize<List<string>>(content);
        //        logger.LogInfo("Received trade strings of length = " + tradesString.Count);
        //    }
        //    return tradesString;
        //}

        //public IEnumerable<string> GetTradeData()
        //{
        //    Task<List<string>> task = Task.Run(() => GetTradeAsync());
        //    task.Wait();
        //
        //    List<string> tradeList = task.Result;
        //    return tradeList;
        //}
    }
}
