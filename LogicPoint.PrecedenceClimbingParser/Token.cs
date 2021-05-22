using System.Runtime.Serialization;

namespace LogicPoint.PrecedenceClimbingParser
{
    [DataContract]
    public class Token
    {
        public Token(ArithmeticTokenType tokenType, Associativity associativity, int precedenceLevel, string element)
        {
            TokenType = tokenType;
            Associativity = associativity;
            PrecedenceLevel = precedenceLevel;
            Element = element;
        }

        public ArithmeticTokenType TokenType { get; }
        public Associativity Associativity { get; }
        public int PrecedenceLevel { get; }
        [DataMember]
        public string Element { get; }
    }
}
