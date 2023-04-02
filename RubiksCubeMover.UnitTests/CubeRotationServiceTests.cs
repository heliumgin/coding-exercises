using System.Drawing;

namespace RubiksCubeMover.UnitTests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Enums;
    using Models;
    using Services;

    [TestClass]
    public class CubeRotationServiceTests
    {
        private CubeRotationService _sut;
        private Cube _cube;

        [TestInitialize]
        public void Initialise()
        {
            _sut = new CubeRotationService();
            _cube = new Cube
            {
                FrontFace = new Face(Colour.White, Colour.Blue, Colour.Blue, Colour.Orange, Colour.White, Colour.Green, Colour.Blue, Colour.Yellow, Colour.Red),
                BackFace = new Face(Colour.Yellow, Colour.Green, Colour.Yellow, Colour.Red, Colour.Yellow, Colour.Orange, Colour.Red, Colour.Blue, Colour.White),
                UpFace = new Face(Colour.Red, Colour.Yellow, Colour.Green, Colour.Blue, Colour.Green, Colour.Blue, Colour.Orange, Colour.Orange, Colour.White),
                DownFace = new Face(Colour.Orange, Colour.Red, Colour.Green, Colour.Green, Colour.Blue, Colour.Red, Colour.Red, Colour.Yellow, Colour.Green),
                LeftFace = new Face(Colour.Blue, Colour.White, Colour.Green, Colour.Yellow, Colour.Red, Colour.White, Colour.Blue, Colour.White, Colour.Yellow),
                RightFace = new Face(Colour.Orange, Colour.Red, Colour.Orange, Colour.Orange, Colour.Orange, Colour.Green, Colour.Yellow, Colour.White, Colour.White)
            };
        }

        private void AssertCubesMatch(Cube expectedCube, Cube actualCube)
        {
            var isFrontFaceCorrect = expectedCube.FrontFace.GetAllFaceColours().SequenceEqual(actualCube.FrontFace.GetAllFaceColours());
            var isBackFaceCorrect = expectedCube.BackFace.GetAllFaceColours().SequenceEqual(actualCube.BackFace.GetAllFaceColours());
            var isUpFaceCorrect = expectedCube.UpFace.GetAllFaceColours().SequenceEqual(actualCube.UpFace.GetAllFaceColours());
            var isDownFaceCorrect = expectedCube.DownFace.GetAllFaceColours().SequenceEqual(actualCube.DownFace.GetAllFaceColours());
            var isLeftFaceCorrect = expectedCube.LeftFace.GetAllFaceColours().SequenceEqual(actualCube.LeftFace.GetAllFaceColours());
            var isRightFaceCorrect = expectedCube.RightFace.GetAllFaceColours().SequenceEqual(actualCube.RightFace.GetAllFaceColours());
            
            Assert.IsTrue(isFrontFaceCorrect, "Front face is not correct");
            Assert.IsTrue(isBackFaceCorrect, "Back face is not correct");
            Assert.IsTrue(isUpFaceCorrect, "Up face is not correct");
            Assert.IsTrue(isDownFaceCorrect, "Down face is not correct");
            Assert.IsTrue(isLeftFaceCorrect, "Left face is not correct");
            Assert.IsTrue(isRightFaceCorrect, "Right face is not correct");
        }

        [TestMethod]
        public void Rotate_Front_Clockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.Blue, Colour.Orange, Colour.White, Colour.Yellow, Colour.White, Colour.Blue, Colour.Red, Colour.Green, Colour.Blue),
                BackFace = new Face(Colour.Yellow, Colour.Green, Colour.Yellow, Colour.Red, Colour.Yellow, Colour.Orange, Colour.Red, Colour.Blue, Colour.White),
                UpFace = new Face(Colour.Red, Colour.Yellow, Colour.Green, Colour.Blue, Colour.Green, Colour.Blue, Colour.Yellow, Colour.White, Colour.Green),
                DownFace = new Face(Colour.Yellow, Colour.Orange, Colour.Orange, Colour.Green, Colour.Blue, Colour.Red, Colour.Red, Colour.Yellow, Colour.Green),
                LeftFace = new Face(Colour.Blue, Colour.White, Colour.Orange, Colour.Yellow, Colour.Red, Colour.Red, Colour.Blue, Colour.White, Colour.Green),
                RightFace = new Face(Colour.Orange, Colour.Red, Colour.Orange, Colour.Orange, Colour.Orange, Colour.Green, Colour.White, Colour.White, Colour.White)
            };

            var cubeResult = _sut.Rotate(_cube, Command.FrontClockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Front_Counterclockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.Blue, Colour.Green, Colour.Red, Colour.Blue, Colour.White, Colour.Yellow, Colour.White, Colour.Orange, Colour.Blue),
                BackFace = new Face(Colour.Yellow, Colour.Green, Colour.Yellow, Colour.Red, Colour.Yellow, Colour.Orange, Colour.Red, Colour.Blue, Colour.White),
                UpFace = new Face(Colour.Red, Colour.Yellow, Colour.Green, Colour.Blue, Colour.Green, Colour.Blue, Colour.Orange, Colour.Orange, Colour.Yellow),
                DownFace = new Face(Colour.Green, Colour.White, Colour.Yellow, Colour.Green, Colour.Blue, Colour.Red, Colour.Red, Colour.Yellow, Colour.Green),
                LeftFace = new Face(Colour.Blue, Colour.White, Colour.White, Colour.Yellow, Colour.Red, Colour.Orange, Colour.Blue, Colour.White, Colour.Orange),
                RightFace = new Face(Colour.Green, Colour.Red, Colour.Orange, Colour.Red, Colour.Orange, Colour.Green, Colour.Orange, Colour.White, Colour.White)
            };

            var cubeResult = _sut.Rotate(_cube, Command.FrontCounterclockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Back_Clockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.White, Colour.Blue, Colour.Blue, Colour.Orange, Colour.White, Colour.Green, Colour.Blue, Colour.Yellow, Colour.Red),
                BackFace = new Face(Colour.Red, Colour.Red, Colour.Yellow, Colour.Blue, Colour.Yellow, Colour.Green, Colour.White, Colour.Orange, Colour.Yellow),
                UpFace = new Face(Colour.Orange, Colour.Green, Colour.White, Colour.Blue, Colour.Green, Colour.Blue, Colour.Orange, Colour.Orange, Colour.White),
                DownFace = new Face(Colour.Orange, Colour.Red, Colour.Green, Colour.Green, Colour.Blue, Colour.Red, Colour.Blue, Colour.Yellow, Colour.Blue),
                LeftFace = new Face(Colour.Green, Colour.White, Colour.Green, Colour.Yellow, Colour.Red, Colour.White, Colour.Red, Colour.White, Colour.Yellow),
                RightFace = new Face(Colour.Orange, Colour.Red, Colour.Green, Colour.Orange, Colour.Orange, Colour.Yellow, Colour.Yellow, Colour.White, Colour.Red)
            };

            var cubeResult = _sut.Rotate(_cube, Command.BackClockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Back_Counterclockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.White, Colour.Blue, Colour.Blue, Colour.Orange, Colour.White, Colour.Green, Colour.Blue, Colour.Yellow, Colour.Red),
                BackFace = new Face(Colour.Yellow, Colour.Orange, Colour.White, Colour.Green, Colour.Yellow, Colour.Blue, Colour.Yellow, Colour.Red, Colour.Red),
                UpFace = new Face(Colour.Blue, Colour.Yellow, Colour.Blue, Colour.Blue, Colour.Green, Colour.Blue, Colour.Orange, Colour.Orange, Colour.White),
                DownFace = new Face(Colour.Orange, Colour.Red, Colour.Green, Colour.Green, Colour.Blue, Colour.Red, Colour.White, Colour.Green, Colour.Orange),
                LeftFace = new Face(Colour.Red, Colour.White, Colour.Green, Colour.Yellow, Colour.Red, Colour.White, Colour.Green, Colour.White, Colour.Yellow),
                RightFace = new Face(Colour.Orange, Colour.Red, Colour.Red, Colour.Orange, Colour.Orange, Colour.Yellow, Colour.Yellow, Colour.White, Colour.Green)
            };

            var cubeResult = _sut.Rotate(_cube, Command.BackCounterclockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Up_Clockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.Orange, Colour.Red, Colour.Orange, Colour.Orange, Colour.White, Colour.Green, Colour.Blue, Colour.Yellow, Colour.Red),
                BackFace = new Face(Colour.Blue, Colour.White, Colour.Green, Colour.Red, Colour.Yellow, Colour.Orange, Colour.Red, Colour.Blue, Colour.White),
                UpFace = new Face(Colour.Orange, Colour.Blue, Colour.Red, Colour.Orange, Colour.Green, Colour.Yellow, Colour.White, Colour.Blue, Colour.Green),
                DownFace = new Face(Colour.Orange, Colour.Red, Colour.Green, Colour.Green, Colour.Blue, Colour.Red, Colour.Red, Colour.Yellow, Colour.Green),
                LeftFace = new Face(Colour.White, Colour.Blue, Colour.Blue, Colour.Yellow, Colour.Red, Colour.White, Colour.Blue, Colour.White, Colour.Yellow),
                RightFace = new Face(Colour.Yellow, Colour.Green, Colour.Yellow, Colour.Orange, Colour.Orange, Colour.Green, Colour.Yellow, Colour.White, Colour.White)
            };

            var cubeResult = _sut.Rotate(_cube, Command.UpClockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Up_Counterclockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.Blue, Colour.White, Colour.Green, Colour.Orange, Colour.White, Colour.Green, Colour.Blue, Colour.Yellow, Colour.Red),
                BackFace = new Face(Colour.Orange, Colour.Red, Colour.Orange, Colour.Red, Colour.Yellow, Colour.Orange, Colour.Red, Colour.Blue, Colour.White),
                UpFace = new Face(Colour.Green, Colour.Blue, Colour.White, Colour.Yellow, Colour.Green, Colour.Orange, Colour.Red, Colour.Blue, Colour.Orange),
                DownFace = new Face(Colour.Orange, Colour.Red, Colour.Green, Colour.Green, Colour.Blue, Colour.Red, Colour.Red, Colour.Yellow, Colour.Green),
                LeftFace = new Face(Colour.Yellow, Colour.Green, Colour.Yellow, Colour.Yellow, Colour.Red, Colour.White, Colour.Blue, Colour.White, Colour.Yellow),
                RightFace = new Face(Colour.White, Colour.Blue, Colour.Blue, Colour.Orange, Colour.Orange, Colour.Green, Colour.Yellow, Colour.White, Colour.White)
            };

            var cubeResult = _sut.Rotate(_cube, Command.UpCounterclockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Down_Clockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.White, Colour.Blue, Colour.Blue, Colour.Orange, Colour.White, Colour.Green, Colour.Blue, Colour.White, Colour.Yellow),
                BackFace = new Face(Colour.Yellow, Colour.Green, Colour.Yellow, Colour.Red, Colour.Yellow, Colour.Orange, Colour.Yellow, Colour.White, Colour.White),
                UpFace = new Face(Colour.Red, Colour.Yellow, Colour.Green, Colour.Blue, Colour.Green, Colour.Blue, Colour.Orange, Colour.Orange, Colour.White),
                DownFace = new Face(Colour.Red, Colour.Green, Colour.Orange, Colour.Yellow, Colour.Blue, Colour.Red, Colour.Green, Colour.Red, Colour.Green),
                LeftFace = new Face(Colour.Blue, Colour.White, Colour.Green, Colour.Yellow, Colour.Red, Colour.White, Colour.Red, Colour.Blue, Colour.White),
                RightFace = new Face(Colour.Orange, Colour.Red, Colour.Orange, Colour.Orange, Colour.Orange, Colour.Green, Colour.Blue, Colour.Yellow, Colour.Red)
            };

            var cubeResult = _sut.Rotate(_cube, Command.DownClockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Down_Counterclockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.White, Colour.Blue, Colour.Blue, Colour.Orange, Colour.White, Colour.Green, Colour.Yellow, Colour.White, Colour.White),
                BackFace = new Face(Colour.Yellow, Colour.Green, Colour.Yellow, Colour.Red, Colour.Yellow, Colour.Orange, Colour.Blue, Colour.White, Colour.Yellow),
                UpFace = new Face(Colour.Red, Colour.Yellow, Colour.Green, Colour.Blue, Colour.Green, Colour.Blue, Colour.Orange, Colour.Orange, Colour.White),
                DownFace = new Face(Colour.Green, Colour.Red, Colour.Green, Colour.Red, Colour.Blue, Colour.Yellow, Colour.Orange, Colour.Green, Colour.Red),
                LeftFace = new Face(Colour.Blue, Colour.White, Colour.Green, Colour.Yellow, Colour.Red, Colour.White, Colour.Blue, Colour.Yellow, Colour.Red),
                RightFace = new Face(Colour.Orange, Colour.Red, Colour.Orange, Colour.Orange, Colour.Orange, Colour.Green, Colour.Red, Colour.Blue, Colour.White)
            };

            var cubeResult = _sut.Rotate(_cube, Command.DownCounterclockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Left_Clockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.Red, Colour.Blue, Colour.Blue, Colour.Blue, Colour.White, Colour.Green, Colour.Orange, Colour.Yellow, Colour.Red),
                BackFace = new Face(Colour.Yellow, Colour.Green, Colour.Red, Colour.Red, Colour.Yellow, Colour.Green, Colour.Red, Colour.Blue, Colour.Orange),
                UpFace = new Face(Colour.White, Colour.Yellow, Colour.Green, Colour.Orange, Colour.Green, Colour.Blue, Colour.Yellow, Colour.Orange, Colour.White),
                DownFace = new Face(Colour.White, Colour.Red, Colour.Green, Colour.Orange, Colour.Blue, Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green),
                LeftFace = new Face(Colour.Blue, Colour.Yellow, Colour.Blue, Colour.White, Colour.Red, Colour.White, Colour.Yellow, Colour.White, Colour.Green),
                RightFace = new Face(Colour.Orange, Colour.Red, Colour.Orange, Colour.Orange, Colour.Orange, Colour.Green, Colour.Yellow, Colour.White, Colour.White)
            };

            var cubeResult = _sut.Rotate(_cube, Command.LeftClockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Left_Counterclockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.Orange, Colour.Blue, Colour.Blue, Colour.Green, Colour.White, Colour.Green, Colour.Red, Colour.Yellow, Colour.Red),
                BackFace = new Face(Colour.Yellow, Colour.Green, Colour.Orange, Colour.Red, Colour.Yellow, Colour.Blue, Colour.Red, Colour.Blue, Colour.Red),
                UpFace = new Face(Colour.White, Colour.Yellow, Colour.Green, Colour.Orange, Colour.Green, Colour.Blue, Colour.Blue, Colour.Orange, Colour.White),
                DownFace = new Face(Colour.White, Colour.Red, Colour.Green, Colour.Orange, Colour.Blue, Colour.Red, Colour.Yellow, Colour.Yellow, Colour.Green),
                LeftFace = new Face(Colour.Green, Colour.White, Colour.Yellow, Colour.White, Colour.Red, Colour.White, Colour.Blue, Colour.Yellow, Colour.Blue),
                RightFace = new Face(Colour.Orange, Colour.Red, Colour.Orange, Colour.Orange, Colour.Orange, Colour.Green, Colour.Yellow, Colour.White, Colour.White)
            };

            var cubeResult = _sut.Rotate(_cube, Command.LeftCounterclockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Right_Clockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.White, Colour.Blue, Colour.Green, Colour.Orange, Colour.White, Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green),
                BackFace = new Face(Colour.White, Colour.Green, Colour.Yellow, Colour.Blue, Colour.Yellow, Colour.Orange, Colour.Green, Colour.Blue, Colour.White),
                UpFace = new Face(Colour.Red, Colour.Yellow, Colour.Blue, Colour.Blue, Colour.Green, Colour.Green, Colour.Orange, Colour.Orange, Colour.Red),
                DownFace = new Face(Colour.Orange, Colour.Red, Colour.Red, Colour.Green, Colour.Blue, Colour.Red, Colour.Red, Colour.Yellow, Colour.Yellow),
                LeftFace = new Face(Colour.Blue, Colour.White, Colour.Green, Colour.Yellow, Colour.Red, Colour.White, Colour.Blue, Colour.White, Colour.Yellow),
                RightFace = new Face(Colour.Yellow, Colour.Orange, Colour.Orange, Colour.White, Colour.Orange, Colour.Red, Colour.White, Colour.Green, Colour.Orange)
            };

            var cubeResult = _sut.Rotate(_cube, Command.RightClockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_Right_Counterclockwise_Success()
        {
            var expectedCube = new Cube
            {
                FrontFace = new Face(Colour.White, Colour.Blue, Colour.Green, Colour.Orange, Colour.White, Colour.Blue, Colour.Blue, Colour.Yellow, Colour.White),
                BackFace = new Face(Colour.Green, Colour.Green, Colour.Yellow, Colour.Red, Colour.Yellow, Colour.Orange, Colour.Green, Colour.Blue, Colour.White),
                UpFace = new Face(Colour.Red, Colour.Yellow, Colour.Red, Colour.Blue, Colour.Green, Colour.Red, Colour.Orange, Colour.Orange, Colour.Yellow),
                DownFace = new Face(Colour.Orange, Colour.Red, Colour.Blue, Colour.Green, Colour.Blue, Colour.Green, Colour.Red, Colour.Yellow, Colour.Red),
                LeftFace = new Face(Colour.Blue, Colour.White, Colour.Green, Colour.Yellow, Colour.Red, Colour.White, Colour.Blue, Colour.White, Colour.Yellow),
                RightFace = new Face(Colour.Orange, Colour.Green, Colour.White, Colour.Red, Colour.Orange, Colour.White, Colour.Orange, Colour.Orange, Colour.Yellow)
            };

            var cubeResult = _sut.Rotate(_cube, Command.RightCounterclockwise);

            AssertCubesMatch(expectedCube, cubeResult);
        }

        [TestMethod]
        public void Rotate_InvalidCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => _sut.Rotate(_cube, (Command)10), "Command not valid");
        }
    }
}