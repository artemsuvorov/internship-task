namespace MindboxInternshipTask;

public class Triangle : Shape
{
    private const double Delta = 1e-5;

    private bool? _isRight;
    private readonly double _side1, _side2, _side3;

    public bool IsRight => _isRight ??= CheckIsRight();

    public Triangle(double side1, double side2, double side3)
    {
        Validate(side1, side2, side3);

        var orderedSides = new double[] { side1, side2, side3 }
            .OrderByDescending(x => x)
            .ToArray();

        (_side1, _side2, _side3) = (orderedSides[0], orderedSides[1], orderedSides[2]);
    }

    protected bool CheckIsRight()
    {
        return Math.Abs(_side2*_side2 + _side3*_side3 - _side1*_side1) < Delta;
    }

    protected override double CalculateArea()
    {
        if (IsRight)
            return 0.5 * _side2 * _side3;

        var (a, b, c) = (_side1, _side2, _side3);
        var p = (a + b + c) * 0.5; // semiperimeter
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    private static void Validate(double side1, double side2, double side3)
    {
        if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
            throw new ArgumentException("Invalid sides for a triangle.");
    }
}