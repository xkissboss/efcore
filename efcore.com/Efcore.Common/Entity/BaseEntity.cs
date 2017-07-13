using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Efcore.Common.Entity
{

    public abstract class BaseEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }

    public class BaseEntity : BaseEntity<Int64>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get => base.Id; set => base.Id = value; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime UpdateTime { get; set; }


        public BaseEntity()
        {
            CreateTime = DateTime.Now;
            IsDeleted = false;
            UpdateTime = DateTime.Now;
        }
    }
}
