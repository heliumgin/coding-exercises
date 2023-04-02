namespace RubiksCubeMover.Models
{
    using System.Collections.Generic;

    using Enums;

    public class Face
    {
        public Face(Colour colour)
        {
            TopLeft = colour;
            TopCenter = colour;
            TopRight = colour;
            MiddleLeft = colour;
            MiddleCenter = colour;
            MiddleRight = colour;
            BottomLeft = colour;
            BottomCenter = colour;
            BottomRight = colour;
        }
        public Face(Colour topLeftColour, Colour topCenterColour, Colour topRightColour,
            Colour middleLeftColour, Colour middleCenterColour, Colour middleRightColour,
            Colour bottomLeftColour, Colour bottomCenterColour, Colour bottomRightColour)
        {
            TopLeft = topLeftColour;
            TopCenter = topCenterColour;
            TopRight = topRightColour;
            MiddleLeft = middleLeftColour;
            MiddleCenter = middleCenterColour;
            MiddleRight = middleRightColour;
            BottomLeft = bottomLeftColour;
            BottomCenter = bottomCenterColour;
            BottomRight = bottomRightColour;
        }

        public Colour TopLeft { get; set; }

        public Colour TopCenter { get; set; }

        public Colour TopRight { get; set; }

        public Colour MiddleLeft { get; set; }

        public Colour MiddleCenter { get; set; }

        public Colour MiddleRight { get; set; }

        public Colour BottomLeft { get; set; }

        public Colour BottomCenter { get; set; }

        public Colour BottomRight { get; set; }

        public List<Colour> GetAllFaceColours()
        {
            return new List<Colour>
            {
                TopLeft,
                TopCenter,
                TopRight,
                MiddleLeft,
                MiddleCenter,
                MiddleRight,
                BottomLeft,
                BottomCenter,
                BottomRight
            };
        }

        public List<Colour> GetTopRowFaceColours()
        {
            return new List<Colour>
            {
                TopLeft,
                TopCenter,
                TopRight
            };
        }

        public List<Colour> GetMiddleRowFaceColours()
        {
            return new List<Colour>
            {
                MiddleLeft,
                MiddleCenter,
                MiddleRight
            };
        }

        public List<Colour> GetBottomRowFaceColours()
        {
            return new List<Colour>
            {
                BottomLeft,
                BottomCenter,
                BottomRight
            };
        }
    }
}
