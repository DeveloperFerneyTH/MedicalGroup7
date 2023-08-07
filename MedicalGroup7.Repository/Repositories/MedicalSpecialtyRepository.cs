using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalGroup7.Repository.Repositories
{
    public class MedicalSpecialtyRepository
    {
        MedicalGroup7Entities entities;

        public MedicalSpecialtyRepository()
        {
            entities = new MedicalGroup7Entities();
        }

        public List<MedicalSpecialty> GetMedicalSpecialties()
        {
            try
            {
                return entities.MedicalSpecialties.ToList();
            }
            catch (MedicalSpecialtyRepositoryException ex)
            {
                throw ex;
            }
        }
    }

    public class MedicalSpecialtyRepositoryException : Exception
    {
        public MedicalSpecialtyRepositoryException(string message) : base(message)
        {
        }
    }
}
