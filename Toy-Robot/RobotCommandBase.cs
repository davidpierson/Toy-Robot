namespace Toy_Robot {

	/// <summary>
	/// Represents an individual command to a robot
	/// </summary>
	public class RobotCommandBase {

		public RobotCommandBase(CommandEnum command) {
			_command = command;
		}

		private CommandEnum _command;

		public CommandEnum Command { get { return _command; } }

	}

	/// <summary>
	/// Enum names correspond to their external input string format prefixed by "ce"
	/// </summary>
	public enum CommandEnum {
		cePlace,
		ceMove,
		ceLeft,
		ceRight,
		ceReport
	}

	/// <summary>
	/// Enum names correspond to their external input string format prefixed by "di"
	/// </summary>
	public enum DirectionEnum {
		diNorth = 0,
		diEast = 90,
		diSouth = 180,
		diWest = 270
		// Enum numeric values are assigned in clockwise order, in a 360 degree circle
		// and the rotation commands rely on this
		// North is the lowest, West is the highest numbered value.
	}
}
