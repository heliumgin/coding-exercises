namespace RubiksCubeMover.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Enums;
    using Helpers;
    using Interfaces;
    using Models;

    public class CubeDisplayService : ICubeDisplayService
    {
        public void DisplayCube(Cube cube)
        {
            var upFaceDetails = cube.UpFace.GetAllFaceColours();
            WriteLineOfColoursToConsole(upFaceDetails.Take(3).ToList(), true);
            WriteLineOfColoursToConsole(upFaceDetails.Skip(3).Take(3).ToList(), true);
            WriteLineOfColoursToConsole(upFaceDetails.TakeLast(3).ToList(), true);

            var topRow = cube.LeftFace.GetTopRowFaceColours()
                .Concat(cube.FrontFace.GetTopRowFaceColours())
                .Concat(cube.RightFace.GetTopRowFaceColours())
                .Concat(cube.BackFace.GetTopRowFaceColours()).ToList();
            WriteLineOfColoursToConsole(topRow);

            var middleRow = cube.LeftFace.GetMiddleRowFaceColours()
                .Concat(cube.FrontFace.GetMiddleRowFaceColours())
                .Concat(cube.RightFace.GetMiddleRowFaceColours())
                .Concat(cube.BackFace.GetMiddleRowFaceColours()).ToList();
            WriteLineOfColoursToConsole(middleRow);

            var bottomRow = cube.LeftFace.GetBottomRowFaceColours()
                .Concat(cube.FrontFace.GetBottomRowFaceColours())
                .Concat(cube.RightFace.GetBottomRowFaceColours())
                .Concat(cube.BackFace.GetBottomRowFaceColours()).ToList();
            WriteLineOfColoursToConsole(bottomRow);

            var downFaceDetails = cube.DownFace.GetAllFaceColours();
            WriteLineOfColoursToConsole(downFaceDetails.Take(3).ToList(), true);
            WriteLineOfColoursToConsole(downFaceDetails.Skip(3).Take(3).ToList(), true);
            WriteLineOfColoursToConsole(downFaceDetails.TakeLast(3).ToList(), true);
        }

        private static void WriteLineOfColoursToConsole(List<Colour> colours, bool hasIndent = false)
        {
            if (hasIndent)
            {
                // adds appropriate indenting as needed
                Console.Write("      ");
            }

            foreach (var colour in colours)
            {
                WriteColourToConsole(colour);
            }

            Console.Write(Environment.NewLine);
        }

        private static void WriteColourToConsole(Colour colour)
        {
            var consoleChar = EnumHelper.GetDescription(colour);
            Console.Write($"{consoleChar} ");
            Console.ResetColor();
        }
    }
}