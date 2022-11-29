using FluentValidation;
using MarsRobot.Api.DTO;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace MarsRobot.Api.Validator
{
    public class RobotStartDTOValidation: AbstractValidator<RobotStartDTO>
    {
        public RobotStartDTOValidation()
        {
            ValidateGrid();
            ValidateCommands();
        }
        private void ValidateGrid()
        {
            RuleFor(r => r.Grid)
                 .NotEmpty()
                     .WithMessage("Mars plateau is Mandatory")
                 .Matches("\\d[X | x]\\d")
                 .NotEqual("0x0")
                     .WithMessage("Mars plateau invalid");


        }
        private void ValidateCommands()
        {
            RuleFor(r => r.Commands)
                 .NotEmpty()
                     .WithMessage("Commands is Mandatory")

                  .Must(CheckCommands);
                  //.Matches("[FfRrLl]");


        }
        private bool CheckCommands(string value)
        {
            Regex rx = new Regex(@"[FfRrLl]",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(value);
            if(matches.Count == value.Count()) { 
                return true;
            }

            return false;
            
        }
    }
}
