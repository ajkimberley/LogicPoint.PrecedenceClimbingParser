using System;
using System.Collections.Generic;
using System.IO;

namespace LogicPoint.PrecedenceClimbingParser.SententialCalculus
{
    public class Scanner
    {
        public static IEnumerable<Token> Scan(string input)
        {
            var reader = new StringReader(input);
            while (reader.Peek() != -1)
            {
                var currentChar = (char)reader.Read();
                if (char.IsLetter(currentChar))
                {
                    var letter = currentChar.ToString();
                    while (char.IsLetter((char)reader.Peek()))
                    {
                        letter += (char)reader.Read();
                    }
                    yield return new Token(TokenType.Variable, Associativity.None, 0, letter);
                }
                else
                {
                    var charString = currentChar.ToString();
                    switch (charString)
                    {
                        case "~":
                            yield return new Token(TokenType.NegationOperator, Associativity.None, 1, charString);
                            break;
                        case "&":
                            yield return new Token(TokenType.ConditionalOperator, Associativity.Left, 2, charString);
                            break;
                        case "+":
                            yield return new Token(TokenType.DisjunctionOperator, Associativity.Left, 3, charString);
                            break;
                        case ">":
                            yield return new Token(TokenType.ConditionalOperator, Associativity.Left, 4, charString);
                            break;
                        case "#":
                            yield return new Token(TokenType.BiConditionalOperator, Associativity.Left, 4, charString);
                            break;
                        case "(":
                            yield return new Token(TokenType.LeftBracket, Associativity.None, 0, charString);
                            break;
                        case ")":
                            yield return new Token(TokenType.RightBracket, Associativity.None, 0, charString);
                            break;
                        default:
                            throw new ArgumentException("Character not recognized in input.", nameof(input));
                    }
                }
            }

        }
    }
}
