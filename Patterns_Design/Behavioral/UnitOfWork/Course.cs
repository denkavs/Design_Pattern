using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.UnitOfWork
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public override void Update(BaseEntity src)
        {
            Course c = src as Course;
            if(c == null)
                throw new ArgumentException("Parameter are not Course type");

            this.Name = c.Name;
        }
    }
}
