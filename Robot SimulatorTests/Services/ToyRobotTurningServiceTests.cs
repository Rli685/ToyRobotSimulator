using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot_Simulator.Enums;
using Robot_Simulator.Models;
using Robot_Simulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator.Services.Tests
{
    [TestClass()]
    public class ToyRobotTurningServiceTests
    {


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TurnLeftTest_ArgumentNullException()
        {
            ToyRobotTurningService turningService = new ToyRobotTurningService();
            Robot robot = null;
            turningService.TurnLeft(robot);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TurnRightTest_ArgumentNullException()
        {
            ToyRobotTurningService turningService = new ToyRobotTurningService();
            Robot robot = null;
            turningService.TurnRight(robot);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TurnLeftTest_ArgumentException()
        {
            ToyRobotTurningService turningService = new ToyRobotTurningService();
            Robot robot = new Robot();
            turningService.TurnLeft(robot);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TurnRightTest_ArgumentException()
        {
            ToyRobotTurningService turningService = new ToyRobotTurningService();
            Robot robot = new Robot();
            turningService.TurnRight(robot);
        }



        [TestMethod()]
        public void TurnLeftTest()
        {
            ToyRobotTurningService turningService = new ToyRobotTurningService();
            Robot robot = new Robot();

            Position position = new Position(3, 1);
            Facing facing = Facing.NORTH;
            robot.Position = position;
            robot.Facing = facing;

            turningService.TurnLeft(robot);
            Assert.AreEqual(Facing.WEST, robot.Facing);

            turningService.TurnLeft(robot);
            Assert.AreEqual(Facing.SOUTH, robot.Facing);

            turningService.TurnLeft(robot);
            Assert.AreEqual(Facing.EAST, robot.Facing);

            turningService.TurnLeft(robot);
            Assert.AreEqual(Facing.NORTH, robot.Facing);

            Assert.AreEqual(3, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);
        }

        [TestMethod()]
        public void TurnRightTest()
        {
            ToyRobotTurningService turningService = new ToyRobotTurningService();
            Robot robot = new Robot();

            Position position = new Position(3, 1);
            Facing facing = Facing.NORTH;
            robot.Position = position;
            robot.Facing = facing;

            turningService.TurnRight(robot);
            Assert.AreEqual(Facing.EAST, robot.Facing);

            turningService.TurnRight(robot);
            Assert.AreEqual(Facing.SOUTH, robot.Facing);

            turningService.TurnRight(robot);
            Assert.AreEqual(Facing.WEST, robot.Facing);

            turningService.TurnRight(robot);
            Assert.AreEqual(Facing.NORTH, robot.Facing);

            Assert.AreEqual(3, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);
        }
        
    }
}