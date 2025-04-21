using Netflix_n_Chill.Models;

namespace Netflix_n_Chill.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
        Person FindByID(long id);
        List<Person> FindAll();
    }
}
