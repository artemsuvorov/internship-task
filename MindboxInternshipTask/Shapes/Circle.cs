namespace MindboxInternshipTask;

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Validate(radius);
        Radius = radius;
    }

    protected override double CalculateArea()
    {
        return Radius * Radius * Math.PI;
    }

    private static void Validate(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Invalid radius.");
    }
}