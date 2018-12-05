using System;

    public class Triangle
    {
    private double a, b, c;

    public Triangle(double a, double b, double c)
    {
        if (a < 0 || b < 0 || c < 0 || a > b + c || b > a + c || c > a + b)
        {
            throw new ArgumentException("This is not a valid triangle!");
        }

        this.a = a;
        this.b = b;
        this.c = c;
    }
    
    public double P
    {
        get
        {
            return this.a + this.b + this.c;
        }
    }

    public double S
    {
        get
        {
            double p = this.P / 2.0;
            return Math.Sqrt(p * (p - this.a) * (p - this.b) * (p - this.c));
        }
    }

    public double A
    {
        get
        {
            return this.a;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("A side of the triangle must be non-positive!");
            }               

            if (value < this.b + this.c)
            {
                throw new ArgumentException("A side of the triangle must not be less than the sum of two other sides!");
            }

            this.a = value;
        }
    }

    public double B
    {
        get
        {
            return this.b;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("A side of the triangle must be non-positive!");
            }

            if (value < this.a + this.c)
            {
                throw new ArgumentException("A side of the triangle must not be less than the sum of two other sides!");
            }

            this.b = value;
        }
    }

    public double C
    {
        get
        {
            return this.c;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("A side of the triangle must be non-negative!");
            }

            if (value < this.a + this.b)
            {
                throw new ArgumentException("A side of the triangle must not be less than the sum of two other sides!");
            }

            this.c = value;
        }
    }
}
