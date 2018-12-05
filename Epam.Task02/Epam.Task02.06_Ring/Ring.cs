using System;

public class Ring
{
    private double x;
    private double y;
    private Round inner;
    private Round outer;

    public Ring(double x, double y, double ri, double ro)
    {
        if (ri > ro)
        {
            throw new ArgumentException("The outer radius must be larger than the inner one!");
        }

        this.x = x;
        this.y = y;
        this.inner = new Round(x, y, ri);
        this.outer = new Round(x, y, ro);
    }

    public double X
    {
        get
        {
            return this.x;
        }

        set
        {
            this.inner.X = this.outer.X = value;
        }
    }

    public double Y
    {
        get
        {
            return this.y;
        }

        set
        {
            this.inner.Y = this.outer.Y = value;
        }
    }

    public double InnerRadius
    {
        get
        {
            return this.inner.R;
        }

        set
        {
            if (value > this.outer.R)
            {
                throw new ArgumentException("The outer radius must be larger than the inner one!");
            }

            this.inner.R = value;
        }
    }

    public double OuterRadius
    {
        get
        {
            return this.outer.R;
        }

        set
        {
            if (value < this.inner.R)
            {
                throw new ArgumentException("The outer radius must be larger than the inner one!");
            }

            this.outer.R = value;
        }
    }

    public double C
    {
        get
        {
            return this.inner.C + this.outer.C;
        }
    }

    public double S
    {
        get
        {
            return this.outer.S - this.inner.S;
        }
    }
}