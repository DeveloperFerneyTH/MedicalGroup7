using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using MedicalGroup7.Core.Domain;
using MedicalGroup7.Repository.Repositories;
using System.Reflection;
using System.Linq;
using MedicalGroup7.Repository;

namespace MedicalGroup7.Core.Providers.Tests
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
            CollectionAssert.AreEqual(expectedAppointments, result);
        }

        //[Test]
        //public void InsertMedicalAppointment_ValidMedicalAppointment_CallsRepositoryMethod()
        //{
        //    // Arrange
        //    MedicalAppointmentVw medicalAppointment = new MedicalAppointmentVw();
        //    repositoryMock.Setup(r => r.CreateMedicalAppintment(It.IsAny<MedicalAppointmentRepository>()));

        //    // Act
        //    provider.InsertMedicalAppointment(medicalAppointment);

        //    // Assert
        //    repositoryMock.Verify(r => r.CreateMedicalAppintment(It.IsAny<MedicalAppointmentRepository>()), Times.Once);
        //}

        private List<MedicalAppView> CreateMedicalsDataMock(int userID)
        {
            List<MedicalAppView> medicalAppointments = new List<MedicalAppView>();
            medicalAppointments.Add(new MedicalAppView
            {
                Address = "Calle 163 #12-45",
                ID = 1,
                UserID = userID
            });
            return medicalAppointments;
        }

        private List<MedicalAppointmentVw> RepositoryViewToDomainMock(List<MedicalAppView> medicalAppView)
        {
            if (medicalAppView == null) return null;
            List<MedicalAppointmentVw> medicals = new List<MedicalAppointmentVw>();

            foreach (var med in medicalAppView)
            {
                medicals.Add(new MedicalAppointmentVw()
                {
                    Direccion = med.Address,
                    ID = med.ID,
                    FechaCita = med.MedicalDate,
                    Especialidad = med.MedSpecialty,
                    Descripcion = med.Name,
                    Clinica = med.Place,
                    UserID = med.UserID,
                });
            }

            return medicals;
        }
    }
}
