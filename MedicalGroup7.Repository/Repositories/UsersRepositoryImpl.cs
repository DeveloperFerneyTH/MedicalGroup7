using MedicalGroup7.Repository.Repositories;
using System;
using System.Linq;

namespace MedicalGroup7.Repository.Providers
{
    public class UsersRepositoryImpl : UsersRepository
    {
        public User GetUserByID(int id)
        {
            try
            {
                MedicalGroup7Entities entities = new MedicalGroup7Entities();
                return entities.Users.FirstOrDefault(u => u.ID == id);
            }
            catch (UsersRepositoryException ex)
            {
                throw ex;
            }
        }

        public User Login(string email, string pass)
        {
            try
            {
                MedicalGroup7Entities entities = new MedicalGroup7Entities();
                return entities.Users.FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(pass));
            }
            catch (UsersRepositoryException ex)
            {
                throw ex;
            }
        }
    }

    public class UsersRepositoryException : Exception
    {
        public UsersRepositoryException(string message) : base(message)
        {
        }
    }
}
