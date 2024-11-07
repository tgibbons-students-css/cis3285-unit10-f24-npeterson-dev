using SingleResponsibilityPrinciple.Contracts;

public class SingleResponsibilityPrinciple.Tests
{

    public class DummyTradeMapper : ITradeMapper
    {
        public TradeRecord Map(string[] fields)
        {
            return new TradeRecord
            {
                DestinationCurrency = "XXX",
                SourceCurrency = "YYY",
                Price = 1.11M,
                Lots = 2.22F
            };
        }
    }
}
