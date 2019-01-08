using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Epam.Task06._01_Users.DAL
{
    public class DAL : Interfaces.IDAL
    {
        private const string USERS_FILE = "users";
        private const string AWARDS_FILE = "awards";
        private Dictionary<int, Entities.User> userList;
        private Dictionary<int, Entities.Award> awardList;
        private FileInfo users;
        private FileInfo awards;
        private BinaryFormatter formatter;

        public DAL()
        {
            users = new FileInfo(Path.Combine(Environment.CurrentDirectory, USERS_FILE));
            awards = new FileInfo(Path.Combine(Environment.CurrentDirectory, AWARDS_FILE));
            formatter = new BinaryFormatter();

            if (users.Exists)
            {
                Stream stream = File.OpenRead(users.FullName);

                try
                {
                    userList = (Dictionary<int, Entities.User>)formatter.Deserialize(stream);
                }
                catch(System.Runtime.Serialization.SerializationException)
                {
                    userList = new Dictionary<int, Entities.User>();
                }
                finally
                {
                    stream.Close();
                }
            }
            else
            {                
                users.Create();
                userList = new Dictionary<int, Entities.User>();
            }

            if (awards.Exists)
            {
                Stream stream = File.OpenRead(awards.FullName);

                try
                {
                    awardList = (Dictionary<int, Entities.Award>)formatter.Deserialize(stream);
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    awardList = new Dictionary<int, Entities.Award>();
                }
                finally
                {
                    stream.Close();
                }
            }
            else
            {
                awards.Create();
                awardList = new Dictionary<int, Entities.Award>();
            }
        }

        public bool Add(int id, string name, DateTime dateOfBirth)
        {
            if (!userList.ContainsKey(id))
            {
                userList.Add(id, new Entities.User(name, dateOfBirth));
                Stream stream = File.OpenWrite(users.FullName);
                formatter.Serialize(stream, userList);
                stream.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            if (userList.ContainsKey(id))
            {
                Stream stream = File.OpenWrite(users.FullName);
                formatter.Serialize(stream, userList);
                stream.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Entities.User GetUser(int id)
        {
            if (userList.ContainsKey(id))
            {
                return userList[id];
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<int> GetIDs()
        {
            return this.userList.Keys;
        }

        public Entities.Award GetAward(int id)
        {
            if (awardList.ContainsKey(id))
            {
                return awardList[id];
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<int> GetAwardIDs()
        {
            return this.awardList.Keys;
        }

        public bool AwardUser(int user, int award)
        {
            if (userList.ContainsKey(user) && awardList.ContainsKey(award))
            {
                return userList[user].Awards.Add(award);
            }
            else
            {
                return false;
            }
        }

        public bool AddAward(int id, string name)
        {
            if (!awardList.ContainsKey(id))
            {
                awardList.Add(id, new Entities.Award(id, name));
                Stream stream = File.OpenWrite(awards.FullName);
                formatter.Serialize(stream, awardList);
                stream.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
