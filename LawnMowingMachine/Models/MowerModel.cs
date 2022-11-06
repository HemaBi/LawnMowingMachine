using System;

namespace LawnMowingMachine.Models
{
    public class MowerModel
    {
        private const int minimumWidth = 0;
        private const int minimumHeight = 0;

        public MowerModel(int positionX, int positionY, LawnDimension lawnDimension)
        {
            if (positionX < 0)
            {
                throw new ArgumentException("x axis position is negative number");
            }

            if (positionY < 0)
            {
                throw new ArgumentException("y axis position is negative number");
            }

            if (lawnDimension == null)
            {
                throw new ArgumentException("lawn dimension is null");
            }

            PositionX = positionX;
            PositionY = positionY;

            LawnDimension = lawnDimension;
        }

        public LawnDimension LawnDimension { get; set; }

        //for width (left and right)
        public int PositionX { get; set; }

        //for height (up and down)
        public int PositionY { get; set; }

        public string Status { get; set; }

        public void ValidatePositionX()
        {
            if (PositionX < minimumWidth)
            {
                PositionX = minimumWidth;
            }
            else if (PositionX > LawnDimension.Width)
            {
                PositionX = LawnDimension.Width;
            }
        }

        public void ValidatePositionY()
        {
            if (PositionY < minimumHeight)
            {
                PositionY = minimumHeight;
            }
            else if (PositionX > LawnDimension.Height)
            {
                PositionY = LawnDimension.Height;
            }
        }
    }
}
