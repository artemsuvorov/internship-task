namespace MindboxInternshipTask.Test;

public class CircleTests
{
    private const double Delta = 1e-5;
    private const double IterationCount = 1e4;
    private const double LengthCoefficient = 1024;

    private static readonly Random _random = new();

    [TestCase(1, Math.PI)]
    [TestCase(2, 4*Math.PI)]
    [TestCase(3.12, 3.12*3.12*Math.PI)]
    public void Test_CirlceAreaByRadius_IsCorrect(double radius, double expectedArea)
    {
        var circle = new Circle(radius);
        var actualArea = Geometry.GetArea(circle);
        Assert.That(actualArea, Is.EqualTo(expectedArea).Within(Delta));
    }

    [Test]
    public void Test_RandomCircleArea_IsCorrect()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            var radius = _random.NextDouble() * LengthCoefficient;
            var expectedArea = radius * radius * Math.PI;
            Test_CirlceAreaByRadius_IsCorrect(radius, expectedArea);
        }
    }

    [Test]
    public void Test_ThrowsExceptionFor_InvalidCircles()
    {
        Assert.Throws<ArgumentException>(() => new Circle(0));
        Assert.Throws<ArgumentException>(() => new Circle(-0.5));
        Assert.Throws<ArgumentException>(() => new Circle(-1.0));
    }
}