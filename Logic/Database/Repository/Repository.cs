using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Repository.Interface;

namespace Logic.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private TPAEntities db = new TPAEntities();
        public TPAEntities Context
        {

            get { return db; }
            set { db = value; }
        }
        public Task<List<T>> GetAll()
        {
            var query = db.Set<T>();
            return query.ToListAsync();
        }

        public Task<List<T>> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            var query = db.Set<T>().Where(predicate);
            return query.ToListAsync();

        }

        public virtual void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChangesAsync();
        }
    }
}
