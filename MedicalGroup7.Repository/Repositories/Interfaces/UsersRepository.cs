namespace MedicalGroup7.Repository.Repositories
{
    public interface UsersRepository
    {
        User GetUserByID(int id);
        User Login(string email, string pass);
    }
}
