using LogicPoint.PrecedenceClimbingParser.Abstractions;
using Newtonsoft.Json;
using System;

namespace LogicPoint.PrecedenceClimbingParser.Printing
{
    class ASTSerialzer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(UnaryOperatorNode))
            {
                var node = (UnaryOperatorNode)value;
                writer.WriteStartObject();
                writer.WritePropertyName(node.Token);
                writer.WriteStartArray();
                serializer.Serialize(writer, node.Operand);
                writer.WriteEndArray();
                writer.WriteEndObject();
            }
            if (value.GetType() == typeof(BinaryOperatorNode))
            {
                var node = (BinaryOperatorNode)value;
                writer.WriteStartObject();
                writer.WritePropertyName(node.Token);
                writer.WriteStartArray();
                serializer.Serialize(writer, node.LHS);
                serializer.Serialize(writer, node.RHS);
                writer.WriteEndArray();
                writer.WriteEndObject();
            }
            else if (value.GetType() == typeof(LeafNode))
            {
                var node = (LeafNode)value;
                writer.WriteValue(node.Token);
            }
        }
    }
}
