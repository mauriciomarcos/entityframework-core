﻿using System.Collections.Generic;

namespace EntityFrameworkCore.Domain.Interface.Repository.Common
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity e);
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity e);
        void DisconnectedUpdate(TEntity e, object objValues);
        void Remove(TEntity e);
    }
}