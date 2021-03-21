using static LogicPoint.PrecedenceClimbingParser.Scanner;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using System;

namespace LogicPoint.PrecedenceClimbingParser.Tests
{
    public class ScannerTests
    {
        [Theory]
        [MemberData(nameof(_theoryData))]
        public void Given_ValidInput_Should_ProduceCorrectSequenceOfTokens(string input, List<TokenType> expected)
        {
            var actual = Scan(input);
            Assert.True(expected.SequenceEqual(actual.Select(x => x.TokenType)));
        }

        [Theory]
        [InlineData(new object[] { "invalid" })]
        public void Given_InvalidInput_Should_ThrowArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => Scan(input).ToList());
        }

        public static readonly List<object[]> _theoryData = new List<object[]>
        {
            new object[]
            {
                "1+1",
                new List<TokenType>
                {
                    TokenType.Number, TokenType.AdditionOperator, TokenType.Number
                }
            },
            new object[]
            {
                "1-1",
                new List<TokenType>
                {
                    TokenType.Number, TokenType.SubtractionOperator, TokenType.Number
                }
            },
            new object[]
            {
                "1*1",
                new List<TokenType>
                {
                    TokenType.Number, TokenType.MultiplicationOperator, TokenType.Number
                }
            },
            new object[]
            {
                "1/1",
                new List<TokenType>
                {

                    TokenType.Number, TokenType.DivisionOperation, TokenType.Number
                }
            },
            new object[]
            {
                "101+202",
                new List<TokenType>
                {
                    TokenType.Number, TokenType.AdditionOperator, TokenType.Number
                }
            },
            new object[]
            {
                "10/4*4+105",
                new List<TokenType>
                {
                    TokenType.Number, TokenType.DivisionOperation, TokenType.Number, TokenType.MultiplicationOperator,
                    TokenType.Number, TokenType.AdditionOperator, TokenType.Number
                }
            }
        };
    }
}
