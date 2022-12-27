using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQHotel.Helper
{
    public interface IDapperRepository 
    {
        void RunScript(string Query);
        Task RunScriptAsync(string Query);
        void RunSp(string spName, object pars);
        Task RunSpAsync(string spName, object pars);
        TEntity GetEntity<TEntity>(string spName, object pars);
        Task<TEntity> GetEntityAsync<TEntity>(string spName, object pars);
        List<TEntity> GetEntityList<TEntity>(string spName, object pars);
        Task<List<TEntity>> GetEntityListAsync<TEntity>(string spName, object pars);
    }
}
