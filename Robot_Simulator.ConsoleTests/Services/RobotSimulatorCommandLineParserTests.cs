using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot_Simulator.ConsoleUI.Models;
using Robot_Simulator.ConsoleUI.Services;
using Robot_Simulator.Enums;
using Robot_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator.ConsoleUI.Services.Tests
{
    [TestClass()]
    public class RobotSimulatorCommandLineParserTests
    {
        [TestMethod()]
        public void ParsingTest()
        {
            Dictionary<String, Command> testData = new Dictionary<string, Command>();
            testData.Add("MOVE", new Command_Move());
            testData.Add("LEFT", new Command_Left());
            testData.Add("RIGHT", new Command_Right());
            testData.Add("REPORT", new Command_Report());
            testData.Add("PLACE 1,1,NORTH", new Command_Place(new Position(1,1), Facing.NORTH));
            testData.Add("Move", null);
            testData.Add("invalid command", null);
            testData.Add("  MOVE     ", new Command_Move());
            testData.Add("   PLACE  1    ,    1  ,   NORTH   ", new Command_Place(new Position(1, 1), Facing.NORTH));
            testData.Add("MOVE Something", null);

            RobotSimulatorCommandLineParser parser = new RobotSimulatorCommandLineParser();

            foreach (var data in testData)
            {
                Command result = parser.Parsing(data.Key);
                if (data.Value == null)
                    Assert.IsNull(result);
                else
                    Assert.IsInstanceOfType(result, data.Value.GetType());
            }
        }
    }
}