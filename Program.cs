using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using GPU_FDG.Database;
using GPU_FDG.DemoRandom;

namespace GPU_FDG;

static class Program
{
    internal class Args
    {
        public string DbPath { get; set; }
        public int Iterations { get; set; }
        public float SpringForce { get; set; }
        public float RepulsiveForce { get; set; }
        public int NumRandNodes { get; set; }
        public int NumRandConnections { get; set; }
    }

    static void Main(string[] args)
    {
        // Create a root command with some options
        RootCommand rootCommand = new()
        {
            new Option<int>(
                new[] {"--iterations", "-i"},
                () => 50,
                "Iterations"),
            new Option<float>(
                new[] {"--springForce", "-k"},
                () => .15f,
                "Universal spring force (must be less than 1)"),
            new Option<float>(
                new[] {"--repulsiveForce", "-e"},
                () => 1,
                "Universal repulsive force"),
            new Option<int>(
                new[] {"--numRandNodes", "-n"},
                () => 0,
                "Number of random nodes"),
            new Option<int>(
                new[] {"--numRandConnections", "-c"},
                () => 0,
                "Number of random connections"),
        };

        Argument<string> outputArgument = new("DbPath");
        rootCommand.Add(outputArgument);

        rootCommand.Description = "Force Directed Graph using ComputeSharp";

        // Note that the parameters of the handler method are matched according to the names of the options
        rootCommand.Handler = CommandHandler.Create<Args>(Run);

        rootCommand.Invoke(args);
    }

    static void Run(Args args)
    {
        if (args.NumRandNodes > 0 && args.NumRandConnections > 0)
        {
            DemoRandomGraph.RunDemoGraph(args);
        }
        else
        {
            GenerateGraphFromData.RunGraph(args);
        }
    }
}