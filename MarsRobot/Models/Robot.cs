using System.ComponentModel.DataAnnotations;

namespace MarsRobot.Api.Models
{
    public class Robot
    {
        public int Id { get; set; }
        
        //It starts always in facing North
        public string facing { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public int limitPosititionX;
        public int limitPosititionY;
    
        public Robot() { }
        public Robot(int LimitPostionX, int LimitPostionY){
            limitPosititionX = LimitPostionX;
            limitPosititionY = LimitPostionY;
            positionX = 1;
            positionY = 1;
            facing = "NORTH";
        }

        internal void TurnLeft(Robot robot, string direction)
        {
            switch (direction)
            {
                case "NORTH":
                    robot.facing = "WEST";
                    break;
                case "EAST":
                    robot.facing = "NORTH";
                    break;
                case "SOUTH":
                    robot.facing = "EAST";
                    break;
                case "WEST":
                    robot.facing = "SOUTH";
                    break;
            }
        }
        internal void TurnRight(Robot robot, string direction)
        {
            switch (direction)
            {
                case "NORTH":
                    robot.facing = "EAST";
                    break;
                case "EAST":
                    robot.facing = "SOUTH";
                    break;
                case "SOUTH":
                    robot.facing = "WEST";
                    break;
                case "WEST":
                    robot.facing = "NORTH";
                    break;
            }

        }
        internal void MoveForwardFacingDirection(Robot robot)
        {
            switch (robot.facing)
            {
                case "NORTH":
                    //If position Y is not in max limit
                    if (robot.positionY != robot.limitPosititionY)
                    {
                        robot.positionY += 1;
                    }
                    break;

                case "EAST":
                    //If position X is not in max limit
                    if (robot.positionX != robot.limitPosititionX)
                    {
                        robot.positionX += 1;
                    }
                    break;
                case "SOUTH":
                    //If position Y is not in min limit
                    if (robot.positionY != 1)
                    {
                        robot.positionY -= 1;
                    }
                    break;
                case "WEST":
                    //If position X is not in min limit
                    if (robot.positionX != 1)
                    {
                        robot.positionX -= 1;
                    }
                    break;
            }
        }

       
    }
}
