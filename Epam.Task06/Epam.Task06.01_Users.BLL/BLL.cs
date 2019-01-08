using System;
using System.Collections.Generic;

namespace Epam.Task06._01_Users.BLL
{
    public class BLL : Interfaces.IBLL
    {
        private Interfaces.IDAL dal;

        public BLL()
        {
            dal = Containers.DALContainer.GetDAL();
        }

        public bool Add(int id, string name, DateTime dateOfBirth)
        {
            return(dal.Add(id, name, dateOfBirth));
        }

        public bool Delete(int id)
        {
            return (dal.Delete(id));
        }

        public IEnumerable<int> GetIDs()
        {
            return dal.GetIDs();
        }

        public Entities.User GetUser(int id)
        {
            return dal.GetUser(id);
        }

        public bool AddAward(int id, string name)
        {
            return dal.AddAward(id, name);
        }

        public IEnumerable<int> GetAwardIDs()
        {
            return dal.GetAwardIDs();
        }

        public Entities.Award GetAward(int id)
        {
            return dal.GetAward(id);
        }

        public bool AwardUser(int user, int award)
        {
            return dal.AwardUser(user, award);
        }
    }
}
