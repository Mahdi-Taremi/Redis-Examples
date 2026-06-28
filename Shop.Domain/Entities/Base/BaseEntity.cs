using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


        protected BaseEntity()
        {
              Id = Guid.NewGuid();
            //Use .NET 9
            //Id = Guid.CreateVersion7();
        }
    }
}
