using BackendApi.Models;

namespace BackendApi.Interfaces
{
    public interface IAuthenticationService
    {
        string TokenGenerate(UserModel user);
    }
}
