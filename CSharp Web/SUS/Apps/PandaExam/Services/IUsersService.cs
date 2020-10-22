namespace PandaExam.Services
{
    using PandaExam.ViewModels.Users;
    using System.Collections.Generic;

    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        string GetUsernameById(string id);

        string GetUserIdByUsername(string username);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);

        IEnumerable<string> GetAllUsernames();
    }
}
