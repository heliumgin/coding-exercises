namespace RubiksCubeMover.Models
{
    using Enums;

    public class Cube
    {
        public Cube()
        {
            // TODO: Allow user to specify starting colour for each face (via args).
            FrontFace = new Face(Colour.Green);
            BackFace = new Face(Colour.Blue);
            UpFace = new Face(Colour.White);
            DownFace = new Face(Colour.Yellow);
            LeftFace = new Face(Colour.Orange);
            RightFace = new Face(Colour.Red);
        }

        public Face FrontFace { get; set; }

        public Face BackFace { get; set; }

        public Face UpFace { get; set; }

        public Face DownFace { get; set; }

        public Face LeftFace { get; set; }

        public Face RightFace { get; set; }
    }
}