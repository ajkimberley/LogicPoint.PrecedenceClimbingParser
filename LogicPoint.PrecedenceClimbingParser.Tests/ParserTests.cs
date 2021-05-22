using FluentAssertions;
using LogicPoint.PrecedenceClimbingParser.Abstractions;
using LogicPoint.PrecedenceClimbingParser.BasicArithmetic;
using System;
using Xunit;

namespace LogicPoint.PrecedenceClimbingParser.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Given_ThreeSums_Then_GenerateLeftAssociativeTree()
        {
            var tree = Parser.Parse("1+2+3+4") as BinaryOperatorNode;
            var expected = new BinaryOperatorNode("+",
                                                  new BinaryOperatorNode("+",
                                                                         new BinaryOperatorNode("+",
                                                                                                new LeafNode("1"),
                                                                                                new LeafNode("2")),
                                                                         new LeafNode("3")),
                                                  new LeafNode("4"));
            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_ThreeSubtractions_Then_GenerateLeftAssociativeTree()
        {
            var tree = Parser.Parse("1-2-3-4");
            var expected = new BinaryOperatorNode("-",
                                      new BinaryOperatorNode("-",
                                                             new BinaryOperatorNode("-",
                                                                                    new LeafNode("1"),
                                                                                    new LeafNode("2")),
                                                             new LeafNode("3")),
                                      new LeafNode("4"));
            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_ThreeMultiplications_Then_GenerateLeftAssociativeTree()
        {
            var tree = Parser.Parse("1*2*3*4");
            var expected = new BinaryOperatorNode("*",
                                      new BinaryOperatorNode("*",
                                                             new BinaryOperatorNode("*",
                                                                                    new LeafNode("1"),
                                                                                    new LeafNode("2")),
                                                             new LeafNode("3")),
                                      new LeafNode("4"));
            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_ThreeDivisions_Then_GenerateLeftAssociativeTree()
        {
            var tree = Parser.Parse("1/2/3/4");
            var expected = new BinaryOperatorNode("/",
                                      new BinaryOperatorNode("/",
                                                             new BinaryOperatorNode("/",
                                                                                    new LeafNode("1"),
                                                                                    new LeafNode("2")),
                                                             new LeafNode("3")),
                                      new LeafNode("4"));
            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_ThreeExponentiations_Then_GenerateRightAssociativeTree()
        {
            var tree = Parser.Parse("1^2^3^4");
            var expected = new BinaryOperatorNode("^",
                                                  new LeafNode("1"),
                                                  new BinaryOperatorNode("^",
                                                                         new LeafNode("2"),
                                                                         new BinaryOperatorNode("^",
                                                                                                new LeafNode("3"),
                                                                                                new LeafNode("4"))));
            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_SumFollowedByMultiplicationFollowedBySum_GenerateTreeWithMultiplicationAtBottom()
        {
            var tree = Parser.Parse("1+2*3+4");
            var expected = new BinaryOperatorNode("+",
                                                  new BinaryOperatorNode("+",
                                                                         new LeafNode("1"),
                                                                         new BinaryOperatorNode("*",
                                                                                                new LeafNode("2"),
                                                                                                new LeafNode("3"))),
                                                  new LeafNode("4"));

            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_SumFollowedByMultiplicationFollowedByExponentiation_Then_GenerateTreeWithCorrectPrecedence()
        {
            var tree = Parser.Parse("1+2*3^4");
            var expected = new BinaryOperatorNode("+",
                                                  new LeafNode("1"),
                                                  new BinaryOperatorNode("*",
                                                                         new LeafNode("2"),
                                                                         new BinaryOperatorNode("^",
                                                                                                new LeafNode("3"),
                                                                                                new LeafNode("4"))));
            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_MultiplicationFollowedByBracketedAddition_Then_GenerateTreeWithAdditionTakingPrecedence()
        {
            var tree = Parser.Parse("1*(2+3)");
            var expected = new BinaryOperatorNode("*",
                                                  new LeafNode("1"),
                                                  new BinaryOperatorNode("+",
                                                                         new LeafNode("2"),
                                                                         new LeafNode("3")));
            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_BracketedAdditionInBetweenTwoExponentiations_Then_GenerateTreeWithAdditionTakingPrecedence()
        {
            var tree = Parser.Parse("1^(2+3)^4");
            var expected = new BinaryOperatorNode("^",
                                                 new LeafNode("1"),
                                                 new BinaryOperatorNode("^",
                                                                        new BinaryOperatorNode("+",
                                                                                               new LeafNode("2"),
                                                                                               new LeafNode("3")),
                                                                        new LeafNode("4")));
            tree.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(new object[] { "+" })]
        [InlineData(new object[] { "1++" })]
        [InlineData(new object[] { "+1" })]
        [InlineData(new object[] { "1+2*" })]
        [InlineData(new object[] { "1++2" })]
        public void Given_InvalidInput_ThrowException(string invalidInput)
        {
            Assert.Throws<Exception>(() => Parser.Parse(invalidInput));
        }
    }
}
