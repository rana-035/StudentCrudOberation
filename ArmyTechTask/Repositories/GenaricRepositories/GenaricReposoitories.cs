
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GenaricReposoitories<T> where T:Class1
    {
        private DbSet<T> db;
        public ArmyTechTaskEntities Context;
        public GenaricReposoitories(ArmyTechTaskEntities context)
        {
            Context = context;
            db = context.Set<T>();
        }
        public T Add(T T)
        {
            return db.Add(T);
        }
        public IEnumerable<T> GetAll()
        {
            return db;
        }
        public T GetByID(int ID)
        {
            return db.FirstOrDefault(i => i.ID == ID);
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return db.Where(filter);
        }
        public T Update(T T)
        {
            if (!db.Local.Any(i => i.ID == T.ID))
                db.Attach(T);
            Context.Entry(T).State = EntityState.Modified;
            
            return T;
        }
        
        public void Remove(T T)
        {
            if (!db.Local.Any(i => i.ID == T.ID))
                db.Attach(T);
            db.Remove(T);
            
        }
    }
}
