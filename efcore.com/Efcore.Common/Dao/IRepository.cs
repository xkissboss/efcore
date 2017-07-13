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
        /// <summary>
        /// 根据主键获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(TPrimaryKey id);
        /// <summary>
        /// 根据主键异步获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TPrimaryKey id);
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        bool Insert(TEntity entity, bool autoSave = true);
        /// <summary>
        /// 异步插入
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        Task<bool> InsertAsync(TEntity entity, bool autoSave = true);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        bool Update(TEntity entity, bool autoSave = true);
        /// <summary>
        /// 异步更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity, bool autoSave = true);
        /// <summary>
        /// 新增或者更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        bool InsertOrUpdate(TEntity entity, bool autoSave = true);
        /// <summary>
        /// 异步新增或者更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        Task<bool> InsertOrUpdateAsync(TEntity entity, bool autoSave = true);
        /// <summary>
        /// 根据表达式获取
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据表达式异步获取
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity GetNoTracking(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetNoTrackingAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        bool Delete(TEntity entity, bool autoSave = true);
        /// <summary>
        /// 异步删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity, bool autoSave = true);
        /// <summary>
        /// 保存列表
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        bool SaveList(List<TEntity> entities, bool autoSave = true);
        /// <summary>
        /// 异步保存列表
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        Task<bool> SaveListAsync(List<TEntity> entities, bool autoSave = true);
        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        bool UpdateList(List<TEntity> entities, bool autoSave = true);
        /// <summary>
        /// 异步更新列表
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        Task<bool> UpdateListAsync(List<TEntity> entities, bool autoSave = true);
        /// <summary>
        /// 删除列表
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        bool DeleteList(List<TEntity> entities, bool autoSave = true);
        /// <summary>
        /// 异步删除列表
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        Task<bool> DeleteListAsync(List<TEntity> entities, bool autoSave = true);
        /// <summary>
        /// 根据表达式删除
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        bool Delete(Expression<Func<TEntity, bool>> predicate, bool autoSave = true);
        /// <summary>
        /// 异步根据表达式删除
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = true);
        /// <summary>
        /// 根据表达式加载列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> LoadAll(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据表达式异步加载列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> LoadAllAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据表达式加载列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> LoadListAll(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据表达式异步加载列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TEntity>> LoadListAllAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据sql加载列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        IQueryable<TEntity> LoadAllBySql(string sql, params DbParameter[] para);
        /// <summary>
        /// 根据sql异步加载列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> LoadAllBySqlAsync(string sql, params DbParameter[] para);
        /// <summary>
        /// 根据表达式判断是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool IsExist(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据表达式异步判断是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据sql判断是否存在
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        bool IsExist(string sql, params DbParameter[] para);
        /// <summary>
        /// 根据sql异步判断是否存在
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        Task<bool> IsExistAsync(string sql, params DbParameter[] para);
        /// <summary>
        /// 分页加载
        /// </summary>
        /// <param name="startPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        PagedResult<TEntity> LoadPageList(int startPage, int pageSize, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null);
        /// <summary>
        /// 分页加载
        /// </summary>
        /// <param name="startPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        IQueryable<TEntity> LoadPageList(int startPage, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null);

        /// <summary>
        /// 根据id列表获取
        /// </summary>
        /// <param name="keyList"></param>
        /// <returns></returns>
        List<TEntity> Get(List<TPrimaryKey> keyList);
        /// <summary>
        /// 根据id列表异步获取
        /// </summary>
        /// <param name="keyList"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetAsync(List<TPrimaryKey> keyList);
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        bool Delete(TPrimaryKey id, bool autoSave = true);
        /// <summary>
        /// 根据id异步删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TPrimaryKey id, bool autoSave = true);
        /// <summary>
        /// 根据id列表删除
        /// </summary>
        /// <param name="keyList"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        bool DeleteByPks(List<TPrimaryKey> keyList, bool autoSave = true);
        /// <summary>
        /// 根据id列表异步删除
        /// </summary>
        /// <param name="keyList"></param>
        /// <param name="autoSave"></param>
        /// <returns></returns>
        Task<bool> DeleteByPksAsync(List<TPrimaryKey> keyList, bool autoSave = true);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, Int64> where TEntity : BaseEntity
    {

    }
}
