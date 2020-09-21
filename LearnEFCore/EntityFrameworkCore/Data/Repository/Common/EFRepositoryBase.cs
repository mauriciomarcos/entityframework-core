using EntityFrameworkCore.Data.Context;
using EntityFrameworkCore.Domain.Interface.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.Data.Repository.Common
{
    public abstract class EFRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {     
        public virtual void Add(TEntity e)
        {
            using DataBaseContext _db = new DataBaseContext();
            _db.Set<TEntity>().Add(e);
            _db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using DataBaseContext _db = new DataBaseContext();
            return _db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int? id)
        {
            using DataBaseContext _db = new DataBaseContext();
            return _db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity e)
        {
            using DataBaseContext _db = new DataBaseContext();
            _db.Set<TEntity>().Remove(e);
            _db.SaveChanges();
        }

        public void Update(TEntity e)
        {
            using DataBaseContext _db = new DataBaseContext();
            _db.Entry(e).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
