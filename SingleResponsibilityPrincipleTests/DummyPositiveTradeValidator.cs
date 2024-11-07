using SingleResponsibilityPrinciple.Contracts;

public class SingleResponsibilityPrinciple.Tests
{
	public class DummyPositiveTradevalidator : ITradeValidator
	{
		public bool Validate(string[] tradedata)
		{
			return true;
		}

	}
}
