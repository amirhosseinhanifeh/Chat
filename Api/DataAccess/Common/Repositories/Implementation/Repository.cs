using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mozer.DataAccess.Common.Repositories.Abstraction;
using Mozer.ServiceContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mozer.DataAccess.Common.Repositories.Implementation
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        public Repository(MozerContext context)
        {
            _context = context;
        }


        protected readonly MozerContext _context;


        public virtual void Add(TModel model)
        {
            _context.Entry(model).State = EntityState.Added;
        }

        public virtual void Update(TModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        public virtual void Delete(TModel model)
        {
            _context.Entry(model).State = EntityState.Deleted;
        }

        public virtual TModel Get(Guid Id)
        {

            var entity = _context.Set<TModel>().Find(Id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual TModel Get(int Id)
        {

            var entity = _context.Set<TModel>().Find(Id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;

            }
            return entity;
        }

        public virtual TModel Get(long Id)
        {

            var entity = _context.Set<TModel>().Find(Id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;

            }
            return entity;
        }

        public virtual TModel Get(short Id)
        {

            var entity = _context.Set<TModel>().Find(Id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;

            }
            return entity;
        }

        public virtual async Task<TModel> GetAsync(Guid Id)
        {
            var entity = await _context.Set<TModel>().FindAsync(Id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;

            }
            return entity;
        }

        public virtual async Task<TModel> GetAsync(int Id)
        {

            var entity = await _context.Set<TModel>().FindAsync(Id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<TModel> GetAsync(long Id)
        {

            var entity = await _context.Set<TModel>().FindAsync(Id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<IEnumerable<TModel>> GetListAsync()
        {
            return await _context.Set<TModel>().ToListAsync();
        }

        public virtual async Task<TModel> GetAsync(short Id)
        {
            var entity = await _context.Set<TModel>().FindAsync(Id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual void Attach(TModel entity)
        {
            _context.Attach(entity);
        }

        public virtual void Detach(TModel entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public async virtual Task<TModel> GetTrackingAsync(long Id)
        {
            return await _context.Set<TModel>().FindAsync(Id);
        }

        public async virtual Task<TModel> GetTrackingAsync(int Id)
        {
            return await _context.Set<TModel>().FindAsync(Id);
        }

        public async virtual Task<TModel> GetTrackingAsync(Guid Id)
        {
            return await _context.Set<TModel>().FindAsync(Id);
        }

        public async virtual Task<TModel> GetTrackingAsync(short Id)
        {
            return await _context.Set<TModel>().FindAsync(Id);
        }

        public void AddRange(IEnumerable<TModel> modelList)
        {
            _context.Set<TModel>().AddRange(modelList);
        }

        public virtual async Task<List<TModel>> GetListAsync(IEnumerable<int> keys, bool tracking)
        {
            return await GetListAsync<int>(keys, tracking);
        }

        public virtual async Task<List<TModel>> GetListAsync(IEnumerable<long> keys, bool tracking)
        {
            return await GetListAsync<long>(keys, tracking);
        }

        public virtual async Task<List<TModel>> GetListAsync(IEnumerable<short> keys, bool tracking)
        {
            return await GetListAsync<short>(keys, tracking);
        }

        public virtual async Task<List<TModel>> GetListAsync(IEnumerable<Guid> keys, bool tracking)
        {
            return await GetListAsync<Guid>(keys, tracking);
        }

        private async Task<List<TModel>> GetListAsync<Tkey>(IEnumerable<Tkey> keys, bool tracking)
        {
            var containsMethod = typeof(Enumerable).GetMethods()
            .FirstOrDefault(m => m.Name == "Contains" && m.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(object));

            var entityType = _context.Model.FindEntityType(typeof(TModel));
            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey.Properties.Count != 1)
                throw new NotSupportedException("Only a single primary key is supported");

            var pkProperty = primaryKey.Properties[0];
            // retrieve member info for primary key
            var pkMemberInfo = typeof(TModel).GetProperty(pkProperty.Name);
            if (pkMemberInfo == null)
                throw new ArgumentException("Type does not contain the primary key as an accessible property");

            // build lambda expression
            var parameter = Expression.Parameter(typeof(TModel), "e");
            var body = Expression.Call(null, containsMethod,
                Expression.Constant(keys),
                Expression.Convert(Expression.MakeMemberAccess(parameter, pkMemberInfo), typeof(object)));
            var predicateExpression = Expression.Lambda<Func<TModel, bool>>(body, parameter);

            // run query
            if (tracking)
            {

                return await _context.Set<TModel>()
                    .Where(predicateExpression)
                    .ToListAsync();
            }

            return await _context.Set<TModel>()
                .AsNoTracking()
                .Where(predicateExpression)
                .ToListAsync();
        }

        public async Task<TModel> Get(Expression<Func<TModel, bool>> predicate, string[] includes = null)
        {
            var query = _context.Set<TModel>().AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);

                }
            }
            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public IQueryable<TModel> AsQueryable()
        {
            return _context.Set<TModel>().AsQueryable();
        }

        public async Task<IEnumerable<TModel>> GetList(Expression<Func<TModel, bool>> predicate, string[] includes = null)
        {
            var query = _context.Set<TModel>().AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);

                }
            }
            return await query.Where(predicate).ToListAsync();
        }
    }
}
