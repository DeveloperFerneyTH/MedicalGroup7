using MedicalGroup7.Core.Domain;
using MedicalGroup7.Core.Domain.Mappers;
using MedicalGroup7.Repository.Repositories;
using System;
using System.Collections.Generic;

namespace MedicalGroup7.Core.Providers
{
    public class MedicalAppointmentProvider
    {
        MedicalAppointmentRepository repository;

        public MedicalAppointmentProvider()
        {
            repository = new MedicalAppointmentRepositoryImpl();
        }

        public List<MedicalAppointmentVw> GetMedicalAppointmentByUserID(int userID)
        {
            try
            {
                var medicals = repository.GetMedicalAppointmentsByUser(userID);
                return MedicalAppointmentMapper.RepositoryViewToDomain(medicals);
            }
            catch (MedicalAppointmentProviderException ex)
            {
                throw ex;
            }
        }

        public void InsertMedicalAppointment(MedicalAppointmentVw medical)
        {
            try
            {
                repository.CreateMedicalAppointment(MedicalAppointmentMapper.ViewToRepository(medical));
            }
            catch (MedicalAppointmentProviderException ex)
            {
                throw ex;
            }
        }
    }

    public class MedicalAppointmentProviderException : Exception
    {
        public MedicalAppointmentProviderException(string message) : base(message)
        {
        }
    }
}
