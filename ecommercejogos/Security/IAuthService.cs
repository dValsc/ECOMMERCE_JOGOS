using ecommercejogos.Model;
namespace ecommercejogos.Security
{
    public interface IAuthService
    {
            Task<UserLogin?> Autenticar(UserLogin userLogin);
        
    }
}
