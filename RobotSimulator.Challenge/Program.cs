
using RobotSimulator.Challenge;

CommandHandler handler = new CommandHandler();

var currentDirectory = Directory.GetCurrentDirectory();
var directory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName;

if(directory != null)
{
    var filePath = Path.Combine(directory, "commands.txt");
    handler.ExecuteCommandFromFile(filePath);
}


