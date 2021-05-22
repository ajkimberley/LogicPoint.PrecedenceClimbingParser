using System.Runtime.Serialization;

namespace LogicPoint.PrecedenceClimbingParser.Abstractions
{
    public interface INode
    {
        public string Token { get; }
    }

    [DataContract]
    public class LeafNode : INode
    {
        public LeafNode(string nodeToken)
        {
            Token = nodeToken;
        }
        [DataMember]
        public string Token { get; }
    }

    [DataContract]
    public class UnaryOperatorNode : INode
    {
        public UnaryOperatorNode(string token, INode operand)
        {
            Token = token;
            Operand = operand;
        }
        [DataMember]
        public string Token { get; }
        [DataMember]
        public INode Operand { get; }
    }

    [DataContract]
    public class BinaryOperatorNode : INode
    {
        public BinaryOperatorNode(string token, INode lhs, INode rhs)
        {
            Token = token;
            LHS = lhs;
            RHS = rhs;
        }
        [DataMember]
        public string Token { get; }
        [DataMember]
        public INode LHS { get; }
        [DataMember]
        public INode RHS { get; }
    }
}
