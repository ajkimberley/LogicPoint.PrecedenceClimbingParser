using Xunit;

namespace LogicPoint.PrecedenceClimbingParser.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Test1()
        {
            var tree = Parser.Parse("1+1*2+1");
            Assert.True(true);
        }
    }
}
