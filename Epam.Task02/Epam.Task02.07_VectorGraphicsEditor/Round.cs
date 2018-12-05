using System;

public class Round
{
    private double r;

    public Round(double x, double y, double r)
    {
        if (r < 0)
        {
            throw new ArgumentOutOfRangeException("Radius must be non-negative!");
        }

        this.X = x;
        this.Y = y;
        this.R = r;
    }

    public double X { get; set; }

    public double Y { get; set; }

    public double R
    {
        get
        {
            return this.r;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Radius can not be negative!");
            }

            this.r = value;
        }
    }

    public double C
    {
        get
        {
            return 2 * Math.PI * this.r;
        }
    }

    public double S
    {
        get
        {
            return Math.PI * this.r * this.r;
        }
    }
}
