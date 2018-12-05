public class Map
{
    public Map(double length, double width)
    {
        this.Length = length;
        this.Width = width;
    }

    public double Length { get; private set; }

    public double Width { get; private set; }
}

public abstract class GameObject
{
    public double X { get; set; }

    public double Y { get; set; }

    public double Radius { get; set; }
}

public abstract class Character : GameObject
{
    public double Health { get; set; }

    public double Speed { get; set; }
}

public class Player : Character
{
    public string Nickname { get; private set; }

    public uint Lives { get; set; }

    public int Score { get; set; }
}

//// MONSTERS

public abstract class Monster : Character
{
    public abstract void Attack(Character target);

    public abstract void Move(double x, double y);
}

public class Wolf : Monster
{
    public static double MaxHealth { get; private set; }

    public override void Attack(Character target)
    {
    }

    public override void Move(double x, double y)
    {
    }
}

public class Bear : Monster
{
    public static double MaxHealth { get; private set; }

    public override void Attack(Character target)
    {
    }

    public override void Move(double x, double y)
    {
    }
}

//// OBSTACLES

public class Stone : GameObject
{
}

public class Tree : GameObject
{
}

//// POWERUPS

public abstract class Powerup : GameObject
{
    public abstract void Pickup();
}

public class Apple : Powerup
{
    public override void Pickup()
    {
    }
}

public class Cherry : Powerup
{
    public override void Pickup()
    {
    }
}