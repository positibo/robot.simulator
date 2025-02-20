namespace RobotSimulator.Challenge.Tests
{
    [TestFixture]
    public class Tests
    {
        private Robot robot;

        [SetUp]
        public void Setup()
        {
            robot = new Robot();
        }

        [Test]
        public void TestPlace()
        {
            robot.Place(0,0,"NORTH");
            var report = robot.GenerateReport();
            Assert.That(report, Is.EqualTo("0,0,NORTH"));
        }

        [Test]
        public void TestNorthMovement()
        {
            robot.Place(0,0,"NORTH");
            robot.Move();
            var report = robot.GenerateReport();
            Assert.That(report, Is.EqualTo("0,1,NORTH"));
        }

        [Test]
        public void TestLeftMovement()
        {
            robot.Place(0,0,"NORTH");
            robot.Move();
            robot.Left();
            var report = robot.GenerateReport();
            Assert.That(report, Is.EqualTo("0,1,WEST"));
        }

        [Test]
        public void TestInvalidPlacement()
        {
            robot.Place(5,5,"EAST");
            var report = robot.GenerateReport();
            Assert.That(report, Is.EqualTo(""));
        }
    }
}