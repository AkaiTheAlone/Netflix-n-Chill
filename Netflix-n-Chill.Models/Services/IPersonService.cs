using Netflix_n_Chill.Models.Modelos;

namespace Netflix_n_Chill.Models.Services
{
    public interface IPersonService
    {
        Person Create (Person person);  
        Person Update (Person person);
        void Delete(long id);
        Person FindByID (long id);
       
        List<Person> FindAll ();
    }
}
