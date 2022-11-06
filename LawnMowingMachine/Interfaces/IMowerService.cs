using LawnMowingMachine.Models;

namespace LawnMowingMachine.Interfaces
{
    public interface IMowerService
    {
        MowerModel MoveUp(MowerModel mowerModel);
        MowerModel MoveDown(MowerModel mowerModel);
        MowerModel MoveLeft(MowerModel mowerModel);
        MowerModel MoveRight(MowerModel mowerModel);
    }
}
