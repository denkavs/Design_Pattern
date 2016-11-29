using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.UnitOfWork
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public abstract void Update(BaseEntity src);
    }
}
