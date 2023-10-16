using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalGroup7.Repository.Repositories
{
    public class MedicalAppointmentRepositoryImpl : MedicalAppointmentRepository
    {
        public List<MedicalAppView> GetMedicalAppointmentsByUser(int userID)
        {
            try
            {
                MedicalGroup7Entities entities = new MedicalGroup7Entities();
                return entities.MedicalAppViews.Where(m => m.UserID == userID).ToList();
            }
            catch (MedicalAppointmentRepositoryException ex)
            {
                throw ex;
            }
        }

        public void CreateMedicalAppointment(MedicalAppointment appointment)
        {
            try
            {
                MedicalGroup7Entities entities = new MedicalGroup7Entities();
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
