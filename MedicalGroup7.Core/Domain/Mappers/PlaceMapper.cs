using MedicalGroup7.Repository;
using System.Collections.Generic;

namespace MedicalGroup7.Core.Domain.Mappers
{
    public static class PlaceMapper
    {
        public static PlaceMedical RepositoryToDomain(Place place)
        {
            if (place == null) return null;
            return new PlaceMedical()
            {
                Address = place.Address,
                City = place.City,
                ID = place.ID,
                Name = place.Name
            };
        }

        public static List<PlaceMedical> RepositoryToDomain(List<Place> places)
        {
            if (places == null) return null;
            List<PlaceMedical> list = new List<PlaceMedical>();

            foreach (var place in places)
            {
                list.Add(RepositoryToDomain(place));
            }
            
            return list;
        }
    }
}
