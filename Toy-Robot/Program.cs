#define CMD_LINE_ORIDE
// Overrides the command line with predefined input for ease of debugging
// Automatically sets the input to the SampleInputs file in the SolutionItems

#define REPORT_ALL
// For ease of testing, prints a report after each & every command, not only REPORT

namespace Toy_Robot {

	internal class Program {

		// Define thw size of the board
		//
		private const int BOARD_WIDTH = 5;
		private const int BOARD_HEIGHT = 5;

#if CMD_LINE_ORIDE
		private const string INPUT_FILE_OVERRIDE = @"..\..\..\..\SampleInputs.txt";
#endif

		private static List<RobotCommandBase> _commands = new List<RobotCommandBase>();

		private static RobotSituation _robotPosition = new();

		static void Main(string[] args) {
			Console.WriteLine("Hello, Toy Robot World!");

			string? cmdLine = args.Length > 0 ? args[0] : null;
#if CMD_LINE_ORIDE
			cmdLine = INPUT_FILE_OVERRIDE;
#endif
			// Stage 1 : Parse all inputs into command queue
			var inputReader = new InputReader(cmdLine);

			foreach (var line in inputReader.ReadFrom()) {
				string msg = CommandInterpreter.ReceiveCommand(line, _commands);
				if (!String.IsNullOrEmpty(msg))
					Console.WriteLine($"\r\n{msg}\r\n");
			}

			// Stage 2 : Execute all instructions from the queue
			CommandRunner runner = new(BOARD_WIDTH, BOARD_HEIGHT);
#if REPORT_ALL
			runner.ReportAll = true;
#endif
			foreach (var command in _commands) {
				var newPosition = runner.ExecuteCommand(command, _robotPosition);
				_robotPosition = newPosition;
			}
		}

	}
}