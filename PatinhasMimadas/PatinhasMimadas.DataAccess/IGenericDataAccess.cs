using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.DataAccess
{
    public interface IGenericDataAccess<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAll();

        Task<TEntity> Get(Guid id);

        Task Add(TEntity entity);

        Task Update(TEntity entity);

    }
}
