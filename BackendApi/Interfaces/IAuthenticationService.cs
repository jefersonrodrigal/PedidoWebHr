using BackendApi.Models;
using BackendApi.ViewModels;

namespace BackendApi.Interfaces
{
    public interface IAuthenticationService
    {
        string TokenGenerate(UserAuthModel user);
    }
}
