using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06._01_Users.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }

        DateTime DateOfBirth { get; set; }

        int Age { get; }
    }

    public interface IBLL
    {
        bool Add(int id, string name, DateTime dateOfBirth);
        bool Remove(int id);
        Dictionary<int, IUser> GetUserList();
    }
}
