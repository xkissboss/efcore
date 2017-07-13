using Efcore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Efcore.Common.Dao
{
    public interface IRepository
    {
    }


    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : BaseEntity<TPrimaryKey>
    {
        TEntity Get(TPrimaryKey id);
        Task<TEntity> GetAsync(TPrimaryKey id);
        bool Insert(TEntity entity, bool autoSave = true);
        Task<bool> InsertAsync(TEntity entity, bool autoSave = true);
        bool Update(TEntity entity, bool autoSave = true);
        Task<bool> UpdateAsync(TEntity entity, bool autoSave = true);
        bool SaveOrUpdate(TEntity entity, bool autoSave = true);
        Task<bool> SaveOrUpdateAsync(TEntity entity, bool autoSave = true);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity GetNoTracking(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetNoTrackingAsync(Expression<Func<TEntity, bool>> predicate);
        bool Delete(TEntity entity, bool autoSave = true);
        Task<bool> DeleteAsync(TEntity entity, bool autoSave = true);
        bool SaveList(List<TEntity> entities, bool autoSave = true);
        Task<bool> SaveListAsync(List<TEntity> entities, bool autoSave = true);
        bool UpdateList(List<TEntity> entities, bool autoSave = true);
        Task<bool> UpdateListAsync(List<TEntity> entities, bool autoSave = true);
        bool DeleteList(List<TEntity> entities, bool autoSave = true);
        Task<bool> DeleteListAsync(List<TEntity> entities, bool autoSave = true);
        bool Delete(Expression<Func<TEntity, bool>> predicate, bool autoSave = true);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = true);
        IQueryable<TEntity> LoadAll(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> LoadAllAsync(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> LoadListAll(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> LoadListAllAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> LoadAllBySql(string sql, params DbParameter[] para);
        Task<IQueryable<TEntity>> LoadAllBySqlAsync(string sql, params DbParameter[] para);
        bool IsExist(Expression<Func<TEntity, bool>> predicate);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate);
        bool IsExist(string sql, params DbParameter[] para);
        Task<bool> IsExistAsync(string sql, params DbParameter[] para);
        PagedResult<TEntity> LoadPageList(int startPage, int pageSize, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null);
        IQueryable<TEntity> LoadPageList(int startPage, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null);
    }

}
