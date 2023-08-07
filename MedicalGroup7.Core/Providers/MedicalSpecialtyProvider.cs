using MedicalGroup7.Core.Domain;
using MedicalGroup7.Core.Domain.Mappers;
using MedicalGroup7.Repository.Repositories;
using System;
using System.Collections.Generic;

namespace MedicalGroup7.Core.Providers
{
    public class MedicalSpecialtyProvider
    {
        MedicalSpecialtyRepository repository;

        public MedicalSpecialtyProvider()
        {
            repository = new MedicalSpecialtyRepository();
        }

        public List<MedSpecialty> GetSpecialties()
        {
            try
            {
                return MedicalSpecialtyMapper.RepositoryToDomain(repository.GetMedicalSpecialties());
            }
            catch (MedicalSpecialtyProviderException ex)
            {
                throw ex;
            }
        }
    }

    public class MedicalSpecialtyProviderException : Exception
    {
        public MedicalSpecialtyProviderException(string message) : base(message)
        {
        }
    }
}
