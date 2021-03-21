using LogicPoint.PrecedenceClimbingParser.Printing;
using Xunit;

namespace LogicPoint.PrecedenceClimbingParser.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Test1()
        { 
            var tree = Parser.Parse("1+2*3+4");
            var printedTree = Printer.Print(tree);
            Assert.True(true);
        }
    }
}
