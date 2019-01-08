using System;

namespace Epam.Task06._01_Users.Entities
{
    [Serializable]
    public class Award
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Award(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
