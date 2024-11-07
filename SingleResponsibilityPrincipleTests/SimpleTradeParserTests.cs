using System.Collections.Generic;
using SingleResponsibilityPrinciple;


namespace SingleResponsibilityPrinciple.Tests
{
    [TestClass]
    public class SimpleTradeParserTests
    {
        private class DummyPositiveTradeValidator : ITradeValidator
        {
            public bool Validate(string[] tradeData)
            {
                return true; // Always valid for testing
            }
        }

        private class DummyNegativeTradeValidator : ITradeValidator
        {
            public bool Validate(string[] tradeData)
            {
                return false; // Always invalid for testing
            }
        }

        private class DummyTradeMapper : ITradeMapper
        {
            public TradeRecord Map(string[] fields)
            {
                return new TradeRecord
                {
                    DestinationCurrency = fields[0].Substring(0, 3),
                    SourceCurrency = fields[0].Substring(3, 3),
                    Price = decimal.Parse(fields[1]),
                    Lots = float.Parse(fields[2])
                };
            }
        }

        [TestMethod]
        public void TestNumberOfPosLines()
        {
            // Arrange
            var validator = new DummyPositiveTradeValidator();
            var mapper = new DummyTradeMapper();
            var parser = new SimpleTradeParser(validator, mapper);
            List<string> sampleInput = new List<string> { "XXXYYY,1111,9.99", "XXXYYY,2222,9.99", "XXXYYY,3333,9.99" };

            // Act
            IEnumerable<TradeRecord> result = parser.Parse(sampleInput);

            // Assert
            Assert.AreEqual(result.Count(), sampleInput.Count());
        }

        [TestMethod]
        public void TestNumberOfNegLines()
        {
            // Arrange
            var validator = new DummyNegativeTradeValidator();
            var mapper = new DummyTradeMapper();
            var parser = new SimpleTradeParser(validator, mapper);
            List<string> sampleInput = new List<string> { "XXXYYY,1111,9.99", "XXXYYY,2222,9.99", "XXXYYY,3333,9.99" };

            // Act
            IEnumerable<TradeRecord> result = parser.Parse(sampleInput);

            // Assert
            Assert.AreEqual(0, result.Count());
        }
    }
}
