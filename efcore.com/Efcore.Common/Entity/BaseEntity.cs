using System;
using System.Collections.Generic;
using System.Text;

namespace Efcore.Common.Entity
{

    public abstract class BaseEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }

    public class BaseEntity : BaseEntity<Int64>
    {
        public override long Id { get => base.Id; set => base.Id = value; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }

        public bool UpdateTime { get; set; }
    }
}
