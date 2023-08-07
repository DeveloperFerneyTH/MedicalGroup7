using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalGroup7.Repository.Repositories
{
    public class MedicalAppointmentRepository
    {
        MedicalGroup7Entities entities;

        public MedicalAppointmentRepository()
        {
            entities = new MedicalGroup7Entities();
        }

        public List<MedicalAppView> GetMedicalAppointmentsByUser(int userID)
        {
            try
            {
                return entities.MedicalAppViews.Where(m => m.UserID == userID).ToList();
            }
            catch (MedicalAppointmentRepositoryException ex)
            {
                throw ex;
            }
        }

        public void CreateMedicalAppintment(MedicalAppointment appointment)
        {
            try
            {
                entities.MedicalAppointments.Add(appointment);
                entities.SaveChanges();
            }
            catch (MedicalAppointmentRepositoryException ex)
            {
                throw ex;
            }
        }
    }

    public class MedicalAppointmentRepositoryException : Exception
    {
        public MedicalAppointmentRepositoryException(string message) : base(message)
        {
        }
    }
}
