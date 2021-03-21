using LogicPoint.PrecedenceClimbingParser.Printing;
using Xunit;

namespace LogicPoint.PrecedenceClimbingParser.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Given_ThreeSums_Then_GenerateAssociativeTree()
        { 
            var tree = Parser.Parse("1+2+3+4") as BinaryOperatorNode;
            Assert.IsType<BinaryOperatorNode>(tree);
            Assert.Equal("+", tree.Token);
            Assert.Equal("+", tree.LHS.Token);
            Assert.Equal("4", tree.RHS.Token);
        }
    }
}
