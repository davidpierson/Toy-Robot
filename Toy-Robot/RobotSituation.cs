namespace Toy_Robot {

	/// <summary>
	/// Represents the current location and direction of the robot
	/// </summary>
	public class RobotSituation {

		public int X;
		public int Y;
		public DirectionEnum Direction;
		public bool OnBoard;

		public RobotSituation ShallowCopy() {

			return (RobotSituation)MemberwiseClone();
		}

		public bool ValidPosition(int boardWidth, int boardHeight) {

			return X >= 0 &&
				   Y >= 0 &&
				   X < boardWidth &&
				   Y < boardHeight;
		}
	}
}
