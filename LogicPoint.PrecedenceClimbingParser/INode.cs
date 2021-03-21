using System;

namespace LogicPoint.PrecedenceClimbingParser
{
    public interface INode
    {
    }

    public class RootNode : INode
    {
        public INode Root { get; set; }
    }

    public class NumeralNode : INode
    {
        public NumeralNode(Token token, int value)
        {
            Token = token;
            Value = value;
        }
        public Token Token { get; }
        public int Value { get; }
    }

    public class BinaryOperatorNode : INode
    {
        public BinaryOperatorNode(Token token, INode lhs, INode rhs)
        {
            Token = token;
            LHS = lhs;
            RHS = rhs;
        }

        public Token Token { get; }
        public INode LHS { get; }
        public INode RHS { get; }
    }
}
