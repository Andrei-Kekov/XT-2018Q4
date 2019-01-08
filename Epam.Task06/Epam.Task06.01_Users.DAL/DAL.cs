using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Epam.Task06._01_Users.DAL
{
    public class DAL : Interfaces.IDAL
    {
        private const string DATA_FILE = "data";
        private Dictionary<int, Entities.User> userList;
        private FileInfo data;
        private BinaryFormatter formatter;

        public DAL()
        {
            data = new FileInfo(Path.Combine(Environment.CurrentDirectory, DATA_FILE));
            formatter = new BinaryFormatter();
            if (data.Exists)
            {
                Stream stream = File.OpenRead(data.FullName);

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
                data.Create();
                userList = new Dictionary<int, Entities.User>();
            }
        }

        public bool Add(int id, string name, DateTime dateOfBirth)
        {
            if (!userList.ContainsKey(id))
            {
                userList.Add(id, new Entities.User(name, dateOfBirth));
                Stream stream = File.OpenWrite(data.FullName);
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
                Stream stream = File.OpenWrite(data.FullName);
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

        public IEnumerable<Entities.User> GetUsers()
        {
            return this.userList.Values;
        }
    }
}
