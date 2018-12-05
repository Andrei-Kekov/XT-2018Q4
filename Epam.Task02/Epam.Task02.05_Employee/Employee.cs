using System;

public class Employee : User
{
    private int experience;

    public string Appointment { get; set; }

    public int Experience
    {
        get
        {
            return this.experience;
        }

        set
        {
            if (value <= this.Age)
            {
                this.experience = value;
            }
            else
            {
                throw new ArgumentException("The employee's experience can't be longer than his or her age!");
            }
        }
    }
}
