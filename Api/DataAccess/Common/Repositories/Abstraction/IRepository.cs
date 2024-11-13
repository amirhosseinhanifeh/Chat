using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mozer.DataAccess.Common.Repositories.Abstraction
{
    public interface IRepository<TModel>
    {
        Task<IEnumerable<TModel>> GetListAsync();

        void Add(TModel model);

        void AddRange(IEnumerable<TModel> modelList);

        void Update(TModel model);

        void Delete(TModel model);

        void Attach(TModel entity);

        void Detach(TModel entity);
        Task<TModel> Get(Expression<Func<TModel, bool>> predicate, string[] includes=null);
        Task<IEnumerable<TModel>> GetList(Expression<Func<TModel, bool>> predicate, string[] includes=null);
        IQueryable<TModel> AsQueryable();
    }
}
