using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SingleResponsibilityPrinciple
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private readonly URLTradeDataProvider _urlTradeDataProvider;

        public AdjustTradeDataProvider(string url, ILogger logger)
        {
            _urlTradeDataProvider = new URLTradeDataProvider(url, logger);
        }

        public IEnumerable<string> GetTradeData()
        {
            // Get the original trade data from the URLTradeDataProvider
            var tradeData = _urlTradeDataProvider.GetTradeData();

            // Convert "GBP" to "EUR"
            var adjustedTradeData = tradeData.Select(line => line.Replace("GBP", "EUR"));

            return adjustedTradeData;
        }
    }
}