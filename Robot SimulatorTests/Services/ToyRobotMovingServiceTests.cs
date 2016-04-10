using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot_Simulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator.Models;
using Robot_Simulator.Enums;

namespace Robot_Simulator.Services.Tests
{
    [TestClass()]
    public class ToyRobotMovingServiceTests
    {

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MoveTest_ArgumentNullException_1()
        {
            ToyRobotMovingService movingService = new ToyRobotMovingService();
            Robot robot = null;
            TableTop table = new TableTop(5, 6);
            movingService.Move(robot, table);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MoveTest_ArgumentNullException_2()
        {
            ToyRobotMovingService movingService = new ToyRobotMovingService();
            Robot robot = new Robot();
            TableTop table = null;
            movingService.Move(robot, table);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void MoveTest_ArgumentOutOfRangeException()
        {
            ToyRobotMovingService movingService = new ToyRobotMovingService();
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);
            movingService.Move(robot, table);
        }
        
 
        //Return true if a valid Move happened.
        //also test the moving to edge 
        [TestMethod()]
        public void MoveTest_Valid()
        {
            ToyRobotMovingService movingService = new ToyRobotMovingService();
            Robot robot = new Robot(); 
            TableTop table = new TableTop(5, 6);

            //Test 1
            Position position = new Position(1, 1);
            Facing facing = Facing.EAST;
            robot.Position = position;
            robot.Facing = facing;
            bool result = movingService.Move(robot,table);
            //Robot move east from 1,1
            //expect new Position is 2,1
            Assert.AreEqual(true, result);
            Assert.AreEqual(Facing.EAST, robot.Facing);
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);

            //Test 2
            position = new Position(0, 1);
            facing = Facing.SOUTH;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Move(robot, table);
            //Robot move SOUTH from 0,1
            //expect new Position is 0,0
            Assert.AreEqual(true, result);
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            //Test 3
            position = new Position(1,0);
            facing = Facing.WEST;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Move(robot, table);
            //Robot move west from 1,0
            //expect new Position is 0,0
            Assert.AreEqual(true, result);
            Assert.AreEqual(Facing.WEST, robot.Facing);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            //Test 4
            position = new Position(3, 5);
            facing = Facing.EAST;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Move(robot, table);
            //Robot move east from 3,5
            //expect new Position is 4,5
            Assert.AreEqual(true, result);
            Assert.AreEqual(Facing.EAST, robot.Facing);
            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(5, robot.Position.Y);

            //Test 5
            position = new Position(4, 4);
            facing = Facing.NORTH;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Move(robot, table);
            //Robot move NORTH from 4,4
            //expect new Position is 4,5
            Assert.AreEqual(true, result);
            Assert.AreEqual(Facing.NORTH, robot.Facing);
            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(5, robot.Position.Y);

        }


        //Return false if a invalid Move happened. 
        [TestMethod()]
        public void MoveTest_Invalid()
        {
            ToyRobotMovingService movingService = new ToyRobotMovingService();
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);

            //Test 1
            Position position = new Position(0, 0);
            Facing facing = Facing.SOUTH;
            robot.Position = position;
            robot.Facing = facing;
            bool result = movingService.Move(robot, table);
            //Robot move north from 0,0
            //expect new Position is 0,0
            Assert.AreEqual(false, result);
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            //Test 2
            position = new Position(0, 1);
            facing = Facing.WEST;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Move(robot, table);
            //Robot move WEST from 0,1
            //expect new Position is 0,0
            Assert.AreEqual(false, result);
            Assert.AreEqual(Facing.WEST, robot.Facing);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);

            //Test 3
            position = new Position(1, 0);
            facing = Facing.SOUTH;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Move(robot, table);
            //Robot move NORTH from 1,0
            //expect new Position is 1,0
            Assert.AreEqual(false, result);
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);


            //Test 4
            position = new Position(4, 2);
            facing = Facing.EAST;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Move(robot, table);
            //Robot move east from 4,2
            //expect new Position is 4,2
            Assert.AreEqual(false, result);
            Assert.AreEqual(Facing.EAST, robot.Facing);
            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);

            //Test 5
            position = new Position(3, 5);
            facing = Facing.NORTH;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Move(robot, table);
            //Robot move south from 3,5
            //expect new Position is 3,5
            Assert.AreEqual(false, result);
            Assert.AreEqual(Facing.NORTH, robot.Facing);
            Assert.AreEqual(3, robot.Position.X);
            Assert.AreEqual(5, robot.Position.Y);

        }



        
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceTest_ArgumentNullException_1()
        {
            ToyRobotMovingService movingService = new ToyRobotMovingService();
            Robot robot = null;
            TableTop table = new TableTop(5, 6);
            Position position = new Position(2, 3);
            Facing facing = Facing.EAST;
            movingService.Place(robot, table, position, facing);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceTest_ArgumentNullException_2()
        {
            ToyRobotMovingService movingService = new ToyRobotMovingService();
            Robot robot = new Robot();
            TableTop table = null;
            Position position = new Position(2, 3);
            Facing facing = Facing.EAST;
            movingService.Place(robot, table, position, facing);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceTest_ArgumentNullException_3()
        {
            ToyRobotMovingService movingService = new ToyRobotMovingService();
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);
            Position position = null;
            Facing facing = Facing.EAST;
            movingService.Place(robot, table, position, facing);
        }
        

        [TestMethod()]
        public void PlaceTest_Valid()
        {
            ToyRobotMovingService movingService = new ToyRobotMovingService();
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);

            //Test 1
            Position position = new Position(1, 1);
            Facing facing = Facing.EAST;         
            bool result = movingService.Place(robot, table, position, facing);
            //expect new Position is 1,1
            Assert.AreEqual(true, result);
            Assert.AreEqual(Facing.EAST, robot.Facing);
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);

            //Test 2
            position = new Position(0, 0);
            facing = Facing.NORTH;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Place(robot, table, position, facing);
            //expect new Position is 0,0
            Assert.AreEqual(true, result);
            Assert.AreEqual(Facing.NORTH, robot.Facing);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            //Test 3
            position = new Position(4, 0);
            facing = Facing.WEST;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Place(robot, table, position, facing);
            //expect new Position is 4,0
            Assert.AreEqual(true, result);
            Assert.AreEqual(Facing.WEST, robot.Facing);
            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            //Test 4
            position = new Position(4, 5);
            facing = Facing.EAST;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Place(robot, table, position, facing);
            //expect new Position is 4,5
            Assert.AreEqual(true, result);
            Assert.AreEqual(Facing.EAST, robot.Facing);
            Assert.AreEqual(4, robot.Position.X);
            Assert.AreEqual(5, robot.Position.Y);

            //Test 5
            position = new Position(0, 5);
            facing = Facing.SOUTH;
            robot.Position = position;
            robot.Facing = facing;
            result = movingService.Place(robot, table, position, facing);
            //expect new Position is 0,5
            Assert.AreEqual(true, result);
            Assert.AreEqual(Facing.SOUTH, robot.Facing);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(5, robot.Position.Y);
        }

        //Test return false if the new Position is invalid
        [TestMethod()]
        public void PlaceTest_Invalid()
        {
            ToyRobotMovingService movingService = new ToyRobotMovingService();
            Robot robot = new Robot();
            TableTop table = new TableTop(5, 6);

            //Setup Robot to a valid Position first
            Position position = new Position(1, 1);
            Facing facing = Facing.EAST;
            bool result = movingService.Place(robot, table, position, facing);

            //Test 1
            position = new Position(-1, 1);
            result = movingService.Place(robot, table, position, facing);
            Assert.AreEqual(false, result);

            //Test 2
            position = new Position(1, -1);
            result = movingService.Place(robot, table, position, facing);
            Assert.AreEqual(false, result);

            //Test 3
            position = new Position(6, 1);
            result = movingService.Place(robot, table, position, facing);
            Assert.AreEqual(false, result);

            //Test 4
            position = new Position(1, 6);
            result = movingService.Place(robot, table, position, facing);
            Assert.AreEqual(false, result);

            //Test 5
            position = new Position(-3, -3);
            result = movingService.Place(robot, table, position, facing);
            Assert.AreEqual(false, result);

            //Test 6
            position = new Position(7, 7);
            result = movingService.Place(robot, table, position, facing);
            Assert.AreEqual(false, result);

            //Test 7: if the Position keep unchanged
            Assert.AreEqual(Facing.EAST, robot.Facing);
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);
        }
        
    }
}