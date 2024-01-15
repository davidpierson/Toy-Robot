namespace Toy_Robot {

	/// <summary>
	/// Represents a PLACE command and includes relevant arguments
	/// </summary>
	internal class RobotCommandPlace : RobotCommandBase {

		public RobotCommandPlace(int x, int y, DirectionEnum f) : base(CommandEnum.cePlace) {
			X = x;
			Y = y;
			F = f;
		}

		public int X;
		public int Y;
		public DirectionEnum F;

	}
}
