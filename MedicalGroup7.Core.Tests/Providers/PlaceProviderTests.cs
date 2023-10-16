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
    public class PlaceProviderTests
    {
        private PlaceProvider provider;
        private Mock<PlaceRepository> repositoryMock;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<PlaceRepository>();
            provider = new PlaceProvider();
            typeof(PlaceProvider).GetField("repository", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(provider, repositoryMock.Object);
        }

        [Test]
        public void GetPlaces_ReturnsPlaces()
        {
            // Arrange
            List<Place> expectedPlaces = CreateDataMock();
            repositoryMock.Setup(r => r.GetPlaces()).Returns(expectedPlaces);

            // Act
            List<PlaceMedical> result = provider.GetPlaces();

            // Assert
            Assert.AreEqual(expectedPlaces.Count, result.Count);
            Assert.AreEqual(expectedPlaces[0].ID, result[0].ID);
            Assert.AreEqual(expectedPlaces[0].Name, result[0].Name);
        }

        private List<Place> CreateDataMock()
        {
            List<Place> data = new List<Place>
            {
                new Place
                {
                    ID = 1,
                    Name = "Clinica de prueba",
                    Address = "Calle falsa #12-3"
                }
            };
            return data;
        }
    }
}
