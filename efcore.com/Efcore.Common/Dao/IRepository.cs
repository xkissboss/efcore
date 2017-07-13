using Efcore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Efcore.Common.Dao
{
    public interface IRepository
    {
    }


    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : BaseEntity<TPrimaryKey>
    {

    }

}
