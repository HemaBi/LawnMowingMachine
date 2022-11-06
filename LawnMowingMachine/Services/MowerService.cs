using LawnMowingMachine.Interfaces;
using LawnMowingMachine.Models;
using System.Threading;

namespace LawnMowingMachine.Services
{
    public class MowerService : IMowerService
    {
        public MowerModel MoveUp(MowerModel mowerModel)
        {
            //mower moves up by one
            mowerModel.PositionY++;

            //mower does not go beyond the lawn (height)
            mowerModel.ValidatePositionY();

            Thread.Sleep(5);

            //get current status of mower position
            mowerModel.Status = $"mower orientation is north and current position of mower is {mowerModel.PositionX} and {mowerModel.PositionY}";

            return mowerModel;
        }

        public MowerModel MoveDown(MowerModel mowerModel)
        {
            // mower moves down by one
            mowerModel.PositionY--;

            //mower does not go beyond the lawn (height)
            mowerModel.ValidatePositionY();

            Thread.Sleep(5);

            //get current status of mower position
            mowerModel.Status = $"mower orientation is south and current position of mower is {mowerModel.PositionX} and {mowerModel.PositionY}";

            return mowerModel;
        }

        public MowerModel MoveLeft(MowerModel mowerModel)
        {
            //mower moves left by one
            mowerModel.PositionX--;

            //mower does not go beyond the lawn (width)
            mowerModel.ValidatePositionX();

            Thread.Sleep(2);

            //get current status of mower position
            mowerModel.Status = $"mower orientation is west and current position of mower is {mowerModel.PositionX} and {mowerModel.PositionY}";

            return mowerModel;
        }

        public MowerModel MoveRight(MowerModel mowerModel)
        {
            //mower moves right by one
            mowerModel.PositionX++;

            //mower does not go beyond the lawn (width)
            mowerModel.ValidatePositionX();

            Thread.Sleep(2);

            //get current status of mower position
            mowerModel.Status = $"mower orientation is east and current position of mower is {mowerModel.PositionX} and {mowerModel.PositionY}";

            return mowerModel;
        }
    }
}