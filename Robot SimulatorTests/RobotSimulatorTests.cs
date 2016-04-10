using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot_Simulator;
using Robot_Simulator.Models;
using Robot_Simulator.Enums;
using Robot_Simulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator.Tests
{
    [TestClass()]
    public class RobotSimulatorTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RobotSimulatorTest_ArgumentNullException_1()
        {
            Robot robot = null;
            TableTop table = new TableTop(5, 6);
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RobotSimulatorTest_ArgumentNullException_2()
        {
            Robot robot = new Robot();
            TableTop table = null;
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RobotSimulatorTest_ArgumentNullException_3()
        {
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);
            IRobotMovingService movingService = null;
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RobotSimulatorTest_ArgumentNullException_4()
        {
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = null;
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RobotSimulatorTest_ArgumentNullException_5()
        {
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = null;

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);
        }

        [TestMethod()]
        public void MoveTest()
        {
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);

            simulator.Move();
            Assert.IsNull(robot.Position);

            simulator.Place(new Position(3, 3), Facing.EAST);
            simulator.Move();

            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
            Assert.AreEqual(Facing.EAST, robot.Facing);



        }

        [TestMethod()]
        public void PlaceTest()
        {
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);

            bool result = simulator.Place(new Position(7, 7), Facing.EAST);
            Assert.IsNull(robot.Position);
            Assert.IsFalse(result);

            result = simulator.Place(new Position(3, 3), Facing.EAST);
            Assert.IsTrue(result);
            Assert.AreEqual(3, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
            Assert.AreEqual(Facing.EAST, robot.Facing);
        }

        [TestMethod()]
        public void TurnLeftTest()
        {
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);
            simulator.Place(new Position(3, 3), Facing.EAST);

            simulator.TurnLeft();
            Assert.AreEqual(3, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
            Assert.AreEqual(Facing.NORTH, robot.Facing);
        }

        [TestMethod()]
        public void TurnRightTest()
        {
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);
            simulator.Place(new Position(3, 3), Facing.EAST);

            simulator.TurnRight();
            Assert.AreEqual(3, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
            Assert.AreEqual(Facing.SOUTH, robot.Facing);

        }

        [TestMethod()]
        public void ReportTest()
        {
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);
            simulator.Place(new Position(3, 3), Facing.EAST);

            string result = simulator.Report();
            Assert.AreEqual("Output: 3,3,EAST", result);
        }
    }
}