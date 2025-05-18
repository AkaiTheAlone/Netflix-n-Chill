using Netflix_n_Chill.Models;

namespace Netflix_n_Chill.Business
{
    public interface IBookBusiness
    {
        Books Create(Books Book);
        Books Update(Books Book);
        void Delete(long id);
        Books FindByID(long id);
        List<Books> FindAll();
    }
}
