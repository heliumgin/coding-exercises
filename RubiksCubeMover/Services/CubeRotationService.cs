namespace RubiksCubeMover.Services
{
    using System;
    using System.Collections.Generic;

    using Enums;
    using Interfaces;
    using Models;

    public class CubeRotationService : ICubeRotationService
    {
        public Cube Rotate(Cube cube, Command command)
        {
            var isClockwise = (int)command > 0;

            switch (command)
            {
                case Command.FrontClockwise:
                case Command.FrontCounterclockwise:
                {
                    cube.FrontFace = RotateMovingFace(cube.FrontFace, isClockwise);
                    var aboveFace = cube.UpFace;
                    var rightSideFace = cube.RightFace;
                    var belowFace = cube.DownFace;
                    var leftSideFace = cube.LeftFace;
                    var aboveColours = GetBottomRowColours(aboveFace);
                    var rightSideColours = GetLeftColumnColours(rightSideFace);
                    var belowColours = GetTopRowColours(belowFace);
                    var leftSideColours = GetRightColumnColours(leftSideFace);

                    if (isClockwise)
                    {
                        cube.UpFace = SetBottomRowColours(aboveFace, leftSideColours, true);
                        cube.RightFace = SetLeftColumnColours(rightSideFace, aboveColours, true);
                        cube.DownFace = SetTopRowColours(belowFace, rightSideColours, true);
                        cube.LeftFace = SetRightColumnColours(leftSideFace, belowColours, true);
                    }
                    else
                    {
                        cube.UpFace = SetBottomRowColours(aboveFace, rightSideColours, false);
                        cube.RightFace = SetLeftColumnColours(rightSideFace, belowColours, false);
                        cube.DownFace = SetTopRowColours(belowFace, leftSideColours, false);
                        cube.LeftFace = SetRightColumnColours(leftSideFace, aboveColours, false);
                    }

                    break;
                }
                case Command.BackClockwise:
                case Command.BackCounterclockwise:
                {
                    cube.BackFace = RotateMovingFace(cube.BackFace, isClockwise);
                    var aboveFace = cube.UpFace;
                    var rightSideFace = cube.LeftFace;
                    var belowFace = cube.DownFace;
                    var leftSideFace = cube.RightFace;
                    var aboveColours = GetTopRowColours(aboveFace);
                    var rightSideColours = GetLeftColumnColours(rightSideFace);
                    var belowColours = GetBottomRowColours(belowFace);
                    var leftSideColours = GetRightColumnColours(leftSideFace);

                    if (isClockwise)
                    {
                        cube.UpFace = SetTopRowColours(aboveFace, leftSideColours, false);
                        cube.LeftFace = SetLeftColumnColours(rightSideFace, aboveColours, false);
                        cube.DownFace = SetBottomRowColours(belowFace, rightSideColours, false);
                        cube.RightFace = SetRightColumnColours(leftSideFace, belowColours, false);
                    }
                    else
                    {
                        cube.UpFace = SetTopRowColours(aboveFace, rightSideColours, true);
                        cube.LeftFace = SetLeftColumnColours(rightSideFace, belowColours, true);
                        cube.DownFace = SetBottomRowColours(belowFace, leftSideColours, true);
                        cube.RightFace = SetRightColumnColours(leftSideFace, aboveColours, true);
                    }

                    break;
                }
                case Command.UpClockwise:
                case Command.UpCounterclockwise:
                {
                    cube.UpFace = RotateMovingFace(cube.UpFace, isClockwise);
                    var aboveFace = cube.BackFace;
                    var rightSideFace = cube.RightFace;
                    var belowFace = cube.FrontFace;
                    var leftSideFace = cube.LeftFace;
                    var aboveColours = GetTopRowColours(aboveFace);
                    var rightSideColours = GetTopRowColours(rightSideFace);
                    var belowColours = GetTopRowColours(belowFace);
                    var leftSideColours = GetTopRowColours(leftSideFace);

                    if (isClockwise)
                    {
                        cube.BackFace = SetTopRowColours(aboveFace, leftSideColours, false);
                        cube.RightFace = SetTopRowColours(rightSideFace, aboveColours, false);
                        cube.FrontFace = SetTopRowColours(belowFace, rightSideColours, false);
                        cube.LeftFace = SetTopRowColours(leftSideFace, belowColours, false);
                    }
                    else
                    {
                        cube.BackFace = SetTopRowColours(aboveFace, rightSideColours, false);
                        cube.RightFace = SetTopRowColours(rightSideFace, belowColours, false);
                        cube.FrontFace = SetTopRowColours(belowFace, leftSideColours, false);
                        cube.LeftFace = SetTopRowColours(leftSideFace, aboveColours, false);
                    }

                    break;
                }
                case Command.DownClockwise:
                case Command.DownCounterclockwise:
                {
                    cube.DownFace = RotateMovingFace(cube.DownFace, isClockwise);
                    var aboveFace = cube.FrontFace;
                    var rightSideFace = cube.RightFace;
                    var belowFace = cube.BackFace;
                    var leftSideFace = cube.LeftFace;
                    var aboveColours = GetBottomRowColours(aboveFace);
                    var rightSideColours = GetBottomRowColours(rightSideFace);
                    var belowColours = GetBottomRowColours(belowFace);
                    var leftSideColours = GetBottomRowColours(leftSideFace);

                    if (isClockwise)
                    {
                        cube.FrontFace = SetBottomRowColours(aboveFace, leftSideColours, false);
                        cube.RightFace = SetBottomRowColours(rightSideFace, aboveColours, false);
                        cube.BackFace = SetBottomRowColours(belowFace, rightSideColours, false);
                        cube.LeftFace = SetBottomRowColours(leftSideFace, belowColours, false);
                    }
                    else
                    {
                        cube.FrontFace = SetBottomRowColours(aboveFace, rightSideColours, false);
                        cube.RightFace = SetBottomRowColours(rightSideFace, belowColours, false);
                        cube.BackFace = SetBottomRowColours(belowFace, leftSideColours, false);
                        cube.LeftFace = SetBottomRowColours(leftSideFace, aboveColours, false);
                    }

                    break;
                }
                case Command.LeftClockwise:
                case Command.LeftCounterclockwise:
                {
                    cube.LeftFace = RotateMovingFace(cube.LeftFace, isClockwise);
                    var aboveFace = cube.UpFace;
                    var rightSideFace = cube.FrontFace;
                    var belowFace = cube.DownFace;
                    var leftSideFace = cube.BackFace;
                    var aboveColours = GetLeftColumnColours(aboveFace);
                    var rightSideColours = GetLeftColumnColours(rightSideFace);
                    var belowColours = GetLeftColumnColours(belowFace);
                    var leftSideColours = GetRightColumnColours(leftSideFace);

                    if (isClockwise)
                    {
                        cube.UpFace = SetLeftColumnColours(aboveFace, leftSideColours, false);
                        cube.FrontFace = SetLeftColumnColours(rightSideFace, aboveColours, true);
                        cube.DownFace = SetLeftColumnColours(belowFace, rightSideColours, true);
                        cube.BackFace = SetRightColumnColours(leftSideFace, belowColours, false);
                    }
                    else
                    {
                        cube.UpFace = SetLeftColumnColours(aboveFace, rightSideColours, true);
                        cube.FrontFace = SetLeftColumnColours(rightSideFace, belowColours, true);
                        cube.DownFace = SetLeftColumnColours(belowFace, leftSideColours, false);
                        cube.BackFace = SetRightColumnColours(leftSideFace, aboveColours, false);
                    }

                    break;
                }
                case Command.RightClockwise:
                case Command.RightCounterclockwise:
                {
                    cube.RightFace = RotateMovingFace(cube.RightFace, isClockwise);
                    var aboveFace = cube.UpFace;
                    var rightSideFace = cube.BackFace;
                    var belowFace = cube.DownFace;
                    var leftSideFace = cube.FrontFace;
                    var aboveColours = GetRightColumnColours(aboveFace);
                    var rightSideColours = GetLeftColumnColours(rightSideFace);
                    var belowColours = GetRightColumnColours(belowFace);
                    var leftSideColours = GetRightColumnColours(leftSideFace);

                    if (isClockwise)
                    {
                        cube.UpFace = SetRightColumnColours(aboveFace, leftSideColours, true);
                        cube.BackFace = SetLeftColumnColours(rightSideFace, aboveColours, false);
                        cube.DownFace = SetRightColumnColours(belowFace, rightSideColours, false);
                        cube.FrontFace = SetRightColumnColours(leftSideFace, belowColours, true);
                    }
                    else
                    {
                        cube.UpFace = SetRightColumnColours(aboveFace, rightSideColours, false);
                        cube.BackFace = SetLeftColumnColours(rightSideFace, belowColours, false);
                        cube.DownFace = SetRightColumnColours(belowFace, leftSideColours, true);
                        cube.FrontFace = SetRightColumnColours(leftSideFace, aboveColours, true);
                    }

                    break;
                }
                default:
                    throw new ArgumentException("Command not valid");
            }

            return cube;
        }

        private List<Colour> GetTopRowColours(Face face)
        {
            return new List<Colour>
            {
                face.TopLeft,
                face.TopCenter,
                face.TopRight
            };
        }

        private List<Colour> GetRightColumnColours(Face face)
        {
            return new List<Colour>
            {
                face.TopRight,
                face.MiddleRight,
                face.BottomRight
            };
        }

        private List<Colour> GetBottomRowColours(Face face)
        {
            return new List<Colour>
            {
                face.BottomLeft,
                face.BottomCenter,
                face.BottomRight
            };
        }

        private List<Colour> GetLeftColumnColours(Face face)
        {
            return new List<Colour>
            {
                face.TopLeft,
                face.MiddleLeft,
                face.BottomLeft
            };
        }

        private Face SetTopRowColours(Face face, List<Colour> colours, bool isClockwise)
        {
            if (isClockwise)
            {
                colours.Reverse();
            }

            face.TopLeft = colours[0];
            face.TopCenter = colours[1];
            face.TopRight = colours[2];

            return face;
        }

        private Face SetRightColumnColours(Face face, List<Colour> colours, bool isClockwise)
        {
            if (!isClockwise)
            {
                colours.Reverse();
            }

            face.TopRight = colours[0];
            face.MiddleRight = colours[1];
            face.BottomRight = colours[2];

            return face;
        }

        private Face SetBottomRowColours(Face face, List<Colour> colours, bool isClockwise)
        {
            if (isClockwise)
            {
                colours.Reverse();
            }

            face.BottomLeft = colours[0];
            face.BottomCenter = colours[1];
            face.BottomRight = colours[2];

            return face;
        }

        private Face SetLeftColumnColours(Face face, List<Colour> colours, bool isClockwise)
        {
            if (!isClockwise)
            {
                colours.Reverse();
            }

            face.TopLeft = colours[0];
            face.MiddleLeft = colours[1];
            face.BottomLeft = colours[2];

            return face;
        }

        private Face RotateMovingFace(Face face, bool isClockwise)
        {
            var rotatingTopLeft = face.TopLeft;
            var rotatingTopCenter = face.TopCenter;
            var rotatingTopRight = face.TopRight;
            var rotatingMiddleLeft = face.MiddleLeft;
            var rotatingMiddleRight = face.MiddleRight;
            var rotatingBottomLeft = face.BottomLeft;
            var rotatingBottomCenter = face.BottomCenter;
            var rotatingBottomRight = face.BottomRight;

            if (isClockwise)
            {
                face.TopLeft = rotatingBottomLeft;
                face.TopCenter = rotatingMiddleLeft;
                face.TopRight = rotatingTopLeft;
                face.MiddleLeft = rotatingBottomCenter;
                face.MiddleRight = rotatingTopCenter;
                face.BottomLeft = rotatingBottomRight;
                face.BottomCenter = rotatingMiddleRight;
                face.BottomRight = rotatingTopRight;
            }
            else
            {
                face.TopLeft = rotatingTopRight;
                face.TopCenter = rotatingMiddleRight;
                face.TopRight = rotatingBottomRight;
                face.MiddleLeft = rotatingTopCenter;
                face.MiddleRight = rotatingBottomCenter;
                face.BottomLeft = rotatingTopLeft;
                face.BottomCenter = rotatingMiddleLeft;
                face.BottomRight = rotatingBottomLeft;
            }

            return face;
        }
    }
}
