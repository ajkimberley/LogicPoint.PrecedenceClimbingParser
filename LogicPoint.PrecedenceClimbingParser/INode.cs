using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace LogicPoint.PrecedenceClimbingParser
{
    public interface INode
    {
    }

    public class RootNode : INode
    {
        public INode Root { get; set; }
    }

    [DataContract]
    public class NumeralNode : INode
    {
        public NumeralNode(Token token, int value)
        {
            Token = token;
            Value = value;
        }
        public Token Token { get; }
        [DataMember]
        public int Value { get; }
    }

    [DataContract]
    public class BinaryOperatorNode : INode
    {
        public BinaryOperatorNode(Token token, INode lhs, INode rhs)
        {
            Token = token;
            LHS = lhs;
            RHS = rhs;
        }
        [DataMember]
        public Token Token { get; }
        [DataMember]
        public INode LHS { get; }
        [DataMember]
        public INode RHS { get; }
    }
}
