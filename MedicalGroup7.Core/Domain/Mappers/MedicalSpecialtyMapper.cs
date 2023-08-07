using MedicalGroup7.Repository;
using System.Collections.Generic;

namespace MedicalGroup7.Core.Domain.Mappers
{
    public static class MedicalSpecialtyMapper
    {
        public static MedSpecialty RepositoryToDomain(MedicalSpecialty medical)
        {
            if (medical == null) return null;
            return new MedSpecialty()
            {
                ID = medical.ID,
                Name = medical.Name,
            };
        }

        public static List<MedSpecialty> RepositoryToDomain(List<MedicalSpecialty> medicals)
        {
            if (medicals == null) return null;
            List<MedSpecialty> list = new List<MedSpecialty>();

            foreach (MedicalSpecialty medical in medicals)
            {
                list.Add(RepositoryToDomain(medical));
            }

            return list;
        }
    }
}
