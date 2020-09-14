using EntityFrameworkCore.Data.Context;
using EntityFrameworkCore.Domain.Interface.Repository.Common;
using System.Collections.Generic;

namespace EntityFrameworkCore.Data.Repository.Common
{
    public abstract class EFRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DataBaseContext _db;

        public EFRepositoryBase(DataBaseContext context) =>
            _db = context;

        public void Add(TEntity e)
        {
            _db.Add(e);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(TEntity e)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity e)
        {
            throw new System.NotImplementedException();
        }
    }
}
