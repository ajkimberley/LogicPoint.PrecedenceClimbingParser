using System;
using System.Collections.Generic;

namespace LogicPoint.PrecedenceClimbingParser
{
    public class BasicArithmeticParser
    {
        public static INode Parse(string input)
        {
            var tokens = Scanner.Scan(input).GetEnumerator();
            var tree = ParseExpression(tokens, 1);
            return tree;
        }

        private static INode ParseExpression(IEnumerator<Token> tokens, int minPrecedenceLevel)
        {
            tokens.MoveNext();
            var lhs = ParseElement(tokens);
            while (true)
            {
                var currentToken = tokens.Current;
                if (currentToken.PrecedenceLevel < minPrecedenceLevel) break;
                else
                {
                    var rhs = ParseExpression(tokens, currentToken.Associativity == Associativity.Left ? currentToken.PrecedenceLevel + 1 : currentToken.PrecedenceLevel);
                    lhs = new BinaryOperatorNode(currentToken.Element, lhs, rhs);
                }
            }
            return lhs;
        }

        private static INode ParseElement(IEnumerator<Token> tokens)
        {
            var currentToken = tokens.Current;
            if (currentToken.TokenType == ArithmeticTokenType.LeftBracket)
            {
                var value = ParseExpression(tokens, 1);
                if (tokens.Current.TokenType != ArithmeticTokenType.RightBracket) throw new Exception("Unmatched left bracket detected");
                tokens.MoveNext();
                return value;
            }
            if (currentToken.TokenType == ArithmeticTokenType.Number) 
            {
                var numeralNode = new NumeralNode(currentToken.Element);
                tokens.MoveNext();
                return numeralNode;
            }
            else throw new Exception($"Unexpected token type: {currentToken.TokenType}");
        }
    }
}
