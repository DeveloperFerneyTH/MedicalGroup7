using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalGroup7.Repository.Repositories
{
    public class PlaceRepositoryImpl : PlaceRepository
    {        
        public List<Place> GetPlaces()
        {
            try
            {
                MedicalGroup7Entities entities = new MedicalGroup7Entities();
                return entities.Places.ToList();
            }
            catch (PlaceRepositoryException ex)
            {
                throw ex;
            }
        }
    }

    public class PlaceRepositoryException : Exception
    {
        public PlaceRepositoryException(string message) : base(message)
        {
        }
    }
}
