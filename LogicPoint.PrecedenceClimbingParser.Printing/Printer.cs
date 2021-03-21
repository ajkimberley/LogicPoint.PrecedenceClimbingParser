using Newtonsoft.Json;

namespace LogicPoint.PrecedenceClimbingParser.Printing
{
    public static class Printer
    {
        public static string Print(INode tree)
        {
            return JsonConvert.SerializeObject(tree);
        }
    }
}
