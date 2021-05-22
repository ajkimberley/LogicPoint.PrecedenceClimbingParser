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
                        numeral += (char)reader.Read();
                    }
                    yield return new Token(ArithmeticTokenType.Number, Associativity.None, 0, numeral);
                }
                else
                {
                    var charString = currentChar.ToString();
                    switch (charString)
                    {
                        case "+":
                            yield return new Token(ArithmeticTokenType.AdditionOperator, Associativity.Left, 1, charString);
                            break;
                        case "-":
                            yield return new Token(ArithmeticTokenType.SubtractionOperator, Associativity.Left, 1, charString);
                            break;
                        case "*":
                            yield return new Token(ArithmeticTokenType.MultiplicationOperator, Associativity.Left, 2, charString);
                            break;
                        case "/":
                            yield return new Token(ArithmeticTokenType.DivisionOperation, Associativity.Left, 2, charString);
                            break;
                        case "^":
                            yield return new Token(ArithmeticTokenType.ExponentiationOperator, Associativity.Right, 3, charString);
                            break;
                        case "(":
                            yield return new Token(ArithmeticTokenType.LeftBracket, Associativity.None, 0, charString);
                            break;
                        case ")":
                            yield return new Token(ArithmeticTokenType.RightBracket, Associativity.None, 0, charString);
                            break;
                        default:
                            throw new ArgumentException("Character not recognized in input.", nameof(input));
                    }
                }
            }

        }
    }
}
