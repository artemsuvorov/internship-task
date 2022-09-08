namespace MindboxInternshipTask.Test;

public class CircleTests
{
    private const double Delta = 1e-5;
    private static readonly Random _random = new();

    [TestCase(1, Math.PI)]
    [TestCase(2, 4*Math.PI)]
    [TestCase(3.12, 3.12*3.12*Math.PI)]
    public void Test_TriangleArea(double radius, double expectedArea)
    {
        var circle = new Circle(radius);
        Assert.That(circle.Area, Is.EqualTo(expectedArea).Within(Delta));
    }

    [Test]
    public void Test_RandomCircleArea()
    {
        var radius = _random.NextDouble() * 1024;
        var circle = new Circle(radius);
        var expectedArea = radius * radius * Math.PI;
        Assert.That(circle.Area, Is.EqualTo(expectedArea).Within(Delta));
    }

    [Test]
    public void Test_InvalidCircles()
    {
        Assert.Throws<ArgumentException>(() => new Circle(0));
        Assert.Throws<ArgumentException>(() => new Circle(-0.5));
        Assert.Throws<ArgumentException>(() => new Circle(-1.0));
    }
}