namespace RobotSimulator.Challenge
{
    /// <summary>
    /// The class for the toy robot functionality.
    /// </summary>
    public class Robot
    {
        private string[] directions = { "NORTH", "SOUTH", "EAST", "WEST" };
        private int? x,y;
        private int tableUnit = 5;
        private string? direction;
        private readonly (int, int)[] directionMap = { (0,1),(1,0),(0,-1),(-1,0) };

        public Robot()
        {
            x = null;
            y = null;
            direction = null;
        }

        /// <summary>
        /// This method will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
        /// </summary>
        /// <param name="x">The X.</param>
        /// <param name="y">The Y.</param>
        /// <param name="direction">The direction.</param>
        public void Place(int x, int y, string direction)
        {
            if (!Array.Exists(directions, d => d == direction))
            {
                return;
            }

            if(x >= 0 && x < tableUnit &&
               y >= 0 && y < tableUnit)
            {
                this.x = x;
                this.y = y;
                this.direction = direction;
            }
        }

        /// <summary>
        /// This method will move the toy robot one unit forward in the direction it is currently facing.
        /// </summary>
        public void Move()
        {
            if (x.HasValue && y.HasValue && direction != null)
            {
                var (directionX, directionY) = directionMap[Array.IndexOf(directions, direction)];
                int newXValue = x.Value + directionX;
                int newYValue = y.Value + directionY;

                if(newXValue >= 0 && newXValue < tableUnit &&
                   newYValue >= 0 && newYValue < tableUnit)
                {
                    this.x = newXValue;
                    this.y = newYValue;
                }
            }
        }

        /// <summary>
        /// This method will rotate the robot 90 degrees in the specified direction without changing the positionof the robot.
        /// </summary>
        public void Left()
        {
            if(direction == null)
            {
                return;
            }

            int currentIndex = Array.IndexOf(directions, direction);
            direction = directions[(currentIndex + 3) % 4];
        }

        /// <summary>
        /// This method will rotate the robot 90 degrees in the specified direction without changing the positionof the robot.
        /// </summary>
        public void Right()
        {
            if (direction == null)
            {
                return;
            }

            int currentIndex = Array.IndexOf(directions, direction);
            direction = directions[(currentIndex + 1) % 4];
        }

        /// <summary>
        /// This will announce the X,Y and F of the robot. This can be in any form, but standard output issufficient.
        /// </summary>
        /// <returns></returns>
        public string GenerateReport()
        {
            if (x.HasValue && y.HasValue && direction != null)
            {
                return $"{x},{y},{direction}";
            }

            return string.Empty;
        }

        /// <summary>
        /// This method will check if valid value for X, Y and direction.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return x.HasValue && y.HasValue && direction != null;
        }
    }
}
