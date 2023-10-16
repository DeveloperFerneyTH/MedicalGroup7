using MedicalGroup7.Core.Domain;
using MedicalGroup7.Core.Providers;
using MedicalGroup7.Repository;
using MedicalGroup7.Repository.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicalGroup7.Core.Tests.Providers
{
    public class MedicalSpecialtyProviderTest
    {
        private MedicalSpecialtyProvider provider;
        private Mock<MedicalSpecialtyRepository> repositoryMock;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<MedicalSpecialtyRepository>();
            provider = new MedicalSpecialtyProvider();
            typeof(MedicalSpecialtyProvider).GetField("repository", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(provider, repositoryMock.Object);
        }

        [Test]
        public void GetSpecialties_ReturnsSpecialties()
        {
            // Arrange
            List<MedicalSpecialty> expectedSpecialties = CreateDataMock();
            repositoryMock.Setup(r => r.GetMedicalSpecialties()).Returns(expectedSpecialties);

            // Act
            List<MedSpecialty> result = provider.GetSpecialties();

            // Assert
            Assert.AreEqual(expectedSpecialties.Count, result.Count);
            Assert.AreEqual(expectedSpecialties[0].ID, result[0].ID);
            Assert.AreEqual(expectedSpecialties[0].Name, result[0].Name);
        }

        private List<MedicalSpecialty> CreateDataMock()
        {
            List<MedicalSpecialty> data = new List<MedicalSpecialty>
            {
                new MedicalSpecialty
                {
                    ID = 1,
                    Name = "Especialidad de prueba"
                }
            };
            return data;
        }
    }
}
