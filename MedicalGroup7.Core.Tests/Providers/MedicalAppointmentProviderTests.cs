using MedicalGroup7.Core.Domain;
using MedicalGroup7.Core.Providers;
using MedicalGroup7.Repository;
using MedicalGroup7.Repository.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

namespace MedicalGroup7.Core.Tests.Providers
{
    public class MedicalAppointmentProviderTests
    {
        private MedicalAppointmentProvider provider;
        private Mock<MedicalAppointmentRepository> repositoryMock;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<MedicalAppointmentRepository>();
            provider = new MedicalAppointmentProvider();
            typeof(MedicalAppointmentProvider).GetField("repository", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(provider, repositoryMock.Object);
        }

        [Test]
        public void GetMedicalAppointmentByUserID_ValidUserID_ReturnsAppointments()
        {
            // Arrange
            int userID = 1;
            List<MedicalAppView> expectedAppointments = CreateMedicalsDataMock(userID);
            repositoryMock.Setup(r => r.GetMedicalAppointmentsByUser(userID)).Returns(expectedAppointments);

            // Act
            List<MedicalAppointmentVw> result = provider.GetMedicalAppointmentByUserID(userID);

            // Assert
            Assert.AreEqual(expectedAppointments.Count, result.Count);
            Assert.AreEqual(expectedAppointments[0].UserID, result[0].UserID);
        }

        [Test]
        public void InsertMedicalAppointment_ValidMedicalAppointment_CallsRepositoryMethod()
        {
            // Arrange
            MedicalAppointmentVw medicalAppointment = new MedicalAppointmentVw();
            repositoryMock.Setup(r => r.CreateMedicalAppointment(It.IsAny<MedicalAppointment>()));

            // Act
            provider.InsertMedicalAppointment(medicalAppointment);

            // Assert
            repositoryMock.Verify(r => r.CreateMedicalAppointment(It.IsAny<MedicalAppointment>()), Times.Once);
        }

        private List<MedicalAppView> CreateMedicalsDataMock(int userID)
        {
            List<MedicalAppView> medicalAppointments = new List<MedicalAppView>
            {
                new MedicalAppView
                {
                    Address = "Calle 163 #12-45",
                    ID = 1,
                    UserID = userID,
                    Name = "Clinica de prueba",
                    Place = "Algun lugar"
                }
            };
            return medicalAppointments;
        }
    }
}
