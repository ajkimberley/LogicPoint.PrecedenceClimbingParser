using LogicPoint.PrecedenceClimbingParser.Abstractions;
using Newtonsoft.Json;

namespace LogicPoint.PrecedenceClimbingParser.Printing
{
    public static class Printer
    {
        public static string Print(INode tree)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new ASTSerialzer());
            settings.Formatting = Formatting.Indented;

            return JsonConvert.SerializeObject(tree, settings);
        }
    }
}
