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
    public class ToyRobotReportingServiceTests
    {

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReportTest_ArgumentNullException_1()
        {
            ToyRobotReportingService reportingService = new ToyRobotReportingService();
            Robot robot = null;
            reportingService.Report(robot);
        }


        [TestMethod()]        
        public void ReportTest()
        {
            ToyRobotReportingService reportingService = new ToyRobotReportingService();            
            Robot robot = new Robot();
            Position position = new Position(3, 3);
            Facing facing = Facing.NORTH;
            robot.Position = position;
            robot.Facing = facing;

            string result = reportingService.Report(robot);

            Assert.AreEqual("Output: 3,3,NORTH", result);

        }
        
    }
}