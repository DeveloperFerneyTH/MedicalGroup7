using MedicalGroup7.Core.Domain;
using MedicalGroup7.Core.Domain.Mappers;
using MedicalGroup7.Repository.Providers;
using MedicalGroup7.Repository.Repositories;
using System;

namespace MedicalGroup7.Core.Providers
{
	public class UserProvider
	{
		UsersRepository repository;

		public UserProvider()
		{

			repository = new UsersRepositoryImpl();
		}

		public UserMedical Login(string email, string password)
		{
			try
			{
				var user = repository.Login(email, password);
				return UserMapper.RepositoryToDomain(user);
			}
			catch (UserProviderException loginEx)
			{
				throw loginEx;
			}
		}
	}

	public class UserProviderException : Exception
	{
		public UserProviderException(string message) : base(message)
		{
		}
	}
}
