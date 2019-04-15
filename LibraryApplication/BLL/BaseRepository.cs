using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseRepository<TEntity> where TEntity:class
    {
        LibraryContext _db;
        public BaseRepository(LibraryContext db)
        {
            _db = db;
        }
        public List<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }
        public TEntity Add(TEntity entity)
        {
           return _db.Set<TEntity>().Add(entity);

        }
        public void Delete(int id)
        {
            TEntity entity = GetById(id);
            _db.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            Type t = typeof(TEntity);
            var idProp = t.GetProperty("Id");
            int id = (int)idProp.GetValue(entity);

            var previousData = GetById(id);
            _db.Entry(previousData).CurrentValues.SetValues(entity);
        }
    }
}
