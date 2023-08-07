using MedicalGroup7.Repository;
using System.Collections.Generic;

namespace MedicalGroup7.Core.Domain.Mappers
{
    public static class MedicalAppointmentMapper
    {
        public static List<MedicalAppointmentVw> RepositoryViewToDomain(List<MedicalAppView> medicalAppView)
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

        public static MedicalAppointment ViewToRepository(MedicalAppointmentVw medical)
        {
            if (medical == null) return null;
            return new MedicalAppointment()
            {
                ID = medical.ID,
                MedicalDate = medical.FechaCita,
                MedicalSpID = medical.MedicalSpID,
                Name = medical.Descripcion,
                PlaceID = medical.PlaceID,
                UserID = medical.UserID,
            };
        }
    }
}
