namespace MindboxInternshipTask.Test;

public class TriangleTests
{
    private const double Delta = 1e-5;
    private static readonly Random _random = new();

    [TestCase(3, 4, 5, 6)]
    [TestCase(7, 10, 5, 16.248077)]
    [TestCase(6, 9, 11, 26.981475)]
    [TestCase(12, 15, 13, 74.833148)]
    [TestCase(1, 1, 1, 0.433013)]
    [TestCase(0.3, 0.6, 0.4, 0.053327)]
    public void Test_TriangleArea(double side1, double side2, double side3, double expectedArea)
    {
        var triangle = new Triangle(side1, side2, side3);
        Assert.That(triangle.Area, Is.EqualTo(expectedArea).Within(Delta));
    }

    [Test]
    public void Test_RandomRightTriangle()
    {
        var cathetus1 = _random.NextDouble() * 1024;
        var cathetus2 = _random.NextDouble() * 1024;
        var hypotenuse = Math.Sqrt(cathetus1 * cathetus1 + cathetus2 * cathetus2);

        var triangle = new Triangle(cathetus1, cathetus2, hypotenuse);
        Assert.That(triangle.IsRight());

        var expectedArea = 0.5 * cathetus1 * cathetus2;
        Assert.That(triangle.Area, Is.EqualTo(expectedArea).Within(Delta));
    }

    [Test]
    public void Test_InvalidTriangles()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(0, 0, 0));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 1));
        Assert.Throws<ArgumentException>(() => new Triangle(-3, -4, -5));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 10));
    }
}