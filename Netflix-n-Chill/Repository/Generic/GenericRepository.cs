using System.Data;
using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;
using Netflix_n_Chill.Models.Base;

namespace Netflix_n_Chill.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private AppDbContext context;
        private DbSet<T> dataSet;
        public GenericRepository(AppDbContext _context)
        {
            context = _context;
            dataSet = context.Set<T>();
        }
        public T Create(T Item)
        {
            try
            {
                dataSet.Add(Item);
                context.SaveChanges();

            }
            catch (Exception) { throw; }

            return Item;
        }

        public void Delete(long id)
        {
            var target = dataSet.SingleOrDefault(x => x.Id == id);
            if (target != null)
            {
                try
                {
                    dataSet.Remove(target);
                    context.SaveChanges();
                }
                catch (Exception) { throw; }
            }
        }

        public bool Exists(long id)
        {
            return dataSet.Any(z => z.Id == id);
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindByID(long id)
        {
            return dataSet.SingleOrDefault(x => x.Id == id);
        }

        public T Update(T Item)
        {
            var result = dataSet.SingleOrDefault(p => p.Id == Item.Id);
            if (result != null)
            {
                try
                {
                    if (Item == null) throw new ApplicationException("Invalid Request!");
                    context.SaveChanges();
                }
                catch (Exception) { throw; }


                dataSet.Update(Item);
            }
            else
            {
                return null;
            }
            return Item;
        }
    }
}
