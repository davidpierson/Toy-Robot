namespace Toy_Robot {

	/// <summary>
	/// Executes robot commands
	/// </summary>
	public class CommandRunner {

		int _boardWidth;
		int _boardHeight;

		public CommandRunner(int boardWidth, int boardHeight) {
			_boardWidth = boardWidth;
			_boardHeight = boardHeight;
		}

		public bool ReportAll { get; internal set; }

		/// <summary>
		/// Takes a single command and the current state of the robot and returns new position or outputs as appropriate
		/// The core approach is to clone the position, apply the commands, then discard the clone if its location is not valid
		/// </summary>
		public RobotSituation ExecuteCommand(RobotCommandBase cmd, RobotSituation position) {

			CommandEnum operation = cmd.Command;
			ReportCommandMaybe(cmd);
			if (!position.OnBoard && operation != CommandEnum.cePlace)   // Discard all commands in the sequence until a valid PLACE command has been executed.
				return position;
			bool reportAfter = ReportAll;
			// Clone into working object which becomes primary situation if valid
			RobotSituation newPosition = position.ShallowCopy();
			//
			// Apply command to newPosition, then validate, and if valid, return the adjusted valid position.
			switch (operation) {
				case (CommandEnum.cePlace):
					RobotCommandPlace placer = (RobotCommandPlace)cmd;
					newPosition.X = placer.X;
					newPosition.Y = placer.Y;
					newPosition.Direction = placer.F;
					break;
				case CommandEnum.ceMove:
					MoveRobot(newPosition);
					break;
				case CommandEnum.ceLeft:
					newPosition.Direction -= 90;
					if ((int)newPosition.Direction < 0)
						newPosition.Direction = DirectionEnum.diWest;		// Enum values are assigned in clockwise & specific order
					break;
				case CommandEnum.ceRight:
					newPosition.Direction += 90;
					if ((int)newPosition.Direction > (int)DirectionEnum.diWest)
						newPosition.Direction = DirectionEnum.diNorth;
					break;
				case CommandEnum.ceReport:
					reportAfter = true;
					break;
			}
			if (newPosition.ValidPosition(_boardWidth, _boardHeight)) {
				newPosition.OnBoard = true;
				ReportMaybe(newPosition, reportAfter);
				return newPosition;
			}
			ReportMaybe(position, reportAfter);
			return position;        // Invalid command e.g. attempt to move past boundary
		}

		private void ReportCommandMaybe(RobotCommandBase cmd) {
			if (ReportAll)
				Console.WriteLine(cmd.Command.ToString().Substring(2));
		}

		private void ReportMaybe(RobotSituation position, bool doReport) {
			if (doReport)
				Console.WriteLine($"X = {position.X}, Y = {position.Y}, F = {position.Direction.ToString().Substring(2)}");
		}
		// MOVE will move the toy robot one unit forward in the direction it is currently facing.
		//
		private void MoveRobot(RobotSituation position) {
			switch (position.Direction) {
				case DirectionEnum.diNorth:
					position.Y++;
					break;
				case DirectionEnum.diSouth:
					position.Y--;
					break;
				case DirectionEnum.diEast:
					position.X++;
					break;
				case DirectionEnum.diWest:
					position.X--;
					break;
			}
		}

	}
}
