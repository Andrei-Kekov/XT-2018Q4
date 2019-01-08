using System;
using System.Collections.Generic;

namespace Epam.Task06._01_Users.Interfaces
{
    public interface IBLL
    {
        bool Add(int id, string name, DateTime dateOfBirth);
        bool Delete(int id);
        IEnumerable<int> GetIDs();
        Entities.User GetUser(int id);
        bool AddAward(int id, string name);
        IEnumerable<int> GetAwardIDs();
        Entities.Award GetAward(int id);
        bool AwardUser(int user, int award);
    }
}
