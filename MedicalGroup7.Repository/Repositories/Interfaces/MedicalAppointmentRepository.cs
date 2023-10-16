using System.Collections.Generic;

namespace MedicalGroup7.Repository.Repositories
{
    public interface MedicalAppointmentRepository
    {
        List<MedicalAppView> GetMedicalAppointmentsByUser(int userID);
        void CreateMedicalAppointment(MedicalAppointment appointment);
    }
}
