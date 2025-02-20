namespace RobotSimulator.Challenge
{
    /// <summary>
    /// Class for handling the process of the commands.
    /// </summary>
    public class CommandHandler
    {
        private Robot robot;

        public CommandHandler()
        {
            robot = new Robot();
        }

        public void ExecuteCommand(string command)
        {
            var parts = command.Trim().Split(' ');

            switch (parts[0])
            {
                case "PLACE":
                    var position = parts[1].Split(',');
                    int x = int.Parse(position[0]);
                    int y = int.Parse(position[1]);
                    var direction = position[2];
                    robot.Place(x, y, direction);
                    break;
                case "MOVE":
                    if (robot.IsValid())
                    {
                        robot.Move();
                    }
                    break;
                case "LEFT":
                    if (robot.IsValid())
                    {
                        robot.Left();
                    }
                    break;
                case "RIGHT":
                    if (robot.IsValid())
                    {
                        robot.Right();
                    }
                    break;
                case "REPORT":
                    if (robot.IsValid())
                    {
                        var report = robot.GenerateReport();
                        Console.WriteLine(report);
                    }
                    break;
            }
        }

        public void ExecuteCommandFromFile(string file)
        {
            var commands = File.ReadAllLines(file);
            foreach (var command in commands)
            {
                ExecuteCommand(command);
            }
        }

    }
}
