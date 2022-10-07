namespace MindboxInternshipTask;

public class Circle : Shape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        Validate(radius);
        _radius = radius;
    }

    protected override double CalculateArea()
    {
        return _radius * _radius * Math.PI;
    }

    private static void Validate(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Invalid radius.");
    }
}