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

		/// <summary>
		/// MoveRobot will move the toy robot one unit forward in the direction it is currently facing.
		/// Updated position may be off the board.
		/// </summary>
		public void MoveRobot() {
			switch (Direction) {
				case DirectionEnum.diNorth:
					Y++;
					break;
				case DirectionEnum.diSouth:
					Y--;
					break;
				case DirectionEnum.diEast:
					X++;
					break;
				case DirectionEnum.diWest:
					X--;
					break;
			}
		}

		public bool ValidPosition(int boardWidth, int boardHeight) {

			return X >= 0 &&
				   Y >= 0 &&
				   X < boardWidth &&
				   Y < boardHeight;
		}
	}
}
