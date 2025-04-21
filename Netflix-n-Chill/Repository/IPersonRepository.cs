using Netflix_n_Chill.Models;

namespace Netflix_n_Chill.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
        Person FindByID(long id);
        List<Person> FindAll();
        bool Exists(long id);
    }
}
