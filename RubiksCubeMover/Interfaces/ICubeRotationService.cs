namespace RubiksCubeMover.Interfaces
{
    using Enums;
    using Models;

    public interface ICubeRotationService
    {
        Cube Rotate(Cube cube, Command command);
    }
}