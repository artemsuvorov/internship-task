namespace MindboxInternshipTask.Test;

public class TriangleTests
{
    private const double Delta = 1e-5;
    private const double IterationCount = 1e4;
    private const double LengthCoefficient = 1024;

    private static readonly Random _random = new();

    [TestCase(3, 4, 5, 6)]
    [TestCase(7, 10, 5, 16.248077)]
    [TestCase(6, 9, 11, 26.981475)]
    [TestCase(12, 15, 13, 74.833148)]
    [TestCase(1, 1, 1, 0.433013)]
    [TestCase(0.3, 0.6, 0.4, 0.053327)]
    public void Test_TriangleAreaBySides_IsCorrect(double side1, double side2, double side3, double expectedArea)
    {
        var triangle = new Triangle(side1, side2, side3);
        var actualArea = Geometry.GetArea(triangle);
        Assert.That(actualArea, Is.EqualTo(expectedArea).Within(Delta));
    }

    [Test]
    public void Test_RandomRightTriangle_IsRight()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            var cathetus1 = _random.NextDouble() * LengthCoefficient;
            var cathetus2 = _random.NextDouble() * LengthCoefficient;
            var hypotenuse = Math.Sqrt(cathetus1 * cathetus1 + cathetus2 * cathetus2);

            var triangle = new Triangle(cathetus1, cathetus2, hypotenuse);
            Assert.That(triangle.IsRight);
        }
    }

    [Test]
    public void Test_RandomRightTriangleArea_IsCorrect()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            var cathetus1 = _random.NextDouble() * LengthCoefficient;
            var cathetus2 = _random.NextDouble() * LengthCoefficient;
            var hypotenuse = Math.Sqrt(cathetus1 * cathetus1 + cathetus2 * cathetus2);

            var expectedArea = 0.5 * cathetus1 * cathetus2;
            Test_TriangleAreaBySides_IsCorrect(hypotenuse, cathetus1, cathetus2, expectedArea);
        }
    }

    [Test]
    public void Test_ThrowsExceptionFor_InvalidTriangles()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(0, 0, 0));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 1));
        Assert.Throws<ArgumentException>(() => new Triangle(-3, -4, -5));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 10));
    }
}