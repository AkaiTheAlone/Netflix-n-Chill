using Netflix_n_Chill.Data.ValueObject;

namespace Netflix_n_Chill.Business.Abstractions
{
    public interface ILoginBussiness
    {
        TokenVO ValidateCredentials(UsersVO user); 
    }
}
