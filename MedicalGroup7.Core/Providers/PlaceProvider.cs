using MedicalGroup7.Core.Domain;
using MedicalGroup7.Core.Domain.Mappers;
using MedicalGroup7.Repository.Repositories;
using System;
using System.Collections.Generic;

namespace MedicalGroup7.Core.Providers
{
    public class PlaceProvider
    {
        PlaceRepository repository;

        public PlaceProvider()
        {
            repository = new PlaceRepository();
        }

        public List<PlaceMedical> GetPlaces()
        {
            try
            {
                return PlaceMapper.RepositoryToDomain(repository.GetPlaces());
            }
            catch (PlaceProviderException ex)
            {
                throw ex;
            }
        }
    }

    public class PlaceProviderException : Exception
    {
        public PlaceProviderException(string message) : base(message)
        {
        }
    }
}
