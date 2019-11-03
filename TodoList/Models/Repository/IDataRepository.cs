﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoList.Models.Repository
{
    public interface IDataRepository<T>
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T dbEntity, T entity);
    }
}
