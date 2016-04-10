
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator.Models;
using Robot_Simulator.Services;
using Robot_Simulator.Enums;

namespace Robot_Simulator
{
    public class RobotSimulator
    {
        private Robot _robot;
        private TableTop _tableTop;
        private readonly IRobotMovingService _movingService;
        private readonly IRobotTurningService _turningService;
        private readonly IRobotReportingService _reportingService;

        public RobotSimulator(Robot robot, TableTop table, IRobotMovingService movingService, IRobotTurningService turningService, IRobotReportingService reportingService)
        {
            if (robot == null) throw new ArgumentNullException(nameof(Robot));
            if (table == null) throw new ArgumentNullException(nameof(TableTop));
            if (movingService == null) throw new ArgumentNullException(nameof(IRobotMovingService));
            if (turningService == null) throw new ArgumentNullException(nameof(IRobotTurningService));
            if (reportingService == null) throw new ArgumentNullException(nameof(IRobotReportingService));

            _robot = robot;
            _tableTop = table;
            _movingService = movingService;
            _turningService = turningService;
            _reportingService = reportingService;
        }   
        
        public bool Move()
        {
            if (_robot.Position != null)
                return _movingService.Move(_robot, _tableTop);
            else
                return false;
        }

        public bool Place(Position position, Facing facing)
        {
           
           return _movingService.Place(_robot, _tableTop,position, facing);
        }

        public void TurnLeft()
        {
            if (_robot.Position != null)  _turningService.TurnLeft(_robot);
        }

        public void TurnRight()
        {
            if (_robot.Position != null)  _turningService.TurnRight(_robot);
        }

        public string Report()
        {

            if (_robot.Position != null)
                return _reportingService.Report(_robot);
            else
                return null;
        }



    }
}
