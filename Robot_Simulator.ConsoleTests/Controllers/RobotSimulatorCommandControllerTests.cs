using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot_Simulator.ConsoleUI.Controllers;
using Robot_Simulator.ConsoleUI.Models;
using Robot_Simulator.ConsoleUI.Services;
using Robot_Simulator.Enums;
using Robot_Simulator.Models;
using Robot_Simulator.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator.ConsoleUI.Controllers.Tests
{
    [TestClass()]
    public class RobotSimulatorCommandControllerTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RobotSimulatorCommandControllerTest_ArgumentNullException()
        {
            RobotSimulatorCommandController controler = new RobotSimulatorCommandController(null);
        }

        [TestMethod()]
        public void RobotSimulatorCommandControllerTest()
        {
            Robot robot = new Robot();
            TableTop table = new SquareTableTop(5);
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);
            RobotSimulatorCommandController controler = new RobotSimulatorCommandController(simulator);

            controler.Run(new Command_Left());
            controler.Run(new Command_Right());
            controler.Run(new Command_Move());
            controler.Run(new Command_Place(new Position(5,5),Facing.EAST));
            Assert.IsNull(robot.Position);

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);
            string startPoint = sb.ToString();

            controler.Run(new Command_Report());
            string middleAPoint = sb.ToString();
            Assert.AreEqual(startPoint, middleAPoint);

            controler.Run(new Command_Place(new Position(3, 3), Facing.EAST));
            Assert.AreEqual(3, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
            Assert.AreEqual(Facing.EAST, robot.Facing);

            controler.Run(new Command_Report());
            string middleBPoint = sb.ToString();
            string expectedString = "Output: 3,3,EAST" + System.Environment.NewLine;
            Assert.AreEqual(expectedString, middleBPoint);

            controler.Run(new Command_Left());
            Assert.AreEqual(Facing.NORTH, robot.Facing);
            controler.Run(new Command_Left());
            Assert.AreEqual(Facing.WEST, robot.Facing);
            controler.Run(new Command_Left());
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
            controler.Run(new Command_Left());
            Assert.AreEqual(Facing.EAST, robot.Facing);

            controler.Run(new Command_Right());
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
            controler.Run(new Command_Right());
            Assert.AreEqual(Facing.WEST, robot.Facing);
            controler.Run(new Command_Right());
            Assert.AreEqual(Facing.NORTH, robot.Facing);
            controler.Run(new Command_Right());
            Assert.AreEqual(Facing.EAST, robot.Facing);

            controler.Run(new Command_Move());
            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
            controler.Run(new Command_Move());
            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);



        }
    }
}