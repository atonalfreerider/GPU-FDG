using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using GPU_FDG.Database;
using GPU_FDG.DemoRandom;

namespace GPU_FDG;

static class Program
{
    static void Main(string[] args)
    {
        RootCommand rootCommand = new("Force Directed Graph using ComputeSharp")
        {
            new Argument<string>(
                "DbPath",
                "Path to the database with nodes and edges tables"),
            new Option<int>(
                ["--iterations", "-i"],
                () => 50,
                "Iterations"),
            new Option<float>(
                ["--springForce", "-k"],
                () => .15f,
                "Universal spring force (must be less than 1)"),
            new Option<float>(
                ["--repulsiveForce", "-e"],
                () => 1,
                "Universal repulsive force"),
        };

        rootCommand.Handler = CommandHandler
            .Create<string, int, float, float>(GenerateGraphFromData.RunGraph);

        Command runDemoGraphCommand = new(
            "demoGraph",
            "Run demo graph with random nodes and connections")
        {
            rootCommand.Arguments[0],
            rootCommand.Options[0],
            rootCommand.Options[1],
            rootCommand.Options[2],
            new Option<int>(
                ["--numRandNodes", "-n"],
                () => 0,
                "Number of random nodes"),
            new Option<int>(
                ["--numRandConnections", "-c"],
                () => 0,
                "Number of random connections")
        };
        rootCommand.AddCommand(runDemoGraphCommand);

        runDemoGraphCommand.Handler = CommandHandler
            .Create<string, int, float, float, int, int>(DemoRandomGraph.RunDemoGraph);

        rootCommand.Invoke(args);
    }
}