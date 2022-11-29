using FluentValidation;
using MarsRobot.Api.Controllers;
using MarsRobot.Api.DTO;
using MarsRobot.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MarsRobot.Test
{
    public class MarsRobotTest
    {
        private readonly RobotContext _context;
        private readonly IValidator<RobotStartDTO> _validator;

        public MarsRobotTest(RobotContext context,
            IValidator<RobotStartDTO> validator)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _validator = validator;

        }
        [Fact]
        public async Task ValidateInputGrid()
        {
            var robotDTO = new RobotStartDTO();
            robotDTO.Grid = "0x0";
            robotDTO.Commands = "L";
            Console.WriteLine(robotDTO);
            var validation = await _validator.ValidateAsync(robotDTO);
            Assert.False(validation.IsValid, $"Mars plateau invalid");

        }

    }
}