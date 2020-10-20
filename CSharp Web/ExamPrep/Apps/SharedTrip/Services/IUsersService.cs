namespace SharedTrip.Services
{
    public interface IUsersService
    {
        void Create(string username, string email, string pasword);

        string GetUserId(string username, string pasword);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
