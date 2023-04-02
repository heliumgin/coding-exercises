namespace RubiksCubeMover
{
    using System;
    using System.Linq;

    using Microsoft.Extensions.DependencyInjection;

    using Enums;
    using Interfaces;
    using Models;
    using Services;

    public class Program
    {
        private static Cube _cube;
        private static ICubeRotationService _cubeRotationService;
        private static ICubeDisplayService _cubeDisplayService;

        public static void Main(string[] args)
        {
            var services = SetupServices();
            _cubeRotationService = services.GetRequiredService<ICubeRotationService>();
            _cubeDisplayService = services.GetRequiredService<ICubeDisplayService>();
            _cube = new Cube();
            MoveCube();
        }

        private static ServiceProvider SetupServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICubeRotationService, CubeRotationService>()
                .AddTransient<ICubeDisplayService, CubeDisplayService>()
                .BuildServiceProvider();

            return serviceProvider;
        }

        public static void MoveCube()
        {
            ListCommandOptions();
            _cubeDisplayService.DisplayCube(_cube);

            while (true)
            {
                Console.WriteLine("Please enter your move:");
                var userInput = Console.ReadLine();

                if (userInput != null)
                {

                    if (userInput.ToUpper() == "Q")
                    {
                        break;
                    }

                    switch (userInput.ToUpper())
                    {
                        case "L":
                            ListCommandOptions();
                            continue;
                        case "R":
                            _cube = new Cube();
                            _cubeDisplayService.DisplayCube(_cube);
                            continue;
                    }

                    if (Enum.TryParse<Command>(userInput, out var userCommand))
                    {
                        _cube = _cubeRotationService.Rotate(_cube, userCommand);
                        _cubeDisplayService.DisplayCube(_cube);
                    }
                    else
                    {
                        Console.WriteLine($"{userInput} is not a recognised command. Please try again.");
                    }
                }
            }
        }

        private static void ListCommandOptions()
        {
            Console.WriteLine("Available commands:");
            var commands = Enum.GetValues(typeof(Command)).OfType<Command>();
            foreach (Command command in commands)
            {
                Console.WriteLine($"{(int)command} = {command}");
            }
            Console.WriteLine("L = List all commands");
            Console.WriteLine("R = Reset cube");
            Console.WriteLine("Q = Quit");
        }
    }
}