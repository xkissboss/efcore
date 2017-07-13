using Efcore.Common.Entity;
using Microsoft.EntityFrameworkCore;
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
    public abstract class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public TEntity Get(TPrimaryKey id)
        {
            return context.Set<TEntity>().Find(id);
        }


        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }


        public virtual bool Insert(TEntity entity, bool autoSave = true)
        {
            context.Set<TEntity>().Add(entity);
            if (autoSave)
                return Save() > 0;
            return false;
        }

        public virtual async Task<bool> InsertAsync(TEntity entity, bool autoSave = true)
        {

            await context.Set<TEntity>().AddAsync(entity);
            if (autoSave)
                return await SaveAsync() > 0;
            return false;
        }


        public virtual bool Update(TEntity entity, bool autoSave = true)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            if (autoSave)
                return Save() > 0;
            else
                return false;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity, bool autoSave = true)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            if (autoSave)
                return await SaveAsync() > 0;
            else
                return false;
        }

        public virtual bool SaveOrUpdate(TEntity entity, bool autoSave = true)
        {
            if (Get(entity.Id) != null)
                return Update(entity, autoSave);
            return Insert(entity, autoSave);
        }
        /// <summary>
        /// 增加或更新一条记录（异步方式）
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="IsSave">是否增加</param>
        /// <param name="IsCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        public virtual async Task<bool> SaveOrUpdateAsync(TEntity entity, bool autoSave = true)
        {
            if ((await GetAsync(entity.Id)) != null)
                return await UpdateAsync(entity, autoSave);
            return await InsertAsync(entity, autoSave);
        }



        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => context.Set<TEntity>().FirstOrDefaultAsync(predicate));
        }


        public virtual TEntity GetNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().AsNoTracking().FirstOrDefault(predicate);
        }

        public virtual async Task<TEntity> GetNoTrackingAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public virtual bool Delete(TEntity entity, bool autoSave = true)
        {
            if (entity == null) return false;
            context.Set<TEntity>().Attach(entity);
            context.Set<TEntity>().Remove(entity);

            if (autoSave)
                return Save() > 0;
            else
                return false;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity, bool autoSave = true)
        {
            if (entity == null) return await Task.Run(() => false);
            context.Set<TEntity>().Attach(entity);
            context.Set<TEntity>().Remove(entity);
            if (autoSave)
                return await SaveAsync() > 0;
            else
                return false;
        }

        public virtual bool SaveList(List<TEntity> entities, bool autoSave = true)
        {
            if (entities == null || entities.Count == 0) return false;

            entities.ForEach(item =>
            {
                context.Set<TEntity>().Add(item);
            });

            if (autoSave)
                return Save() > 0;
            else
                return false;
        }


        public virtual async Task<bool> SaveListAsync(List<TEntity> entities, bool autoSave = true)
        {
            if (entities == null || entities.Count == 0) return false;

            entities.ForEach(item =>
            {
                context.Set<TEntity>().Add(item);
            });

            if (autoSave)
                return await SaveAsync() > 0;
            else
                return false;
        }




        public virtual bool UpdateList(List<TEntity> entities, bool autoSave = true)
        {
            if (entities == null || entities.Count == 0) return false;

            entities.ForEach(item =>
            {
                Update(item, false);
            });

            if (autoSave)
                return Save() > 0;
            else
                return false;
        }

        public virtual async Task<bool> UpdateListAsync(List<TEntity> entities, bool autoSave = true)
        {
            if (entities == null || entities.Count == 0) return false;

            entities.ForEach(item =>
            {
                Update(item, false);
            });

            if (autoSave)
                return await SaveAsync() > 0;
            else
                return false;
        }



        public virtual bool DeleteList(List<TEntity> entities, bool autoSave = true)
        {
            if (entities == null || entities.Count == 0) return false;

            entities.ForEach(item =>
            {
                Delete(item, false);
            });
            if (autoSave)
                return Save() > 0;
            else
                return false;
        }


        public virtual async Task<bool> DeleteListAsync(List<TEntity> entities, bool autoSave = true)
        {
            if (entities == null || entities.Count == 0) return false;

            entities.ForEach(item =>
            {
                Delete(item, false);
            });
            if (autoSave)
                return await SaveAsync() > 0;
            else
                return false;
        }


        public virtual bool Delete(Expression<Func<TEntity, bool>> predicate, bool autoSave = true)
        {
            context.Set<TEntity>().Where(predicate).ToList().ForEach(item => context.Set<TEntity>().Remove(item));
            if (autoSave)
                return Save() > 0;
            else
                return false;
        }




        public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = true)
        {
            await context.Set<TEntity>().Where(predicate).ForEachAsync(item => context.Set<TEntity>().Remove(item));
            if (autoSave)
                return Save() > 0;
            else
                return false;
        }

        public virtual IQueryable<TEntity> LoadAll(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate != null ? context.Set<TEntity>().Where(predicate).AsNoTracking<TEntity>() : context.Set<TEntity>().AsQueryable<TEntity>().AsNoTracking<TEntity>();
        }

        public virtual async Task<IQueryable<TEntity>> LoadAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate != null ? await Task.Run(() => context.Set<TEntity>().Where(predicate).AsNoTracking<TEntity>()) : await Task.Run(() => context.Set<TEntity>().AsQueryable<TEntity>().AsNoTracking<TEntity>());
        }


        public virtual List<TEntity> LoadListAll(Expression<Func<TEntity, bool>> predicate)
        {
            return LoadAll(predicate).ToList();
        }

        public virtual async Task<List<TEntity>> LoadListAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return (await LoadAllAsync(predicate)).ToList();
        }

        public virtual IQueryable<TEntity> LoadAllBySql(string sql, params DbParameter[] para)
        {
            return context.Set<TEntity>().FromSql(sql, para);
        }

        public virtual async Task<IQueryable<TEntity>> LoadAllBySqlAsync(string sql, params DbParameter[] para)
        {
            return await Task.Run(() => LoadAllBySql(sql, para));
        }



        public virtual bool IsExist(Expression<Func<TEntity, bool>> predicate)
        {
            var entry = context.Set<TEntity>().Where(predicate);
            return (entry.Any());
        }
        /// <summary>
        /// 验证当前条件是否存在相同项（异步方式）
        /// </summary>
        public virtual async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entry = context.Set<TEntity>().Where(predicate);
            return await Task.Run(() => entry.Any());
        }


        /// <summary>
        /// 根据SQL验证实体对象是否存在
        /// </summary>
        public virtual bool IsExist(string sql, params DbParameter[] para)
        {
            return context.Database.ExecuteSqlCommand(sql, para) > 0;
        }
        /// <summary>
        /// 根据SQL验证实体对象是否存在（异步方式）
        /// </summary>
        public virtual async Task<bool> IsExistAsync(string sql, params DbParameter[] para)
        {
            return await Task.Run(() => context.Database.ExecuteSqlCommand(sql, para) > 0);
        }



        public virtual PagedResult<TEntity> LoadPageList(int startPage, int pageSize, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null)
        {

            if (startPage < 1) startPage = 1;
            if (pageSize < 1) pageSize = 15;
            var result = from p in context.Set<TEntity>()
                         select p;
            if (where != null)
                result = result.Where(where);
            if (order != null)
                result = result.OrderBy(order);
            else
                result = result.OrderBy(m => m.Id);

            return result.PageResult<TEntity>(startPage, pageSize);
        }



        public IQueryable<TEntity> LoadPageList(int startPage, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null)
        {

            if (startPage < 1) startPage = 1;
            if (pageSize < 1) pageSize = 15;
            var result = from p in context.Set<TEntity>()
                         select p;
            if (where != null)
                result = result.Where(where);
            if (order != null)
                result = result.OrderBy(order);
            else
                result = result.OrderBy(m => m.Id);
            rowCount = result.Count();
            return result.Skip((startPage - 1) * pageSize).Take(pageSize);
        }




        public virtual int Save()
        {
            return context.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
