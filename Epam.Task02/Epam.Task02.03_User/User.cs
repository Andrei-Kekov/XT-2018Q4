using System;

public class User
{
    private DateTime dateOfBirth;

    public string FirstName { get; set; }

    public string Patronymic { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth
    {
        get
        {
            return this.dateOfBirth;
        }

        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("The user's date of birth can't be in the future!");
            }

            if (DateTime.Now.Year - value.Year > 200)
            {
                throw new ArgumentException("The user's age is more than 200 years - this is probably a mistake!");
            }

            this.dateOfBirth = value;
        }
     }

    public int Age
    {
        get
        {
            return DateTime.Now.Year - this.DateOfBirth.Year - (DateTime.Today.DayOfYear < this.DateOfBirth.DayOfYear ? 1 : 0);
        }
    }
}