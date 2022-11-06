using Microsoft.Extensions.Configuration;
using System;

namespace LawnMowingMachine.Models
{
    public class LawnDimension
    {
        public int Width { get; }
        public int Height { get; }

        public LawnDimension(IConfiguration configuration)
        {
            Width = Convert.ToInt32(configuration["LawnWidth"]);
            Height = Convert.ToInt32(configuration["LawnHeight"]);
        }
    }
}
