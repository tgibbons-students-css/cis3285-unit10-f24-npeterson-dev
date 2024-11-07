using System;
using System.Collections;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class URLAsyncProvider: ITradeProvider
    {
        // field to hold the base trade data provider instance
        ITradeDataProvider baseProvider;

        // constructor accepts a base trade data provider
        public URLAsyncProvider(ITradeDataProvider baseProvider)
        {
            this.baseProvider = baseProvider;
        }

        // asynchronous method to get trade data
        public async Task<IEnumerable<string>> GetTradeDataAsync()
        {
            // run base providers GetTradedata method in a separate task
            // allows for non-blocking calls and improves responsiveness
            return await Task.Run(() => baseProvider.GetTradeData());
        }
    }
}
