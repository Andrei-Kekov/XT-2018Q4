using System;

public class VectorGraphicsEditor
{
    public static Line AddLine()
    {
        double x1;
        double y1;
        double x2;
        double y2;
        Console.WriteLine("Enter the coordinates:");
        Console.Write("x1: ");
        
        if (!double.TryParse(Console.ReadLine(), out x1))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("y1: ");

        if (!double.TryParse(Console.ReadLine(), out y1))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("x2: ");

        if (!double.TryParse(Console.ReadLine(), out x2))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("y2: ");

        if (!double.TryParse(Console.ReadLine(), out y2))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }
        
        return new Line(x1, y1, x2, y2);
    }

    public static Rectangle AddRectangle()
    {
        double x;
        double y;
        double a;
        double b;
        Console.WriteLine("Enter the coordinates of the base vertex");
        Console.Write("x: ");

        if (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("y: ");

        if (!double.TryParse(Console.ReadLine(), out y))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.WriteLine("Enter the dimensions:");
        Console.Write("a: ");

        if (!double.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("b: ");

        if (!double.TryParse(Console.ReadLine(), out b))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        return new Rectangle(x, y, a, b);
    }

    public static Circle AddCircle()
    {
        double x;
        double y;
        double r;
        Console.WriteLine("Enter the coordinates of the center:");
        Console.Write("x: ");

        if (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("y: ");

        if (!double.TryParse(Console.ReadLine(), out y))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }
        
        Console.Write("Enter the radius: ");

        if (!double.TryParse(Console.ReadLine(), out r))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        try
        {
            return new Circle(x, y, r);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
            return null;
        }
    }

    public static Disc AddDisc()
    {
        double x;
        double y;
        double r;
        Console.WriteLine("Enter the coordinates of the center:");
        Console.Write("x: ");

        if (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("y: ");

        if (!double.TryParse(Console.ReadLine(), out y))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("Enter the radius: ");

        if (!double.TryParse(Console.ReadLine(), out r))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        try
        {
            return new Disc(x, y, r);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
            return null;
        }
    }

    public static RingShowable AddRing()
    {
        double x;
        double y;
        double ri;
        double ro;
        Console.WriteLine("Enter the coordinates of the center:");
        Console.Write("x: ");

        if (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("y: ");

        if (!double.TryParse(Console.ReadLine(), out y))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("Enter the inner radius: ");

        if (!double.TryParse(Console.ReadLine(), out ri))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        Console.Write("Enter the outer radius: ");

        if (!double.TryParse(Console.ReadLine(), out ro))
        {
            Console.WriteLine("Incorrect value.");
            return null;
        }

        try
        {
            return new RingShowable(x, y, ri, ro);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
            return null;
        }
    }

    public static void ShowAll(IShape[] shapes)
    {
        foreach (IShape shape in shapes)
        {
            if (shape != null)
            {
                shape.Show();
                Console.WriteLine();
            }
        }
    }

    public static void Main()
    {
        Console.WriteLine("Task 2.7. Vector Graphics Editor");

        char key = '\0';
        IShape[] shapes = new IShape[10];
        int count = 0;

        while (key != 'x')
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("Add (l)ine, add rec(t)angle, add (c)ircle, add (d)isk, add ri(n)g, (s)how all, e(x)it");

            if (!char.TryParse(Console.ReadLine(), out key))
                {
                Console.WriteLine("Wrong command.");
                continue;
                }

            key = char.ToLower(key);

            switch (key)
            {
                case 'l':
                    shapes[count] = AddLine();

                    if (shapes[count] != null)
                    {
                        count++;
                        Console.WriteLine($"Line added. {count} shapes total.");
                    }

                    break;
                case 't':
                    shapes[count] = AddRectangle();
                    if (shapes[count] != null)
                    {
                        count++;
                        Console.WriteLine($"Rectangle added. {count} shapes total.");
                    }

                    break;
                case 'c':
                    shapes[count] = AddCircle();

                    if (shapes[count] != null)
                    {
                        count++;
                        Console.WriteLine($"Circle added. {count} shapes total.");
                    }

                    break;
                case 'd':
                    shapes[count] = AddDisc();

                    if (shapes[count] != null)
                    {
                        count++;
                        Console.WriteLine($"Disc added. {count} shapes total.");
                    }

                    break;
                case 'n':
                    shapes[count] = AddRing();
                    if (shapes[count] != null)
                    {
                        count++;
                        Console.WriteLine($"Ring added. {count} shapes total.");
                    }

                    break;
                case 's':
                    ShowAll(shapes);
                    break;
            }

            if (count == 10)
            {
                Console.WriteLine("Only ten shapes supported!");
                ShowAll(shapes);
            }
        }
    }
}