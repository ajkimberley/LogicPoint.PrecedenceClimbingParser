namespace LogicPoint.PrecedenceClimbingParser
{
    public class Token
    {
        public Token(TokenType tokenType, Associativity associativity, int precedenceLevel, string element)
        {
            TokenType = tokenType;
            Associativity = associativity;
            PrecedenceLevel = precedenceLevel;
            Element = element;
        }

        public TokenType TokenType { get; }
        public Associativity Associativity { get; }
        public int PrecedenceLevel { get; }
        public string Element { get; }
    }
}
