namespace HTTPServer.GameStoreApplication.Services.Contracts
{
    using GameStore.Models;

    public interface IUserService
    {
        bool Create(string email, string name, string password);

        bool Find(string email, string password);

        User FindByEmail(string email);

        bool IsAdmin(string email);
    }
}
