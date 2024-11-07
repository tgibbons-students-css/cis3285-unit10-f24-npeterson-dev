using SingleResponsibilityPrinciple.Contracts;

public class SingleResponsibilityPrinciple.Tests
{

    public class DummyNegativeTradevalidator : ITradeValidator
    {
        public bool Validate(string[] tradedata)
        {
            return false;
        }

    }
}
