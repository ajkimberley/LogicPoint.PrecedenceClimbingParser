using System;
using System.Collections.Generic;
using System.IO;

namespace LogicPoint.PrecedenceClimbingParser
{
    public static class Scanner
    {
        public static IEnumerable<Token> Scan(string input)
        {
            var reader = new StringReader(input);
            while (reader.Peek() != -1)
            {
                var currentChar = (char)reader.Read();
                if (char.IsDigit(currentChar))
                {
                    var numeral = currentChar.ToString();
                    while (char.IsDigit((char)reader.Peek()))
                    {
                        numeral += reader.Read();
                    }
                    yield return new Token(TokenType.Number, Associativity.None, 0, numeral);
                }
                else
                {
                    var charString = currentChar.ToString();
                    switch (charString)
                    {
                        case "+":
                            yield return new Token(TokenType.AdditionOperator, Associativity.Left, 1, charString);
                            break;
                        case "-":
                            yield return new Token(TokenType.SubtractionOperator, Associativity.Left, 1, charString);
                            break;
                        case "*":
                            yield return new Token(TokenType.MultiplicationOperator, Associativity.Left, 2, charString);
                            break;
                        case "/":
                            yield return new Token(TokenType.DivisionOperation, Associativity.Left, 2, charString);
                            break;
                        case "^":
                            yield return new Token(TokenType.ExponentiationOperator, Associativity.Right, 3, charString);
                            break;
                        default:
                            throw new ArgumentException("Character not recognized in input.", nameof(input));
                    }
                }
            }

        }
    }
}
