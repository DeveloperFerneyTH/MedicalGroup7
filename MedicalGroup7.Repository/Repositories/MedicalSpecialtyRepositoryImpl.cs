using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalGroup7.Repository.Repositories
{
    public class MedicalSpecialtyRepositoryImpl : MedicalSpecialtyRepository
    {       

        public List<MedicalSpecialty> GetMedicalSpecialties()
        {
            try
            {
                MedicalGroup7Entities entities = new MedicalGroup7Entities();
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
