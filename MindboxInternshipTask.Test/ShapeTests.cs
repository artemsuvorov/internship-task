namespace MindboxInternshipTask.Test;

internal class ShapeTests
{
    private const double Delta = 1e-5;
    private const double IterationCount = 1e6;

    private class TestShape : Shape
    {
        public int CalculateCount { get; private set; } = 0;

        protected override double CalculateArea()
        {
            CalculateCount++;
            return default;
        }
    }

    private class Point : Shape
    {
        protected override double CalculateArea()
        {
            return 0.0;
        }
    }

    [Test]
    public void Test_DifferentAreaCalls_ReturnSameValue()
    {
        var point = new Point();

        var area1 = Geometry.GetArea(point);
        var area2 = point.Area;

        Assert.That(area1, Is.EqualTo(area2).Within(Delta));
    }

    [Test]
    public void Test_CalculateAreaMethod_IsCalledOnce()
    {
        var shape = new TestShape();

        for (var i = 0; i < IterationCount; i++)
        {
            _ = shape.Area;
            _ = Geometry.GetArea(shape);
        }

        Assert.That(shape.CalculateCount, Is.EqualTo(expected: 1).Within(Delta));
    }
}