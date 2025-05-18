using Netflix_n_Chill.Models;

namespace Netflix_n_Chill.Repository
{
    public interface IBookRepository
    {
        Books Create(Books book);
        Books Update(Books book);
        void Delete(long id);
        Books FindByID(long id);
        List<Books> FindAll();
        bool Exists(long id);
    }
}

