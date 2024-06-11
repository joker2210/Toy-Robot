// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Robot.Commands.Contracts;
using Robot.Commands.Implementations;
using Robot.Entities;
using Robot.Simulation;
using RobotToy = Robot.Entities.Robot;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<ISimulator, Simulator>();
        services.AddSingleton<RobotToy>();
        services.AddSingleton<Table>();
        services.AddSingleton<IPlace, Place>();
        services.AddSingleton<IMove, Move>();
        services.AddSingleton<IReport, Report>();

        services.AddLogging(
                        builder =>
                        {
                            builder.AddFilter("Microsoft", LogLevel.Warning)
                                   .AddConsole();
                        });
    }).Build();

builder.Start();
var services = builder.Services;

string filePath;

#if DEBUG
Console.WriteLine("Please provide text file path and press enter");
filePath = Console.ReadLine();
#endif

#if !DEBUG
filePath = args[0];
#endif

if (File.Exists(filePath) && (Path.GetExtension(filePath) == ".txt"))
{
    string[] commands = File.ReadAllLines(filePath);
    var simulator = services.GetRequiredService<ISimulator>();
    simulator.Start(commands);
}

else
{
    Console.WriteLine("Not a text file with .txt extension. Please try again.");
    Console.Write(@"The correct command formats are as follows:
                    PLACE X,Y,DIRECTION
                    MOVE
                    RIGHT
                    LEFT
                    REPORT");
}

Console.ReadKey();
