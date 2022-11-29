using FluentValidation;
using MarsRobot.Api.DTO;
using MarsRobot.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarsRobot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsRobotController : ControllerBase
    {
        private readonly RobotContext _context;
        private readonly IValidator<RobotStartDTO> _validator;

     

        public MarsRobotController(RobotContext context, 
            IValidator<RobotStartDTO> validator)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _validator = validator; 

        }
        [HttpGet]
        public async Task<ActionResult> GetResultAll()
        {
            return Ok(await _context.Robots.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetResult(int id)
        {
            var result = await _context.Robots.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> TaskRobotPost([FromBody] RobotStartDTO roboStart)
        {
            var validation = await _validator.ValidateAsync(roboStart);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors?.Select(e => new ValidationResult()
                {
                    Code = e.ErrorCode,
                    PropertyName = e.PropertyName,
                    Message = e.ErrorMessage
                }));
            }
            char[] commands = roboStart.Commands.ToCharArray();
            List<string> grid = new List<string>(roboStart.Grid.ToUpper().Split("X"));
            Robot robot = new Robot(Int32.Parse(grid[0]), Int32.Parse(grid[1]));
            foreach(char c in commands)
            {
                if(c == 'L')
                {
                    robot.TurnLeft(robot, robot.facing);
                }
                if(c == 'R')
                {
                    robot.TurnRight(robot, robot.facing);
                }
                if(c == 'F')
                {
                    robot.MoveForwardFacingDirection(robot);
                }
            }
            _context.Robots.Add(robot);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                "GetResult",
                new { id = robot.Id },
                robot);
        }
    }
}
