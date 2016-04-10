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

            //Invalid moving, position of robot should not been changed.
            //Test 1
            simulator.Place(new Position(0,0), Facing.SOUTH);
            simulator.Move();
            //Robot move SOUTH from 0,0
            //expect new Position is 0,0
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            //Test 2
            simulator.Place(new Position(0, 1), Facing.WEST);
            simulator.Move();
            //Robot move WEST from 0,1
            //expect new Position is 0,0
            Assert.AreEqual(Facing.WEST, robot.Facing);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);

            //Test 3
            simulator.Place(new Position(1, 0), Facing.SOUTH);
            simulator.Move();
            //Robot move NORTH from 1,0
            //expect new Position is 1,0
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);


            //Test 4
            simulator.Place(new Position(4, 2), Facing.EAST);
            simulator.Move();
            //Robot move east from 4,2
            //expect new Position is 4,2
            Assert.AreEqual(Facing.EAST, robot.Facing);
            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);

            //Test 5
            simulator.Place(new Position(3, 5), Facing.NORTH);
            simulator.Move();
            //Robot move south from 3,5
            //expect new Position is 3,5
            Assert.AreEqual(Facing.NORTH, robot.Facing);
            Assert.AreEqual(3, robot.Position.X);
            Assert.AreEqual(5, robot.Position.Y);

            //Valid moving, position of robot should been changed.
            //Test 1
            simulator.Place(new Position(1, 1), Facing.EAST);
            simulator.Move();
            //Robot move east from 1,1
            //expect new Position is 2,1
            Assert.AreEqual(Facing.EAST, robot.Facing);
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);

            //Test 2
            simulator.Place(new Position(0,1), Facing.SOUTH);
            simulator.Move();
            //Robot move SOUTH from 0,1
            //expect new Position is 0,0
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            //Test 3

            simulator.Place(new Position(1,0), Facing.WEST);
            simulator.Move();
            //Robot move west from 1,0
            //expect new Position is 0,0
            Assert.AreEqual(Facing.WEST, robot.Facing);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            //Test 4
            simulator.Place(new Position(3, 5), Facing.EAST);
            simulator.Move();
            //Robot move east from 3,5
            //expect new Position is 4,5
            Assert.AreEqual(Facing.EAST, robot.Facing);
            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(5, robot.Position.Y);

            //Test 5
            simulator.Place(new Position(4,4), Facing.NORTH);
            simulator.Move();
            //Robot move NORTH from 4,4
            //expect new Position is 4,5
            Assert.AreEqual(Facing.NORTH, robot.Facing);
            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(5, robot.Position.Y);

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

            Facing defaultFacing = robot.Facing;
            simulator.TurnLeft();
            Assert.AreEqual(defaultFacing, robot.Facing);
            Assert.IsNull(robot.Position);


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

            Facing defaultFacing = robot.Facing;
            simulator.TurnRight();
            Assert.AreEqual(defaultFacing, robot.Facing);
            Assert.IsNull(robot.Position);

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

            
            string result = simulator.Report();
            Assert.IsNull( result);
            Assert.IsNull(robot.Position);


            simulator.Place(new Position(3, 3), Facing.EAST);

            result = simulator.Report();
            Assert.AreEqual("Output: 3,3,EAST", result);
        }
    }
}