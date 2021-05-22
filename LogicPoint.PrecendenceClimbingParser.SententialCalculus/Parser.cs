using LogicPoint.PrecedenceClimbingParser.Abstractions;
using System;
using System.Collections.Generic;

namespace LogicPoint.PrecedenceClimbingParser.SententialCalculus
{
    public class Parser
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
            if (currentToken.TokenType == TokenType.LeftBracket)
            {
                var value = ParseExpression(tokens, 1);
                if (tokens.Current.TokenType != TokenType.RightBracket) throw new Exception("Unmatched left bracket detected");
                tokens.MoveNext();
                return value;
            }
            if (currentToken.TokenType == TokenType.NegationOperator)
            {
                var negationElement = currentToken.Element;
                tokens.MoveNext();
                var negationNode = new UnaryOperatorNode(negationElement, ParseElement(tokens));
                return negationNode;
            }
            if (currentToken.TokenType == TokenType.Variable)
            {
                var numeralNode = new LeafNode(currentToken.Element);
                tokens.MoveNext();
                return numeralNode;
            }
            else throw new Exception($"Unexpected token type: {currentToken.TokenType}");
        }
    }
}
