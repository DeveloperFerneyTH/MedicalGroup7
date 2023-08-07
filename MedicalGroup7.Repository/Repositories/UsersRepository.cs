using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalGroup7.Repository.Providers
{
    public class UsersRepository
    {
        MedicalGroup7Entities entities;

        public UsersRepository()
        {
            entities = new MedicalGroup7Entities();
        }

        public User GetUserByID(int id)
        {
            try
            {
                return entities.Users.FirstOrDefault(u => u.ID == id);
            }
            catch (UsersProviderException ex)
            {
                throw ex;
            }
        }

        public User Login(string email, string pass)
        {
            try
            {
                return entities.Users.FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(pass));
            }
            catch (UsersProviderException ex)
            {
                throw ex;
            }
        }
    }

    public class UsersProviderException : Exception
    {
        public UsersProviderException(string message) : base(message)
        {
        }
    }
}
