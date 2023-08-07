using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalGroup7.Repository.Repositories
{
    public class PlaceRepository
    {
        MedicalGroup7Entities entities;

        public PlaceRepository()
        {
            entities = new MedicalGroup7Entities();
        }

        public List<Place> GetPlaces()
        {
            try
            {
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
