using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Contract;
using Sprout.Exam.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sprout.Exam.DataAccess.Concrete
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected SproutExamDbContext _dbContext;

        public BaseRepository(SproutExamDbContext dbContext) =>
            _dbContext = dbContext;

        public virtual IQueryable<T> FindAll() =>
            _dbContext.Set<T>().AsNoTracking();

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _dbContext.Set<T>().Where(expression).AsNoTracking();

        public virtual void Create(T model) =>
            _dbContext.Set<T>().Add(model);

        public virtual void Update(T model) =>
            _dbContext.Set<T>().UpdateRange(model);

        public virtual void Delete(T model) =>
            _dbContext.Set<T>().Remove(model);
    }
}
