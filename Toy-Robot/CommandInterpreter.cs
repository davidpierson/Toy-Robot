namespace Toy_Robot {

	/// <summary>
	/// Translates from external string format to internal command format
	/// and adds command object to queue
	/// </summary>
	public class CommandInterpreter {

		/// <summary>
		/// Takes an input line text and adds the result to the command queue
		/// Blank/empty return is good, otherwise is an error message
		/// </summary>
		public static string ReceiveCommand(string line, List<RobotCommandBase> commands) {

			if (String.IsNullOrEmpty(line.Trim()))    // ignore empty input
				return "";

			string[] parts = line.Split(' ');

			if (Enum.TryParse(typeof(CommandEnum), "ce" + parts[0], true, out object? enumObj)) {

				RobotCommandBase? cmd;
				CommandEnum ce = (CommandEnum)enumObj;
				switch (ce) {
					case CommandEnum.cePlace:
						string msg = ParsePlace(parts.Length > 1 ? parts[1] : "", out int x, out int y, out DirectionEnum f);
						if (msg.Length > 0)
							return msg;
						cmd = new RobotCommandPlace(x, y, f);
						break;
					default:
						cmd = new RobotCommandBase(ce);
						break;
				}
				commands.Add(cmd);
				return "";
			}
			else {
				return $"Unrecognised command token '{parts[0]}' in line '{line}'";
			}
		}

		// Interpret the X Y and F arguments in PLACE X,Y,F
		//
		private static string ParsePlace(string subCommand, out int x, out int y, out DirectionEnum f) {

			x = y = 0;
			f = 0; // dummy
			string[] parts = subCommand.Split(',');
			if (parts.Length < 3)
				return $"PLACE command : insufficient arguments in '{subCommand}'";

			if (!int.TryParse(parts[0], out x) ||
				!int.TryParse(parts[1], out y))
				return $"PLACE command : non-numeric X or Y in '{subCommand}'";

			f = GetDirection(parts[2], out string msg);
			return msg;
		}

		// Translate a direction string (North, South, East, West) to internal format
		//
		private static DirectionEnum GetDirection(string direction, out string msg) {

			if (Enum.TryParse(typeof(DirectionEnum), "di" + direction, true, out object? enumObj)) {
				msg = "";
				return (DirectionEnum)enumObj;
			}
			else {
				msg = $"PLACE command : invalid direction argument '{direction}'.";
				return 0;
			}
		}
	}
}
