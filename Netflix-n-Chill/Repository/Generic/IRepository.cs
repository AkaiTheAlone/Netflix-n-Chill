using Netflix_n_Chill.Models.Base;

namespace Netflix_n_Chill.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity //it means IRep asks for an Type object inherinting from BaseEntity class
    {
        T Create(T Item);
        T Update(T Item);
        void Delete(long id);
        List<T> FindAll();
        T FindByID(long id);
        bool Exists(long id);

    }
}
