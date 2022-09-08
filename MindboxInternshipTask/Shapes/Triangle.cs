namespace MindboxInternshipTask;

public class Triangle : Shape
{
    private const double Delta = 1e-5;

    public double Hypotenuse { get; }
    public double Cathetus1 { get; }
    public double Cathetus2 { get; }

    public Triangle(double side1, double side2, double side3)
    {
        Validate(side1, side2, side3);

        var orderedSides = new double[] { side1, side2, side3 }
            .OrderByDescending(x => x)
            .ToArray();

        Hypotenuse = orderedSides[0];
        Cathetus1 = orderedSides[1];
        Cathetus2 = orderedSides[2];
    }

    public bool IsRight()
    {
        return Math.Abs(Cathetus1*Cathetus1 + Cathetus2*Cathetus2 - Hypotenuse*Hypotenuse) < Delta;
    }

    protected override double CalculateArea()
    {
        if (IsRight())
            return 0.5 * Cathetus1 * Cathetus2;

        var (a, b, c) = (Hypotenuse, Cathetus1, Cathetus2);
        var p = (a + b + c) * 0.5; // semiperimeter
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    private static void Validate(double side1, double side2, double side3)
    {
        if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
            throw new ArgumentException("Invalid sides for a triangle.");
    }
}