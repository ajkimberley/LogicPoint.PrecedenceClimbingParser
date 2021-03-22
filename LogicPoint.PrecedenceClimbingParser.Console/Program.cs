using static LogicPoint.PrecedenceClimbingParser.Parser;
using static LogicPoint.PrecedenceClimbingParser.Printing.Printer;
namespace LogicPoint.PrecedenceClimbingParser.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                System.Console.WriteLine("Please enter arithmetic expression to parse...");
                var input = System.Console.ReadLine();
                var tree = GenerateTreeFor(input);
                var printedTree = Print(tree);
                System.Console.Clear();
                System.Console.WriteLine(printedTree);
                System.Console.ReadKey();
            }
        }

        private static INode GenerateTreeFor(string input)
            => Parse(input);
    }
}
