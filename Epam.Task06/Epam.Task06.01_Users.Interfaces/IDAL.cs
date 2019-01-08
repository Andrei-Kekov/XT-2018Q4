using System;
using System.Collections.Generic;

namespace Epam.Task06._01_Users.Interfaces
{
    public interface IDAL
    {
        bool Add(int id, string name, DateTime dateOfBirth);
        bool Delete(int id);
        IEnumerable<int> GetIDs();
        Entities.User GetUser(int id);
    }
}
