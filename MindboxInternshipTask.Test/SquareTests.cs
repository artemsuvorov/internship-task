namespace MindboxInternshipTask.Test;

internal class SquareTests
{
    private const double Delta = 1e-5;
    private const double IterationCount = 1e4;
    private const double LengthCoefficient = 1024;

    private static readonly Random _random = new();

    // It is this easy to create new Geomtery Shape
    private class Square : Shape
    {
        private readonly double _side;

        public Square(double side)
        {
            _side = side;
        }

        protected override double CalculateArea()
        {
            return _side * _side;
        }
    }

    [TestCase(1.0, 1.0)]
    [TestCase(2.5, 2.5 * 2.5)]
    [TestCase(Math.PI, Math.PI * Math.PI)]
    public void Test_SquareAreaBySide_IsCorrect(double side, double expectedArea)
    {
        var square = new Square(side);
        var actualArea = Geometry.GetArea(square);
        Assert.That(actualArea, Is.EqualTo(expectedArea).Within(Delta));
    }

    [Test]
    public void Test_RandomSquareArea_IsCorrect()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            var side = _random.NextDouble() * LengthCoefficient;
            var expectedArea = side * side;
            Test_SquareAreaBySide_IsCorrect(side, expectedArea);
        }
    }
}