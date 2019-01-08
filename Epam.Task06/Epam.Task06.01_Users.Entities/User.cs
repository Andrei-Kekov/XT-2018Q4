using System;

namespace Epam.Task06._01_Users.Entities
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                return now.DayOfYear < this.DateOfBirth.DayOfYear ? now.Year - DateOfBirth.Year - 1 : now.Year - DateOfBirth.Year;
            }
        }

        public User(string name, DateTime dateOfBirth)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }
    }
}