using System.Runtime.Serialization;

namespace LogicPoint.PrecedenceClimbingParser
{
    public interface INode
    {
        public string Token { get; }
    }

    [DataContract]
    public class NumeralNode : INode
    {
        public NumeralNode(string nodeToken)
        {
            Token = nodeToken;
        }
        [DataMember]
        public string Token { get; }
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
