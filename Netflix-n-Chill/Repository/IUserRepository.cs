using Netflix_n_Chill.Data.ValueObject;
using Netflix_n_Chill.Models;

namespace Netflix_n_Chill.Repository
{
    public interface IUserRepository
    {
        Users ValidateCredentials(UsersVO user);
    }
}
