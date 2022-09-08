namespace MindboxInternshipTask;

public abstract class Shape
{
    private double? _area;

    public double Area => _area ??= CalculateArea();

    protected abstract double CalculateArea();
}