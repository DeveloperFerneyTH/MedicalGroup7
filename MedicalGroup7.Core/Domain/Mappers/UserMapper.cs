using MedicalGroup7.Repository;

namespace MedicalGroup7.Core.Domain.Mappers
{
    public static class UserMapper
    {
        public static UserMedical RepositoryToDomain(User user)
        {
            if (user == null) return null;
            return new UserMedical()
            {
                Email = user.Email,
                FirtName = user.FirtName,
                LastName = user.LastName,
                Password = user.Password,
                UserID = user.ID
            };
        }
    }
}
