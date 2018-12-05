using System;

public interface IShape
{
    void Show();
}

public class Line : IShape
{
    public Line(double x1, double y1, double x2, double y2)
    {
        this.X1 = x1;
        this.Y1 = y1;
        this.X2 = x2;
        this.Y2 = y2;
    }

    public Line(double x1, double y1) : this(x1, y1, 0, 0)
    {
    }

    public double X1 { get; set; }

    public double Y1 { get; set; }

    public double X2 { get; set; }

    public double Y2 { get; set; }

    public double Length
    {
        get
        {
            return Math.Sqrt(((this.X1 - this.X2) * (this.X1 - this.X2)) + ((this.Y1 - this.Y2) * (this.Y1 - this.Y2)));
        }
    }

    public double? Slope
    {
        get
        {
            try
            {
                return checked((this.Y2 - this.Y1) / (this.X1 - this.X2));
            }
            catch (OverflowException)
            {
                return null;
            }
            catch (DivideByZeroException)
            {
                return null;
            }
        }
    }

    public double Angle
    {
        get
        {
            return this.Slope.HasValue ? Math.Atan(this.Slope.Value) : (Math.PI / 2);
        }
    }

    public void Show()
    {
        Console.WriteLine("Line");
        Console.WriteLine($"({this.X1}; {this.Y1}) ({this.X2}; {this.Y2})");
        Console.WriteLine($"Length = {this.Length}; Slope = {(this.Slope.HasValue ? this.Slope.Value.ToString() : "undefined")}; Angle = {this.Angle}");
    }
}

public class Rectangle : IShape
{
    private double x;
    private double y;
    private double a;
    private double b;
    private Line[] side;

    public Rectangle(double x, double y, double a, double b)
    {
        this.x = x;
        this.y = y;
        this.a = a;
        this.b = b;
        this.side = new Line[4];
        this.side[0] = new Line(x, y, x + a, y);
        this.side[1] = new Line(x + a, y, x + a, y + b);
        this.side[2] = new Line(x + a, y + b, x, y + b);
        this.side[3] = new Line(x, y + b, x, y);
    }

    public Rectangle(double a, double b) : this(0, 0, a, b)
    {
    }

    public bool IsSquare
    {
        get
        {
            return Math.Abs(this.a) == Math.Abs(this.b);
        }
    }

    public double Perimeter
    {
        get
        {
            return Math.Abs(2 * (this.a + this.b));
        }
    }

    public double Area
    {
        get
        {
            return Math.Abs(this.a * this.b);
        }
    }

    public double Diagonal
    {
        get
        {
            return Math.Sqrt((this.a * this.a) + (this.b * this.b));
        }
    }

    public void Show()
    {
        Console.WriteLine("Rectangle");
        Console.WriteLine($"x = {this.x}; y = {this.y}");
        Console.WriteLine($"a = {this.a}; b = {this.b}{(this.IsSquare ? " (square)" : "")}");
        Console.Write("Vertices: ");

        for (int i = 0; i < 4; i++)
        {
            Console.Write($"({this.side[i].X1}; {this.side[i].Y1}); ");
        }

        Console.WriteLine();
        Console.WriteLine($"Perimeter = {this.Perimeter}; Area = {this.Area}; Diagonal = {this.Diagonal}");
    }
}

public class Circle : Round, IShape
{
    public Circle(double x, double y, double r) : base(x, y, r)
    {
    }

    public void Show()
    {
        Console.WriteLine("Circle");
        Console.WriteLine($"Center at ({this.X}; {this.Y}), Radius = {this.R}");
        Console.WriteLine($"Circumference = {this.C}");
    }
}

public class Disc : Round, IShape
{
    public Disc(double x, double y, double r) : base(x, y, r)
    {
    }

    public void Show()
    {
        Console.WriteLine("Circle");
        Console.WriteLine($"Center at ({this.X}; {this.Y}), Radius = {this.R}");
        Console.WriteLine($"Circumference = {this.C}, Area = {this.S}");
    }
}

public class RingShowable : Ring, IShape
{
    public RingShowable(double x, double y, double ri, double ro) : base(x, y, ri, ro)
    {
    }

    public double Thickness
    {
        get
        {
            return this.OuterRadius - this.InnerRadius;
        }
    }

    public void Show()
    {
        Console.WriteLine("Ring");
        Console.WriteLine($"Center at ({this.X}; {this.Y})");
        Console.WriteLine($"Inner radius = {this.InnerRadius}; Outer radius = {this.OuterRadius}");
        Console.WriteLine($"Thickness = {this.Thickness}; Total circumference = {this.C}, Area = {this.S}");
    }
}
