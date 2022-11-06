using LawnMowingMachine.Interfaces;
using LawnMowingMachine.Models;
using Microsoft.AspNetCore.Mvc;

namespace LawnMowingMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawnMowerController : ControllerBase
    {
        private readonly IMowerService _mowerService;

        public LawnMowerController(IMowerService mowerService)
        {
            _mowerService = mowerService;
        }

        [HttpPost, Route("MoveUp")]
        public IActionResult MoveUp(MowerModel mowerModel)
        {
            return new JsonResult(_mowerService.MoveUp(mowerModel));
        }

        [HttpPost, Route("MoveDown")]
        public IActionResult MoveDown(MowerModel mowerModel)
        {
            return new JsonResult(_mowerService.MoveDown(mowerModel));
        }

        [HttpPost, Route("MoveLeft")]
        public IActionResult MoveLeft(MowerModel mowerModel)
        {
            return new JsonResult(_mowerService.MoveLeft(mowerModel));
        }

        [HttpPost, Route("MoveRight")]
        public IActionResult MoveRight(MowerModel mowerModel)
        {
            return new JsonResult(_mowerService.MoveRight(mowerModel));
        }
    }
}
