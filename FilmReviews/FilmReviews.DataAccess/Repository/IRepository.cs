﻿using FilmReviews.DataAccess.Entities;
using System.Linq.Expressions;

namespace FilmReviews.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
        T? GetById(int id);
        T? GetById(Guid id);
        T Save(T entity);
        void Delete(T entity);
    }
}
