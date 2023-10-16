using MedicalGroup7.Core.Domain;
using MedicalGroup7.Core.Providers;
using MedicalGroup7.Repository;
using MedicalGroup7.Repository.Providers;
using MedicalGroup7.Repository.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Reflection;

namespace MedicalGroup7.Core.Tests.Providers
{
    public class UserProviderTests
    {
        private UserProvider provider;
        private Mock<UsersRepository> repositoryMock;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<UsersRepository>();
            provider = new UserProvider();
            typeof(UserProvider).GetField("repository", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(provider, repositoryMock.Object);
        }

        [Test]
        public void Login_ValidCredentials_ReturnsUserMedical()
        {
            // Arrange
            string email = "user@example.com";
            string password = "password123";

            // Simula un usuario válido en el repositorio
            var userInRepository = CreateDataMock();

            repositoryMock.Setup(r => r.Login(email, password)).Returns(userInRepository);

            // Act
            UserMedical result = provider.Login(email, password);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userInRepository.Email, result.Email);
        }

        [Test]
        public void Login_InvalidCredentials_ThrowsUserProviderException()
        {
            // Arrange
            string email = "user@example.com";
            string password = "invalidpassword";

            // Simula una excepción en el repositorio al tratar de autenticar
            repositoryMock.Setup(r => r.Login(email, password)).Throws(new UsersRepositoryException("Invalid credentials"));

            // Act y Assert
            Assert.Throws<UsersRepositoryException>(() => provider.Login(email, password));
        }

        private User CreateDataMock()
        {
            return new User()
            {
                ID = 1,
                Created = DateTime.Now,
                Email = "user@example.com",
                FirtName = "Usuario",
                LastName = "Prueba"
            };
        }
    }
}
