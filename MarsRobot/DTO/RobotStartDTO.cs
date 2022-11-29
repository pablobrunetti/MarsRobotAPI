using FluentValidation.Results;
using MarsRobot.Api.Validator;

namespace MarsRobot.Api.DTO
{
    public class RobotStartDTO
    {
        public string Grid { get; set; }
        public string Commands { get; set; }
    }
}
